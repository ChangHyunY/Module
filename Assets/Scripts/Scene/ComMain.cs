using UnityEngine;
using UnityEngine.InputSystem;
using Anchor.Unity;

namespace Anchor
{
    public class ComMain : MonoBehaviour
    {
        private static ComMain s_Root = null;
        public static ComMain Root => s_Root;

        [SerializeField] UnityEngine.EventSystems.EventSystem s_EventSystem;

        private void Awake()
        {
            s_Root = this;

            DontDestroyOnLoad(this);
            DontDestroyOnLoad(s_EventSystem);

            ProjectSetting.Initalize();
        }

        private void Start()
        {
            ResourceHelper.LoadScene(SceneId.Start, Define.LoginAssets);
        }

        private void Update()
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                DialogManager.CloseFromNavigation();
            }
        }

        public void DebugMessage(string msg)
        {
            Debug.Log(msg);
        }
    }
}