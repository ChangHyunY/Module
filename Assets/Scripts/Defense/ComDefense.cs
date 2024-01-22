using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComDefense : MonoBehaviour
{
    private static ComDefense s_Root;

    public static ComDefense Root => s_Root;

    public SOMonsterData soMonsterData;
    public SOStageData soStageData;
    public SOSkillData soSkillData;
    public List<SOSkillBuff> soSkillBuff;

    public int StageIndex { get; set; }

    public StageData GetStageData
    {
        get => soStageData.stageDatas[StageIndex];
    }

    private void Awake()
    {
        s_Root = this;

        Screen.SetResolution(720, 1280, true);
    }

    private void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.qKey.wasPressedThisFrame)
        {
            ComUIDefenseSkillSelector.Root.Open();
        }
    }

    public void GameStart()
    {
        StartCoroutine(IGameStart());
    }

    private IEnumerator IGameStart()
    {
        yield return new WaitForSeconds(1.0f);

        ComDefensePlayer.Root.SetUp(SkillId.MagicMissile);
        ComUIDefenseInGame.Root.Reset();
        ComUIDefenseSkillSelector.Root.Reset();
        StartCoroutine(ComDefenseSpawner.Root.Spawn());
    }
}
