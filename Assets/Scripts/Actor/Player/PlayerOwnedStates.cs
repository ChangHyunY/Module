using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor.PlayerStates
{
    public class Idle : State<Player>
    {
        public override void Enter(Player actor)
        {
            Debug.Log("Idle Enter");

            actor.Animator.Play(PlayerState.Idle.ToString());
        }

        public override void Excute(Player actor)
        {
        }

        public override void Exit(Player actor)
        {
            Debug.Log("Idle Exit");
        }
    }

    public class Walk : State<Player>
    {
        public override void Enter(Player actor)
        {
            actor.Animator.Play(PlayerState.Walk.ToString());
        }

        public override void Excute(Player actor)
        {
            actor.ComPlayer.ComPlayerController.LookAtDirection();
            actor.ComPlayer.ComPlayerController.Move();
        }

        public override void Exit(Player actor)
        {
        }
    }

    public class Run : State<Player>
    {
        public override void Enter(Player actor)
        {
            actor.Animator.Play(PlayerState.Run.ToString());
        }

        public override void Excute(Player actor)
        {
        }

        public override void Exit(Player actor)
        {
        }
    }

    public class Attack : State<Player>
    {
        enum AttackType { Attack01, Attack02 }

        private int m_MaxIdx;
        private short m_Idx;
        private AttackType m_AttackType;

        public Attack()
        {
            m_MaxIdx = System.Enum.GetValues(typeof(AttackType)).Length;
            m_Idx = 0;
            m_AttackType = AttackType.Attack01;
        }

        public override void Enter(Player actor)
        {
            Debug.Log("Attack Enter");

            actor.Animator.Play(m_AttackType.ToString());
            
            if(++m_Idx >m_MaxIdx - 1)
            {
                m_Idx = 0;
            }

            m_AttackType = (AttackType)m_Idx;
        }

        public override void Excute(Player actor)
        {
            Debug.Log($"Attack Excute ");
            if(actor.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                //actor.StateMachine.RevertToPreviousState();
                actor.StateMachine.ChangeState(actor.States[(int)PlayerState.Idle]);
            }
        }

        public override void Exit(Player actor)
        {
            Debug.Log("Attack Exit");
        }
    }
}