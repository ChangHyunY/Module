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

        [SerializeField] float m_Gravity = 9.8f;
        [SerializeField] float m_VerticalSpeed = 0.0f;


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
            ApplyGravity();
            m_BaseActor.Updated();
        }

        private void ApplyGravity()
        {
            if (BaseActor.Controller == null) return;

            if(BaseActor.Controller.isGrounded)
            {
                m_VerticalSpeed = -m_Gravity * Time.deltaTime;
            }
            else
            {
                m_VerticalSpeed -= m_Gravity * Time.deltaTime;
            }

            Vector3 moveDirection = new Vector3(0, m_VerticalSpeed, 0);
            BaseActor.Controller.Move(moveDirection * Time.deltaTime);
        }
    }
}