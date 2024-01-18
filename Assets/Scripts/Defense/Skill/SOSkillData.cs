using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Defense/SkillData", order = int.MaxValue)]
public class SOSkillData : ScriptableObject
{
    public List<SkillInfo> skillDatas;
}

[System.Serializable]
public class SkillInfo
{
    public SkillId id;
    public SkillType type;
    public string title;

    public float cooldown;
    public float skillRange;
    public float moveSpeed;

    public float defaultDamage;
    public int penetrate;
    public int castCount;

    public float explosionRange;
    public float explosionDamage;

    public SkillBuffId[] buffChains;
}