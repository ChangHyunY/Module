using UnityEngine;
using UnityEngine.InputSystem;
using Anchor.Unity.UGui;

namespace Anchor
{
    public class ComMain : MonoBehaviour
    {
        public static ComMain Root;

        [SerializeField] UnityEngine.EventSystems.EventSystem s_EventSystem;

        private void Awake()
        {
            Root = this;

            DontDestroyOnLoad(this);
            DontDestroyOnLoad(s_EventSystem);

            ProjectSetting.Initalize();
        }

        private void Start()
        {
            ResourceHelper.LoadScene(SceneId.Login);
        }

        private void Update()
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                DialogManager.CloseFromNavigation();
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Anchor.Unity.Sound.SoundManager.Play(SoundId.eft_ui_click_blop, SoundType.EFT);
            }
        }

        public void DebugMessage(string msg)
        {
            Debug.Log(msg);
        }
    }
}