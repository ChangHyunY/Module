using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComDefensePlayer : MonoBehaviour
{
    private static ComDefensePlayer s_Root;
    public static ComDefensePlayer Root => s_Root;

    public List<GameObject> m_SkillPrefabs = new List<GameObject>();
    public Transform m_SkillRoot;

    private SkillAgent m_SkillAgent;

    public SkillAgent SkillAgent => m_SkillAgent;

    private void Awake()
    {
        s_Root = this;
    }

    public void SetUp(SkillId id)
    {
        m_SkillAgent = new SkillAgent(this);

        switch(id)
        {
            case SkillId.MagicMissile:
                m_SkillAgent.Add(new MagicMissile(), m_SkillPrefabs[(int)id], m_SkillRoot);
                break;

            case SkillId.Fireball:
                m_SkillAgent.Add(new Fireball(), m_SkillPrefabs[(int)id], m_SkillRoot);
                break;

            case SkillId.Icebolt:
                m_SkillAgent.Add(new Icebolt(), m_SkillPrefabs[(int)id], m_SkillRoot);
                break;
        }
    }

    private void Update()
    {
        m_SkillAgent?.Casting();
    }
}
