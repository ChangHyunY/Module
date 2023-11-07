using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    [RequireComponent(typeof(ComPivotAgent))]
    public abstract class ComBaseActor : MonoBehaviour
    {
        protected BaseActor m_BaseActor;

        public BaseActor BaseActor
        {
            get => m_BaseActor;
        }

        protected ComPivotAgent m_PivotAgent;

        public ComPivotAgent PivotAgent => m_PivotAgent;

        [SerializeField] protected SOStatusData m_SOStatusData;

        protected virtual void Awake() 
        {
            m_PivotAgent = GetComponent<ComPivotAgent>();
        }

        protected virtual void Start() 
        {
            Init();
        }

        public abstract void Init();

        private void Update()
        {
            m_BaseActor.Updated();
        }
    }
}