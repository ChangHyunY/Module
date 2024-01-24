using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.UGui.Panel;
using System;

public class ComUIMain : ComPanel<ComUIMain>
{
    [Space]
    public Transform m_ParentRoot;

    private Dictionary<int, Transform> m_ChildRoots;

    protected override void OnInit()
    {
        DontDestroyOnLoad(this);

        m_ChildRoots = new Dictionary<int, Transform>();
        int length = Enum.GetValues(typeof(DefaultAssetId)).Length;
        for(int i = 0; i < length; ++i)
        {
            var root = new GameObject(((DefaultAssetId)i).ToString());
            root.transform.SetParent(m_ParentRoot);
            m_ChildRoots.Add(i, root.transform);
        }

        for(int i = 0; i < 64; ++i)
        {
            var obj = Anchor.Unity.ResourceHelper.GameObjectBags[(int)GameObjectBagId.Normal].Get<RectTransform>(Define.DefaultAssets[(int)DefaultAssetId.DamageText]);
            obj.transform.SetParent(m_ChildRoots[(int)DefaultAssetId.DamageText]);
        }
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
