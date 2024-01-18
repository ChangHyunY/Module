using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillBuff", menuName = "Defense/SkillBuff", order = int.MaxValue)]
public class SOSkillBuff : ScriptableObject
{
    public SkillId id;
    public List<SkillBuff> skillBuffs;
}

[System.Serializable]
public class SkillBuff
{
    public SkillId id;
    public SkillBuffId buffId;
    public string title;
    public string content;
    public Sprite icon;
    public int count;

    public SkillStatusType[] skillStatusType;
    public float[] buffValue;

    public SkillBuffId[] buffChains;
}