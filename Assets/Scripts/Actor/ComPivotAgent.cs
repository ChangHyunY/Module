using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    public enum PivotType
    {
        UI,
        Effect,
    }

    [System.Serializable]
    public class PivotInfo
    {
        [SerializeField] PivotType m_PivotType;
        [SerializeField] Transform m_Pivot;
        [SerializeField] Vector3 m_PositionOffset = Vector3.zero;
        [SerializeField] Vector3 m_RotationOffset = Vector3.zero;
        [SerializeField] Vector3 m_ScaleOffset = Vector3.one;

        public PivotType PivotType => m_PivotType;
        public Transform Pivot => m_Pivot;
        public Vector3 PositionOffset => m_PositionOffset;
        public Vector3 RotationOffset => m_RotationOffset;
        public Vector3 ScaleOffset => m_ScaleOffset;
    }

    public class ComPivotAgent : MonoBehaviour
    {
        [SerializeField] List<PivotInfo> m_PivotInfos;

        public List<PivotInfo> PivotInfos => m_PivotInfos;

        public PivotInfo GetPivot(PivotType pivotType)
        {
            PivotInfo result = m_PivotInfos.Find(element => element.PivotType == pivotType);

            if(result == null)
            {
                throw new System.Exception();
            }

            return result;
        }
    }
}