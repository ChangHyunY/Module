using System;
using Anchor.Core.Systems;
using Anchor.Unity.UGui.Dialog;

namespace Witch
{
    public struct CommonDialogData
    {
        private string m_Title;

        public string Title => m_Title;

        public CommonDialogData(string title)
        {
            m_Title = title;
        }
    }

    public class ComUICommonDialog : ComDialog
    {
        private TMPro.TextMeshProUGUI m_UGui;

        private CommonDialogData m_Value;

        protected override void OnInit()
        {
            m_UGui = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }

        protected override void OnOpen()
        {
            m_UGui.text = m_Value.Title;
        }

        protected override void OnClose()
        {
        }

        protected override void OnSetBtnText(string[] text)
        {
        }

        protected override void OnSetData(EventArgs args)
        {
            Args<CommonDialogData> value = args as Args<CommonDialogData>;
            m_Value = value.Arg1;
        }
    }
}