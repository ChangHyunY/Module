using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    public class ComPlayer : ComBaseActor
    {
        ComPlayerController m_ComPlayerController;
        public ComPlayerController ComPlayerController
        {
            get => m_ComPlayerController;
        }

        public override void Init()
        {
            m_BaseActor = new Player(this);
            m_BaseActor.Animator = GetComponent<Animator>();
            m_BaseActor.Controller = GetComponent<CharacterController>();
            m_BaseActor.StatusAgent = new StatusAgent(m_SOStatusData);
            m_BaseActor.Setup();

            m_ComPlayerController = GetComponent<ComPlayerController>();
            m_ComPlayerController.Setup(m_BaseActor as Player);

            // TODO : think wru using this code
            Camera.main.GetComponent<Anchor.Unity.Cameras.ComQViewCamera>().Setup(transform);
        }
    }
}