using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public class ComFireball : ComSkill
    {
        public override void SetUp(ComMonster target)
        {
            base.SetUp(target);
        }

        protected override void Move()
        {
            transform.Translate(m_Direaction * m_Skill.MoveSpeed * Time.deltaTime);
        }

        protected override void Hit()
        {
            foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, m_Skill.ExplosionRange))
            {
                collider.GetComponent<IAttackable>().Hit(m_OffenseParameter, m_Skill.Info.explosionDamage);
            }

            Return();
        }
    }
}