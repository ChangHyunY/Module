using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Anchor.Unity.Actor
{
    public class ComPlayerController : MonoBehaviour
    {
        private Player m_Player;

        private Vector3 m_Direction;

        [SerializeField] float m_MoveSpeed;

        public float MoveSpeed
        {
            get => m_MoveSpeed;
            set => m_MoveSpeed = value;
        }

        public void Setup(Player player)
        {
            m_Player = player;
        }

        // InputSystem Send Message
        private void OnMove(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();

            if(input.magnitude > 0)
            {
                m_Direction = new Vector3(input.x, 0f, input.y);
                m_Player.ChangeState(PlayerState.Walk);
            }
            else
            {
                m_Player.ChangeState(PlayerState.Idle);
            }
        }

        public void Move()
        {
            m_Player.ComPlayer.BaseActor.Controller.Move(m_Direction * m_MoveSpeed * Time.deltaTime);
        }

        public void LookAtDirection()
        {
            m_Player.ComPlayer.transform.rotation = Quaternion.LookRotation(m_Direction, Vector3.up);
        }
    }
}