using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComDefenseSpawner : MonoBehaviour
{
    private static ComDefenseSpawner s_Root;
    public static ComDefenseSpawner Root => s_Root;

    public StageData m_StageData;

    public Transform m_SpawnRoot;
    public Transform m_SpawnPivot;
    public Transform[] m_SpawnXRange;

    private int m_RoundIndex = 0;
    private float m_RespawnDelay = 5.0f;

    private const float m_InitalGenerateCount = 16;

    public Transform m_TargetPivot;

    private Dictionary<int, FixedPool<ComMonster>> m_Monsters;

    private void Awake()
    {
        s_Root = this;
    }

    private void Start()
    {
        m_StageData = ComDefense.Root.soStageData.stageDatas[0];
        m_StageData.SetUp();

        int length = m_StageData.monsterId.Length;
        m_Monsters = new Dictionary<int, FixedPool<ComMonster>>(length);

        for (int i = 0; i < length; ++i)
        {
            int index = m_StageData.monsterId[i];
            GameObject prefab = ComDefense.Root.soMonsterData.monsterDatas[index].prefab;
            m_Monsters.Add(i, new FixedPool<ComMonster>(
                component: prefab.GetComponent<ComMonster>()
                ));

            for (int j = 0; j < m_InitalGenerateCount; ++j)
            {
                var obj = GameObject.Instantiate(prefab, m_SpawnRoot);
                obj.SetActive(false);

                m_Monsters[i].Add(obj.GetComponent<ComMonster>());
            }
        }
    }

    public IEnumerator Spawn()
    {
        m_RoundIndex = 0;
        for (int i = 0; i < 20; ++i)
        {
            int idx = 0;
            float delay = m_StageData.GetDelay(m_RoundIndex);
            int[] counts = new int[m_StageData.monsters.Count];
            Debug.Log($"{m_RoundIndex + 1} Round Start | Delay : {delay}");

            while (true)
            {
                if (idx > m_StageData.monsterId.Length)
                {
                    break;
                }

                if (counts[idx] >= m_StageData.monsters[idx][m_RoundIndex])
                {
                    ++idx;
                    continue;
                }

                var monster = m_Monsters[idx].Get();

                if (monster == null)
                {
                    GameObject prefab = ComDefense.Root.soMonsterData.monsterDatas[m_StageData.monsterId[idx]].prefab;
                    monster = GameObject.Instantiate(prefab, m_SpawnRoot).GetComponent<ComMonster>();
                }

                Vector3 position = m_SpawnPivot.position;
                position.x += Random.Range(m_SpawnXRange[0].position.x, m_SpawnXRange[1].position.x);
                monster.transform.position = position;
                monster.gameObject.SetActive(true);
                monster.SetUp(idx, m_TargetPivot, ComDefense.Root.soMonsterData.monsterDatas[(int)monster.m_MonsterId]);

                ++counts[idx];

                yield return new WaitForSeconds(delay);
            }

            ++m_RoundIndex;
            yield return new WaitForSeconds(m_RespawnDelay);
        }        
    }

    public void Return(ComMonster comMonster)
    {
        comMonster.gameObject.SetActive(false);
        m_Monsters[comMonster.m_Index].Return(comMonster);
    }
}
