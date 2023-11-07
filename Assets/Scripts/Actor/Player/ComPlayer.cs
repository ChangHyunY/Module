using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anchor.Unity.Actor
{
    public class ComPlayer : ComBaseActor
    {
        public override void Init()
        {
            m_BaseActor = new Player();
            m_BaseActor.Setup();

            m_BaseActor.Animator = GetComponent<Animator>();
            m_BaseActor.StatusAgent = new StatusAgent(m_SOStatusData);
        }
    }
}