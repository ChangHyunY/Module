using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.UGui;
using Anchor.Unity.Sound;

namespace Anchor
{
    public class ProjectSetting
    {
        public static void Initalize()
        {
            Application.targetFrameRate = 60;

            ResourceHelper.Initalize();
            DialogManager.Initialize();
            SoundManager.Initalize();
        }
    }
}