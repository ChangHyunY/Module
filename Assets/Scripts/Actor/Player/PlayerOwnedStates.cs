using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor.PlayerStates
{
    public class Idle : State<Player>
    {
        public override void Enter(Player actor)
        {
            actor.Animator.Play(PlayerState.Idle.ToString());
        }

        public override void Excute(Player actor)
        {
        }

        public override void Exit(Player actor)
        {
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

        public override void Enter(Player actor)
        {
            actor.Animator.Play(PlayerState.Attack.ToString());
        }

        public override void Excute(Player actor)
        {
            if(actor.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                actor.StateMachine.ReverToPreviousState();
            }
        }

        public override void Exit(Player actor)
        {
        }
    }
}