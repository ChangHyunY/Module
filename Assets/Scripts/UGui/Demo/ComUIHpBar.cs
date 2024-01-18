using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Anchor.Unity.UGui.Dialog;

namespace Witch
{
    public class ComUIHpBar : ComDialog
    {
        private Transform m_Actor;

        [SerializeField] Image m_Hp;
        [SerializeField] TMPro.TextMeshProUGUI m_Value;

        protected override void OnInit()
        {
        }

        protected override void OnClose()
        {
        }

        protected override void OnOpen()
        {
        }

        protected override void OnSetBtnText(string[] text)
        {
        }

        protected override void OnSetData(EventArgs args)
        {
        }
    }
}