using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.Actor.MonsterStates;

namespace Anchor.Unity.Actor
{
    public enum MonsterState
    {
        Idle,
        Move,
        Attack,
        Skill,
    }

    public class Monster : BaseActor
    {
        private State<Monster>[] m_States;
        private StateMachine<Monster> m_StateMachine;

        public StateMachine<Monster> StateMachine
        {
            get => m_StateMachine;
        }

        public override void Setup()
        {
            base.Setup();

            m_States = new State<Monster>[System.Enum.GetValues(typeof(MonsterState)).Length];
            m_States[(int)MonsterState.Idle] = new Idle();
            m_States[(int)MonsterState.Move] = new Move();
            m_States[(int)MonsterState.Attack] = new Attack();
            m_States[(int)MonsterState.Skill] = new Skill();

            m_StateMachine = new StateMachine<Monster>();
            m_StateMachine.Setup(this, m_States[(int)MonsterState.Idle]);
        }

        public override void Updated()
        {
            m_StateMachine.Excute();
        }

        public void ChangeState(MonsterState newState)
        {
            m_StateMachine.ChangeState(m_States[(int)newState]);
        }
    }
}