using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Anchor.Unity.Cameras
{
    public class ComQViewCamera : MonoBehaviour
    {
        private Transform m_Actor;
        private bool m_InitCalled = false;

        [SerializeField] Vector3 m_DefaultViewPosition;
        [SerializeField] Vector3 m_DefaultViewRotation;

        [SerializeField] bool m_IsLookAt;

        public void Setup(Transform actor)
        {
            m_Actor = actor;
            m_InitCalled = true;
            transform.rotation = Quaternion.Euler(m_DefaultViewRotation);
        }

        private void Update()
        {
            if (!m_InitCalled) return;

            DefaultQViewCamera();

            transform.LookAt(m_Actor.position);
        }

        private void DefaultQViewCamera()
        {
            Vector3 position = m_Actor.position + m_DefaultViewPosition;
            position.y = transform.position.y;
            transform.position = position;
        }
    }
}