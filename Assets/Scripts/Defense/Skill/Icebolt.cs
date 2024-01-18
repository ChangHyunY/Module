using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icebolt : Defense.Skill
{
    public Icebolt()
    {
        m_SkillInfo = ComDefense.Root.soSkillData.skillDatas.Find(x => x.id.Equals(SkillId.Icebolt));
    }

    protected override string GetSkillName()
    {
        return "Icebolt";
    }
}
