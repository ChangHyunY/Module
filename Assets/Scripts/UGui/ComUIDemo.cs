using UnityEngine;
using UnityEngine.AddressableAssets;
using Anchor.Unity;
using Anchor.Unity.UGui.Panel;

namespace Witch
{
    public enum DemoUIId
    {
        DamageText,
        CommonDialog,
    }

    public class ComUIDemo : ComPanel<ComUIDemo>
    {
        [SerializeField] AssetReference m_DamageTextRef;
        [SerializeField] Transform m_RootDamageText;

        [SerializeField] Transform m_CommonDialog;
        [SerializeField] Transform m_RootCommonDialog;

        protected override void OnInit()
        {
            CreateSubject();
        }

        protected override void OnClose()
        {
        }

        protected override void OnOpen()
        {
        }

        protected override void OnSetData(System.EventArgs args)
        {
        }

        protected override void OnSetBtnText(string[] text)
        {
        }

        private void CreateSubject()
        {
            for (int i = 0, loop = 16; i < loop; ++i)
            {
                var go = ResourceHelper.GameObjectBags[(int)GameObjectBagId.Normal].Get<ComUIDamageText>(m_DamageTextRef);
                go.transform.SetParent(m_RootDamageText);
            }
        }

        // Button Event
        public void OnEventAttack()
        {
            DialogCaller.OnDamageText(
                    DialogId.DamageText,
                    $"{Random.Range(10, 500)}",
                    Random.Range(0, System.Enum.GetValues(typeof(DamageId)).Length),
                    ComSpawner.Root.GetRandomObjectPosition()
                    );
        }

        // Button Event
        public void OnEventCommonDialog()
        {
            DialogCaller.OnCommonDialog(DialogId.CommonDialog, "CommonDialog");
        }
    }
}