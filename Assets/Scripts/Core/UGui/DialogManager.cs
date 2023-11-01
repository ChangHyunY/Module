namespace Anchor.Unity
{
    using Anchor.Unity.UGui;
    using Anchor.Unity.UGui.Dialog;
    using Anchor.Unity.UGui.Panel;
    using Anchor.Core.Pool;
    using System.Collections.Generic;


    public static class DialogManager
    {
        private static bool s_InitCalled = false;

        private static Dictionary<UGuiId, List<UGuiInfo>> m_Values;
        private static Stack<IPanel> m_NavigateValues;

        private const int m_DefaultInitalCount = 8;
        private const int m_DefaultInitalCapacity = 16;
        private const int m_DefaultMaxPoolSize = 64;

        public static void Initialize()
        {
            if (s_InitCalled) return;

            s_InitCalled = true;

            m_Values = new Dictionary<UGuiId, List<UGuiInfo>>()
            {
                { UGuiId.Panel, new List<UGuiInfo>() },
                { UGuiId.Dialog, new List<UGuiInfo>() },
            };

            m_NavigateValues = new Stack<IPanel>();
        }

        public static void Add(UGuiId id, ComUGui uGui, int initCount = m_DefaultInitalCount, int initalCapacity = m_DefaultInitalCapacity, int maxPoolSize = m_DefaultMaxPoolSize)
        {
            if (!s_InitCalled) Initialize();

            if (!m_Values[id].Exists(element => element.Component.GetID() == uGui.GetID()))
            {
                if (uGui.ManageType == ManageType.Pool)
                {
                    uGui.gameObject.SetActive(false);

                    Pool<ComUGui> pool = new Pool<ComUGui>(uGui, initCount, initalCapacity, maxPoolSize);

                    m_Values[id].Add(new UGuiInfo(uGui, pool));
                }
                else
                {
                    uGui.gameObject.SetActive(uGui.AwakeOnOpen);

                    m_Values[id].Add(new UGuiInfo(uGui));
                }
            }
            else
            {
                if(uGui.ManageType == ManageType.Pool)
                {
                    uGui.gameObject.SetActive(false);

                    int idx = m_Values[id].FindIndex(element => element.Component.GetID() == uGui.GetID());

                    m_Values[id][idx].Pool.Add(uGui);
                }

                return;
            }
        }

        public static void Remove(ComUGui uGui)
        {
            uGui.gameObject.SetActive(false);

            var idx = m_Values[uGui.UGuiType].FindIndex(element => element.Component.GetID() == uGui.GetID());

            if (idx >= 0)
            {
                m_Values[uGui.UGuiType].RemoveAt(idx);
            }
        }

        public static void ReturnToPool(ComUGui uGui)
        {
            if (uGui.ManageType == ManageType.Pool)
            {
                var idx = m_Values[uGui.UGuiType].FindIndex(element => element.Component.GetID() == uGui.GetID());

                if(idx >= 0)
                {
                    m_Values[uGui.UGuiType][idx].Pool.Return(uGui);
                }
            }
            else
            {
                uGui.gameObject.SetActive(false);
            }
        }

        public static void Open<T>(ComPanel<T> panel) where T : ComPanel<T>
        {
            if(panel != null)
            {
                panel.Open();
            }

            if (panel.Navigated)
            {
                m_NavigateValues.Push(panel);
            }
        }

        public static void DisPlay(int id, System.EventArgs dataArgs, string[] btnText,
            System.Action<int, System.EventArgs> clickCallback = null, System.EventArgs callbackArgs = null)
        {
            var com = GetInternal(id);

            if (com != null)
            {
                com.SetData(dataArgs, btnText, clickCallback, callbackArgs);
                com.Open();
            }
        }

        private static ComDialog GetInternal(int id)
        {
            ComDialog com = null;

            var idx = m_Values[UGuiId.Dialog].FindIndex(element => element.Component.GetID() == id);

            if (idx >= 0)
            {
                if (m_Values[UGuiId.Dialog][idx].Pool != null)
                {
                    com = m_Values[UGuiId.Dialog][idx].Pool.Get().GetComponent<ComDialog>();
                }
                else
                {
                    com = m_Values[UGuiId.Dialog][idx].Component as ComDialog;

                    if (com.Opened)
                    {
                        com.Close();
                    }
                }
            }

            return com;
        }

        public static void CloseFromNavigation()
        {
            if (m_NavigateValues.Count <= 0) return;

            IPanel panel = m_NavigateValues.Pop();
            panel.Close();
        }
    }
}