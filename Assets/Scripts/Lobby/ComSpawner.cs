using Anchor.Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.Actor;

namespace Witch
{
    public class ComSpawner : MonoBehaviour
    {
        private static ComSpawner m_Root;

        public static ComSpawner Root => m_Root;

        private float m_Angle = 360f;
        [SerializeField] float m_Radius;
        [SerializeField] short m_Count;
        [SerializeField] Transform m_Prefab;

        private List<ComCube> m_Pool;

        private void Awake()
        {
            m_Root = this;

            m_Pool = new List<ComCube>();
        }

        private void Start()
        {
            List<Vector3> points = CalculatePointsOnCircle();
            for (short i = 0; i < m_Count; ++i)
            {
                Transform go = Instantiate(m_Prefab, points[i], Quaternion.identity, this.transform);
                m_Pool.Add(go.GetComponent<ComCube>());
            }
        }

        private List<Vector3> CalculatePointsOnCircle()
        {
            float angleIncrement = m_Angle / m_Count;
            List<Vector3> points = new List<Vector3>();

            for (int i = 0; i < m_Count; ++i)
            {
                float angleDegrees = i * angleIncrement;
                float angleRadians = Mathf.PI * angleDegrees / 180.0f;
                Vector3 point = new Vector3(m_Radius * Mathf.Cos(angleRadians), 0, m_Radius * Mathf.Sin(angleRadians));
                points.Add(point);
            }

            return points;
        }

        public Vector3 GetRandomObjectPosition()
        {
            return m_Pool [Random.Range(0, m_Pool.Count)].PivotAgent.GetPivot(PivotType.UI).Pivot.position;
        }
    }
}