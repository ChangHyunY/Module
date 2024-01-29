using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Defense/StageData", order = int.MaxValue)]
public class SOStageData : ScriptableObject
{
    // 어떤 종류의 몬스터가 등장할지 (최대 보스포함 4종류의 몬스터)
    // 한 라운드에 어떤 종류의 몬스터가 얼마나 등장할지 어떤 간격으로 등장할 지
    // 한 라운드의 몬스터가 모드 등장한 후 5초 뒤에 다름 라운드 진행
    // 매 10스테이지의 마지막 라운드에는 보스가 등장

    public List<StageData> stageDatas;

    public Dictionary<int, int> monsters;
}

[System.Serializable]
public class StageData
{
    public int index;                       // 스테이지 번호
    public int[] monsterId;                 // 스테이지에 등장할 몬스터 번호
    public int[] numberOfZeroMonster;
    public int[] numberOfFirstMonster;
    public int[] numberOfSecondMonster;
    public int[] numberOfThirdMonster;

    public Dictionary<int, int[]> monsters;

    public void SetUp()
    {
        monsters = new Dictionary<int, int[]>
        {
            { 0, numberOfZeroMonster    },
            { 1, numberOfFirstMonster   },
            { 2, numberOfSecondMonster  },
            { 3, numberOfThirdMonster   }
        };
    }

    public float GetDelay(int round)
    {
        int count = 0;
        for(int i = 0; i < monsterId.Length; ++i)
        {
            count += monsters[i][round];
        }

        return 1.0f / count;
    }

    public int GetAllMonstersCount(int length)
    {
        int result = 0;

        foreach(int[] monster in monsters.Values)
        {
            for(int i = 0; i < length; ++i)
            {
                result += monster[i];
            }
        }

        return result;
    }
}