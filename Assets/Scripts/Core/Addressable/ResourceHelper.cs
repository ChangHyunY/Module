using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.Addressables;

namespace Anchor.Unity
{
    public enum SceneId
    {
        Main,
        Start,
        Login,
        Demo,
        Field_01,
        Defense,
    }

    public class ResourceHelper
    {
        private static GameObjectBag[] s_GameObjectBags;

        public static GameObjectBag[] GameObjectBags => s_GameObjectBags;

        public static readonly string[] k_SceneNames =
        {
            "Assets/Scenes/Main.unity",
            "Assets/Scenes/Start.unity",
            "Assets/Scenes/Login.unity",
            "Assets/Scenes/Demo.unity",
            "Assets/Resource/Field/Scene/rpgpp_lt_scene_1.0.unity",
            "Assets/Scenes/Defense.unity",
        };

        public static void Initalize()
        {
            int length = System.Enum.GetValues(typeof(GameObjectBagId)).Length;
            s_GameObjectBags = new GameObjectBag[length];

            for (int i = 0; i < length; ++i)
            {
                bool rootGameObjectDontDestroy = true;

                switch ((GameObjectBagId)i)
                {
                    case GameObjectBagId.Normal:
                        rootGameObjectDontDestroy = false;
                        break;
                }

                s_GameObjectBags[i] = new GameObjectBag(i, ((GameObjectBagId)i).ToString(), rootGameObjectDontDestroy);
            }
        }

        public static void LoadScene(SceneId scene, string[] keys, System.Action resultCallback = null)
        {
            System.Action<bool> callback = (success) =>
            {
                if (!success)
                {
                    Debug.LogError(success.ToString());
                }

                resultCallback?.Invoke();
            };

            switch (scene)
            {
                case SceneId.Main:
                case SceneId.Start:
                case SceneId.Login:
                case SceneId.Defense:
                    LoadDefaultScene(keys, scene, callback);
                    break;

                case SceneId.Demo:
                    LoadDemoScene(keys, scene, callback);
                    break;
            }
        }

        public static void LoadAndGetBuiltInAsset(System.Action<bool> callback = null)
        {
            ComMain.Root.StartCoroutine(CoLoadAndGetBuiltInAsset(callback));
        }

        private static IEnumerator CoLoadAndGetBuiltInAsset(System.Action<bool> callback = null)
        {
            foreach(var key in Define.DefaultAssets)
            {
                yield return s_GameObjectBags[(int)GameObjectBagId.Normal].CoLoad(key, ManageType.Default);
            }

            foreach(var key in Define.BuiltInAssets)
            {
                yield return s_GameObjectBags[(int)GameObjectBagId.Normal].CoLoad(key, ManageType.Default);

                var item = s_GameObjectBags[(int)GameObjectBagId.Normal].Get<RectTransform>(key);
            }
        }

        private static void LoadDefaultScene(string[] keys, SceneId id, System.Action<bool> callback = null)
        {
            ComMain.Root.StartCoroutine(CoLoadDefaultScene(keys, id, callback));
        }

        private static IEnumerator CoLoadDefaultScene(string[] keys, SceneId id, System.Action<bool> callback = null)
        {
            //canvas load
            foreach (var asset in keys)
            {
                yield return s_GameObjectBags[(int)GameObjectBagId.Normal].CoLoad(asset, ManageType.Default);
            }

            //scene load
            bool success = false;

            yield return ResourceManager.CoLoadSceneAsync(k_SceneNames[(int)id], UnityEngine.SceneManagement.LoadSceneMode.Single, (result) =>
            {
                success = result;
            });

            if (!success)
            {
                Debug.LogError("scene load fail");
                yield break;
            }
        }

        private static void LoadDemoScene(string[] keys, SceneId id, System.Action<bool> callback = null)
        {
            ComMain.Root.StartCoroutine(CoLoadDemoScene(keys, id, callback));
        }

        private static IEnumerator CoLoadDemoScene(string[] keys, SceneId id, System.Action<bool> callback = null)
        {
            //assets load
            foreach (var asset in keys)
            {
                yield return s_GameObjectBags[(int)GameObjectBagId.Normal].CoLoad(asset, ManageType.Default);
            }

            //demo scene load
            bool success = false;

            yield return ResourceManager.CoLoadSceneAsync(k_SceneNames[(int)id], UnityEngine.SceneManagement.LoadSceneMode.Single, (result) =>
            {
                success = result;
            });

            if (!success)
            {
                Debug.LogError($"{id} scene load fail");
            }

            //field scene load
            yield return ResourceManager.CoLoadSceneAsync(k_SceneNames[(int)SceneId.Field_01], UnityEngine.SceneManagement.LoadSceneMode.Additive, (result) =>
            {
                success = result;
            });

            if (!success)
            {
                Debug.LogError($"{SceneId.Field_01} scene load fail");
            }
        }
    }
}