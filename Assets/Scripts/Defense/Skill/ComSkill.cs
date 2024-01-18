using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public abstract class ComSkill : MonoBehaviour
    {
        public Skill m_Skill = null;

        public ComMonster m_Target;
        public Vector3 m_Direaction = Vector3.zero;

        public virtual void SetUp(ComMonster target)
        {
            m_Target = target;
            m_Direaction = (target.transform.position - transform.position).normalized;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch(collision.tag)
            {
                case "Monster":
                    Hit(collision.GetComponent<ComMonster>());
                    break;

                default:
                    break;
            }
        }

        protected abstract void Move();

        protected abstract void Hit();

        protected virtual void Hit(ComMonster comMonster)
        {
            comMonster.Hit(m_Skill.Info.defaultDamage);

            Hit();
        }

        protected void Return()
        {
            ComDefensePlayer.Root.SkillAgent.Return(this);
        }
    }
}