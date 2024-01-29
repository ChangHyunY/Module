using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public abstract class ComSkill : MonoBehaviour
    {
        public Skill m_Skill = null;

        protected ComMonster m_Target;
        protected Vector3 m_Direaction = Vector3.zero;

        protected OffenseParameter<ComSkill> m_OffenseParameter;

        public virtual void SetUp(ComMonster target)
        {
            m_OffenseParameter = new OffenseParameter<ComSkill>()
            {
                component = this,
                offenseType = OffenseType.Skill,
                hitCallback = Hit,
                returnCallback = Return,
            };

            m_Target = target;
            m_Direaction = (target.transform.position - transform.position).normalized;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<IAttackable>()?.Hit(m_OffenseParameter, m_Skill.Info.defaultDamage);
        }

        protected void LookTarget(Transform transform, Vector3 dir, float angle)
        {
            transform.rotation = Quaternion.LookRotation(dir, m_Direaction);
            transform.rotation *= Quaternion.AngleAxis(angle, dir);
        }

        protected abstract void Move();

        protected abstract void Hit();

        protected void Return()
        {
            ComDefensePlayer.Root.SkillAgent.Return(this);
        }
    }
}