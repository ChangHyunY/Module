namespace Anchor.Unity.UGui.Panel
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class ComPanel<T> : ComUGui, IPanel where T : ComPanel<T>
    {
        private static T s_Root;

        public static T Root => s_Root;

        [SerializeField] PanelId m_Id;
        [SerializeField] private bool m_Navigated = false;

        public bool Navigated => m_Navigated;

        protected override void Awake()
        {
            m_Canvas = GetComponent<Canvas>();
            DialogManager.Add(UGuiId.Panel, this);
            s_Root = this as T;
            OnInit();
        }

        protected override void OnDestroy()
        {
            DialogManager.Remove(this);
        }

        public override int GetID()
        {
            return (int)m_Id;
        }

        public void Open()
        {
            if (m_Opened) return;

            m_Opened = true;

            m_Canvas.enabled = true;

            if (m_SiblingOnOpen == Sibling.First)
            {
                gameObject.transform.SetAsFirstSibling();
            }
            if (m_SiblingOnOpen == Sibling.Last)
            {
                gameObject.transform.SetAsLastSibling();
            }

            if (!m_OpenCalled)
            {
                m_OpenCalled = true;
                OnInit();
            }

            OnOpen();
        }

        public void Close()
        {
            OnClose();

            m_Opened = false;

            m_Canvas.enabled = false;
        }
    }
}