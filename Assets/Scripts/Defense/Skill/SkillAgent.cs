using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Skill = Defense.Skill;
using ComSkill = Defense.ComSkill;

public class SkillAgent
{
    private ComDefensePlayer m_Player = null;
    private Transform m_Root = null;

    // Skill의 정보를 담고있는 데이터 (*최대 5개까지 저장)
    private List<Skill> m_Skill = new List<Skill>();

    // 실제로 행동하는 Skill을 담고있는 Pool
    private Dictionary<int, FixedPool<ComSkill>> m_ComSkill = new Dictionary<int, FixedPool<ComSkill>>();

    private List<SkillBuff> m_Buffs = new List<SkillBuff>();

    public SkillAgent(ComDefensePlayer player, Transform root)
    {
        m_Player = player;
        m_Root = root;

        foreach(var skillbuff in ComDefense.Root.soSkillBuff)
        {
            m_Buffs.Add(skillbuff.skillBuffs[0]);
        }
    }

    public void Add(Skill skill, GameObject prefab, Transform root, int initalCount = 8)
    {
        m_Skill.Add(skill);

        int idx = GetIndex(skill);
        ComSkill[] comSkills = new ComSkill[initalCount];

        for (int i = 0; i < initalCount; ++i)
        {
            var obj = GameObject.Instantiate(prefab, root);
            obj.SetActive(false);

            ComSkill comSkill = obj.GetComponent<ComSkill>();
            comSkill.m_Skill = m_Skill[idx];
            comSkills[i] = comSkill;
        }

        if (!m_ComSkill.ContainsKey(idx))
        {
            m_ComSkill.Add(idx, new FixedPool<ComSkill>(comSkills[0]));
        }

        foreach (ComSkill comSkill in comSkills)
        {
            m_ComSkill[idx].Add(comSkill);
        }

        RemoveBuff(skill.Info);
        AddBuff(skill.Info);
    }

    public void Add(SkillId id)
    {
        switch (id)
        {
            case SkillId.MagicMissile:
                Add(new MagicMissile(), m_Player.m_SkillPrefabs[(int)id], m_Root);
                break;

            case SkillId.Fireball:
                Add(new Fireball(), m_Player.m_SkillPrefabs[(int)id], m_Root);
                break;

            case SkillId.Icebolt:
                Add(new Icebolt(), m_Player.m_SkillPrefabs[(int)id], m_Root);
                break;
        }
    }

    public void AddBuff(SkillInfo info)
    {
        SOSkillBuff skillBuff = ComDefense.Root.soSkillBuff[(int)info.id];

        foreach(SkillBuffId buffId in info.buffChains)
        {
            m_Buffs.Add(skillBuff.skillBuffs.Find(buff => buff.buffId.Equals(buffId)));
        }
    }

    public void RemoveBuff(SkillInfo info)
    {
        int idx = m_Buffs.FindIndex(buff => buff.id.Equals(info.id));

        m_Buffs.RemoveAt(idx);
    }

    //TODO
    public void RemoveBuff(SkillBuff buff)
    {
        if(--buff.count <= 0)
        {
            int idx = m_Buffs.FindIndex(x => x.Equals(buff));

            m_Buffs.RemoveAt(idx);
        }
    }

    //TODO
    public void Edit(SkillBuff buff)
    {
        Skill skill = m_Skill.Find(x => x.Info.id.Equals(buff.id));

        if (skill != null)
        {
            for (int i = 0, length = buff.skillStatusType.Length; i < length; ++i)
            {
                switch (buff.skillStatusType[i])
                {
                    case SkillStatusType.Cooldown:
                        skill.Info.cooldown -= (skill.Info.cooldown * buff.buffValue[i]);
                        break;

                    case SkillStatusType.SkillRange:
                        break;

                    case SkillStatusType.MoveSpeed:
                        skill.Info.moveSpeed = (skill.Info.moveSpeed * (1 + (buff.buffValue[i] * 0.01f)));
                        break;

                    case SkillStatusType.DefaultDamage:
                        skill.Info.defaultDamage = (skill.Info.defaultDamage * (1 + (buff.buffValue[i] * 0.01f)));
                        break;

                    case SkillStatusType.Pentrate:
                        skill.Info.penetrate += (int)buff.buffValue[i];
                        break;

                    case SkillStatusType.CastCount:
                        skill.Info.castCount += (int)buff.buffValue[i];
                        break;

                    case SkillStatusType.ExplosionRange:
                        skill.Info.explosionRange = skill.Info.explosionRange * (1 + (buff.buffValue[i] * 0.01f));
                        break;

                    case SkillStatusType.ExplosionDamage:
                        skill.Info.explosionDamage = (skill.Info.explosionDamage * (1 + (buff.buffValue[i] * 0.01f)));
                        break;
                }
            }

            RemoveBuff(buff);
        }
        else
        {
            Add(buff.id);
        }
    }

    public SkillBuff[] GetRandomBuffs()
    {
        List<SkillBuff> result = new List<SkillBuff>();

        while(result.Count < 3)
        {
            SkillBuff randomBuff = m_Buffs[Random.Range(0, m_Buffs.Count)];

            if(!result.Contains(randomBuff))
            {
                result.Add(randomBuff);
            }
        }

        return result.ToArray();
    }

    private int GetIndex(Skill skill) => m_Skill.FindIndex(x => x.Equals(skill));

    public void Casting()
    {
        m_Skill.ForEach(skill =>
        {
            if (skill.Casting())
            {
                ComMonster comMonster = FindMonsters(skill.SkillRange);

                if (comMonster != null)
                {
                    int idx = GetIndex(skill);
                    ComSkill comSkill = m_ComSkill[idx].Get();
                    comSkill.transform.position = m_Player.transform.position;
                    comSkill.gameObject.SetActive(true);
                    comSkill.SetUp(comMonster);
                }
            }
        });
    }

    private ComMonster FindMonsters(float skillRange)
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(m_Player.transform.position, skillRange);

        if (results.Length > 0)
        {
            float closeDistance = float.MaxValue;
            ComMonster closestMonster = null;

            foreach (var result in results)
            {
                float distance = Vector3.Distance(result.transform.position, m_Player.transform.position);

                if (distance < closeDistance && result.CompareTag("Monster"))
                {
                    closeDistance = distance;
                    closestMonster = result.GetComponent<ComMonster>();
                }
            }

            return closestMonster;
        }

        return null;
    }

    public void Return(ComSkill comSkill)
    {
        comSkill.gameObject.SetActive(false);
        int idx = GetIndex(comSkill.m_Skill);
        m_ComSkill[idx].Return(comSkill);
    }
}
