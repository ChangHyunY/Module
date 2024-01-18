using UnityEngine;
using UnityEngine.AddressableAssets;
using Anchor.Unity;
using Anchor.Unity.UGui.Panel;
using System.Collections.Generic;

namespace Witch
{
    public enum DemoUIId
    {
        DamageText,
        HpBar,
    }

    public class ComUIDemo : ComPanel<ComUIDemo>
    {
        [SerializeField] List<AssetReference> m_AssetRefs;
        [SerializeField] List<Transform> m_DialogRoots;

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
                ComUIDamageText damageText = ResourceHelper.GameObjectBags[(int)GameObjectBagId.Normal].Get<ComUIDamageText>(m_AssetRefs[(int)DemoUIId.DamageText]);
                damageText.transform.SetParent(m_DialogRoots[(int)DemoUIId.DamageText]);
            }

            ComUIHpBar hpBar = ResourceHelper.GameObjectBags[(int)GameObjectBagId.Normal].Get<ComUIHpBar>(m_AssetRefs[(int)DemoUIId.HpBar]);
            hpBar.transform.SetParent(m_DialogRoots[(int)DemoUIId.HpBar]);
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