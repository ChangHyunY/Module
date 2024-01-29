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

    public int index;           // ������ ���� ��ȣ
    public int type;            // ������ Ÿ��
    public string name;         // ������ �̸�
    public string content;      // ������ ����

    public float hp;            // ������ ä��
    public float atk;           // ������ ���ݷ�
    public float def;           // ������ ����
    public float luk;           // ������ ȸ��Ȯ��
    public float timeToArrive;  // ������ �̵��ӵ�
    public float exp;           // ���Ͱ� �ִ� ����ġ�� ��

    public float fire;          // ���Ͱ� �޴� �߰� ȭ�� ������
    public float ice;           // ���Ͱ� �޴� �߰� ���� ������
    public float lightning;     // ���Ͱ� �޴� �߰� ���� ������
    public float physical;      // ���Ͱ� �޴� �߰� ���� ������
}
