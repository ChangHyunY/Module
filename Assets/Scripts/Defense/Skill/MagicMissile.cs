using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : Defense.Skill
{
    public MagicMissile()
    {
        m_SkillInfo = ComDefense.Root.soSkillData.skillDatas.Find(x => x.id.Equals(SkillId.MagicMissile));
    }

    protected override string GetSkillName()
    {
        return "MagicMissile";
    }
}
