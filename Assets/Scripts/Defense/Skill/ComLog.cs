using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public class ComLog : ComSkill
    {
        public override void SetUp(ComMonster target)
        {
            base.SetUp(target);
        }

        protected override void Hit()
        {
            
        }

        protected override void Move()
        {
            transform.Translate(m_Skill.MoveSpeed * Time.deltaTime * Vector3.up);
        }
    }
}