using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Witch.UGui
{
    [System.Serializable]
    public class DamageData
    {
        [SerializeField] DamageId m_DamageId;
        [SerializeField] TMPro.FontStyles m_FontStyle;
        [SerializeField] float m_FontSize;
        [SerializeField] Color m_Color;

        public DamageId DamageId => m_DamageId;
        public TMPro.FontStyles FontStyle => m_FontStyle;
        public float FontSize => m_FontSize;
        public Color Color => m_Color;
    }

    [CreateAssetMenu(fileName = "SODamageDatas", menuName = "SODatas/SODamageDatas", order = int.MaxValue)]
    public class SODamageData : ScriptableObject
    {
        [SerializeField] List<DamageData> m_DamageDatas;

        public List<DamageData> DamageDatas => m_DamageDatas;
    }
}