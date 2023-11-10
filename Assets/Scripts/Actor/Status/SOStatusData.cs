using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    [System.Serializable]
    public class StatusData
    {
        [SerializeField] List<StatusId> m_Keys;
        [SerializeField] List<long> m_Values;

        public Dictionary<StatusId, long> SetUp()
        {
            Dictionary<StatusId, long> result = new Dictionary<StatusId, long>();

            if(m_Keys.Count != m_Values.Count)
            {
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
            }

            for(int i = 0, loop = m_Keys.Count; i < loop; ++i)
            {
                result.Add(m_Keys[i], m_Values[i]);
                Debug.Log($"{m_Keys[i]}, {m_Values[i]}");
            }

            return result;
        }
    }

    [CreateAssetMenu(fileName = "SoStatusDatas", menuName = "SODatas/SOStatusDatas", order = int.MaxValue)]
    public class SOStatusData : ScriptableObject
    {
        [SerializeField] StatusData m_StatusData;

        public StatusData StatusData => m_StatusData;
    }
}