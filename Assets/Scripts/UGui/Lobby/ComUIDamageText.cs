using System;
using UnityEngine;
using Witch.UGui;
using Anchor.Unity.UGui.Dialog;
using Anchor.Core.Systems;

namespace Witch
{
    public struct DamageDialogData
    {
        private string m_Title;
        private int m_SODamageDataId;
        private Vector3 m_Pivot;

        public string Title => m_Title;
        public int SODamageDataId => m_SODamageDataId;
        public Vector3 Pivot => m_Pivot;

        public DamageDialogData(string title, int id, UnityEngine.Vector3 pivot)
        {
            m_Title = title;
            m_SODamageDataId = id;
            m_Pivot = pivot;
        }
    }

    public class ComUIDamageText : ComDialog
    {
        private TMPro.TextMeshProUGUI m_UGui;

        [SerializeField] float m_Speed;
        [SerializeField] SODamageData m_SODamageData;

        private DamageDialogData m_Value;

        private void Update()
        {
            transform.position += Vector3.up * m_Speed;
        }

        protected override void OnOpen()
        {
            m_UGui.text = m_Value.Title;
            m_UGui.fontStyle = m_SODamageData.DamageDatas[m_Value.SODamageDataId].FontStyle;
            m_UGui.fontSize = m_SODamageData.DamageDatas[m_Value.SODamageDataId].FontSize;
            m_UGui.color = m_SODamageData.DamageDatas[m_Value.SODamageDataId].Color;

            transform.position = Camera.main.WorldToScreenPoint(m_Value.Pivot);
        }

        protected override void OnClose()
        {
        }

        protected override void OnInit()
        {
            m_UGui = GetComponent<TMPro.TextMeshProUGUI>();
        }

        protected override void OnSetData(EventArgs args)
        {
            Args<DamageDialogData> value = args as Args<DamageDialogData>;
            m_Value = value.Arg1;
        }

        protected override void OnSetBtnText(string[] text)
        {
        }
    }
}