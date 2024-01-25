using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public class ComIcebolt : ComSkill
    {
        [SerializeField] SpriteRenderer sr;
        private int penetrate;

        public override void SetUp(ComMonster target)
        {
            base.SetUp(target);

            penetrate = m_Skill.Info.penetrate;

            LookTarget(sr.transform, Vector3.forward, 90f);
        }

        protected override void Move()
        {
            transform.Translate(m_Direaction * m_Skill.MoveSpeed * Time.deltaTime);
        }

        protected override void Hit()
        {
            if(--penetrate <= 0)
            {
                Return();
            }
        }
    }
}