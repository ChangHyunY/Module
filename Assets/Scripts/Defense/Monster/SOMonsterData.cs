using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Defense/MonsterData", order = int.MaxValue)]
public class SOMonsterData : ScriptableObject
{
    public List<MonsterData> monsterDatas;
}

[System.Serializable]
public class MonsterData
{
    public GameObject prefab;

    public int index;           // 몬스터의 고유 번호
    public int type;            // 몬스터의 타입
    public string name;         // 몬스터의 이름
    public string content;      // 몬스터의 설명

    public float hp;            // 몬스터의 채력
    public float atk;           // 몬스터의 공격력
    public float def;           // 몬스터의 방어력
    public float luk;           // 몬스터의 회피확률
    public float timeToArrive;  // 몬스터의 이동속도
    public float exp;           // 몬스터가 주는 경험치의 양

    public float fire;          // 몬스터가 받는 추가 화염 데미지
    public float ice;           // 몬스터가 받는 추가 얼음 데미지
    public float lightning;     // 몬스터가 받는 추가 번개 데미지
    public float physical;      // 몬스터가 받는 추가 물리 데미지
}
