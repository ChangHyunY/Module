using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    public enum StatusId
    {
        Hp,
        Mp,
        Atk,
        Def,
        Exp,
    }

    public class StatusAgent
    {
        private Dictionary<StatusId, long> m_Status;

        public Dictionary<StatusId, long> Status => m_Status;

        public StatusAgent(SOStatusData soStatusData)
        {
            m_Status = soStatusData.StatusData.SetUp();
        }

        public long Get(StatusId id)
        {
            return m_Status[id];
        }
    }
}