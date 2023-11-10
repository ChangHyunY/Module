using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.Actor.PlayerStates;

namespace Anchor.Unity.Actor
{
    public enum PlayerState { Idle, Walk, Run, Attack, Defend, Die, DieRecover, Dizzy, GetHit }

    public class Player : BaseActor
    {
        private ComPlayer m_ComPlayer;
        private State<Player>[] m_States;
        private StateMachine<Player> m_StateMachine;

        public ComPlayer ComPlayer
        {
            get => m_ComPlayer;
        }

        public StateMachine<Player> StateMachine
        {
            get => m_StateMachine;
        }

        public Player(ComPlayer actor)
        {
            m_ComPlayer = actor;
        }

        public override void Setup()
        {
            base.Setup();

            m_States = new State<Player>[System.Enum.GetValues(typeof(PlayerState)).Length];
            m_States[(int)PlayerState.Idle] = new Idle();
            m_States[(int)PlayerState.Walk] = new Walk();
            m_States[(int)PlayerState.Run] = new Run();
            m_States[(int)PlayerState.Attack] = new Attack();

            m_StateMachine = new StateMachine<Player>();
            m_StateMachine.Setup(this, m_States[(int)PlayerState.Idle]);
        }

        public override void Updated()
        {
            m_StateMachine.Excute();
        }

        public void ChangeState(PlayerState newState)
        {
            m_StateMachine.ChangeState(m_States[(int)newState]);
        }
    }
}