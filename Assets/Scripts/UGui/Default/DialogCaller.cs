using Anchor.Core.Systems;
using Anchor.Unity;

namespace Witch
{
    // Default Format
    public struct DefaultCommonDialogData
    {
        private string m_Title;
        private string m_Content;

        public string Title => m_Title;
        public string Contnet => m_Content;

        public DefaultCommonDialogData(string title, string content)
        {
            m_Title = title;
            m_Content = content;
        }
    }

    public static class DialogCaller
    {
        public static void SampleCall()
        {
            OnDialog(DialogId.CommonDialog, "Title", "Content", (btnId, args) =>
            {
                switch (btnId)
                {
                    case 0:
                        Anchor.ComMain.Root.DebugMessage("First args function");
                        break;

                    case 1:
                        Anchor.ComMain.Root.DebugMessage("Second args function");
                        break;

                    case 2:
                        Anchor.ComMain.Root.DebugMessage("Third args function");
                        break;
                }
            });
        }

        public static void OnDialog(DialogId dialogId, string title, string content, System.Action<int, System.EventArgs> clickCallback = null)
        {
            var data = new Args<DefaultCommonDialogData>() { Arg1 = new DefaultCommonDialogData(title, content) };
            string[] btnText = { "1" };
            DialogManager.DisPlay((int)dialogId, data, btnText, clickCallback);
        }

        public static void OnCommonDialog(DialogId dialogId, string title)
        {
            var data = new Args<CommonDialogData>() { Arg1 = new CommonDialogData(title) };
            DialogManager.DisPlay((int)dialogId, data, null, null);
        }

        public static void OnDamageText(DialogId dialogId, string title, int id, UnityEngine.Vector3 pivot)
        {
            var data = new Args<DamageDialogData>() { Arg1 = new DamageDialogData(title, id, pivot) };
            DialogManager.DisPlay((int)dialogId, data, null, null);
        }
    }
}