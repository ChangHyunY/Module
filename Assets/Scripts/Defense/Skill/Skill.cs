using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense
{
    public abstract class Skill
    {
        protected SkillInfo m_SkillInfo;
        private float m_CurrentCooldown;

        public SkillInfo Info
        {
            get => m_SkillInfo;
        }

        public float SkillRange
        {
            get => m_SkillInfo.skillRange;
        }

        public float MoveSpeed
        {
            get => m_SkillInfo.moveSpeed;
        }

        public float ExplosionRange
        {
            get => m_SkillInfo.explosionRange;
        }

        public virtual bool Casting()
        {
            bool result = false;

            if (!IsCooldown())
            {
                m_CurrentCooldown = Time.time;
                result = true;
            }

            return result;
        }

        public bool IsCooldown()
        {
            return Time.time - m_CurrentCooldown < m_SkillInfo.cooldown;
        }

        protected abstract string GetSkillName();
    }
}