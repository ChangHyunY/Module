using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Defense.Skill
{
    public Fireball()
    {
        m_SkillInfo = ComDefense.Root.soSkillData.skillDatas.Find(x => x.id.Equals(SkillId.Fireball));
    }

    protected override string GetSkillName()
    {
        return "Fireball";
    }
}
