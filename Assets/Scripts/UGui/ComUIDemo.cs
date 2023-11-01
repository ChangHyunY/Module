using System.Collections;
using System.Collections.Generic;
using Anchor.Unity.UGui;
using Anchor.Core.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Anchor.Unity;

namespace Witch
{
    public enum DemoUIId
    {
        DamageText,
        CommonDialog,
    }

    public class ComUIDemo : MonoBehaviour
    {
        private static ComUIDemo m_Root;
        public static ComUIDemo Root => m_Root;


        [SerializeField] AssetReference m_DamageTextRef;
        [SerializeField] Transform m_RootDamageText;

        [SerializeField] Transform m_CommonDialog;
        [SerializeField] Transform m_RootCommonDialog;
        
        

        private void Awake()
        {
            m_Root = this;

            Initialize();
        }

        private void Initialize()
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
                    ComSpawner.Root.GetRandomObjectPosition
                    );
        }

        // Button Event
        public void OnEventCommonDialog()
        {

        }
    }
}