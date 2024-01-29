using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Defense/StageData", order = int.MaxValue)]
public class SOStageData : ScriptableObject
{
    // � ������ ���Ͱ� �������� (�ִ� �������� 4������ ����)
    // �� ���忡 � ������ ���Ͱ� �󸶳� �������� � �������� ������ ��
    // �� ������ ���Ͱ� ��� ������ �� 5�� �ڿ� �ٸ� ���� ����
    // �� 10���������� ������ ���忡�� ������ ����

    public List<StageData> stageDatas;

    public Dictionary<int, int> monsters;
}

[System.Serializable]
public class StageData
{
    public int index;                       // �������� ��ȣ
    public int[] monsterId;                 // ���������� ������ ���� ��ȣ
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