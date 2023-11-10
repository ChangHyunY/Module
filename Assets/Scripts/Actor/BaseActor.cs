using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    public abstract class BaseActor
    {
        private static int s_NextValidID = 0;

        private int m_ID;
        public int ID
        {
            set
            {
                m_ID = value;
                s_NextValidID++;
            }
            get => m_ID;
        }

        protected Animator m_Animator;
        public Animator Animator
        {
            get => m_Animator;
            set => m_Animator = value;
        }

        protected CharacterController m_CharacterController;
        public CharacterController Controller
        {
            get => m_CharacterController;
            set => m_CharacterController = value;
        }

        protected StatusAgent m_StatusAgent;
        public StatusAgent StatusAgent
        {
            get => m_StatusAgent;
            set => m_StatusAgent = value;
        }        

        public virtual void Setup()
        {
            ID = s_NextValidID;
        }

        public abstract void Updated();
    }
}