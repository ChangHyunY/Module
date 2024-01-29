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

    private const float k_StartDelay = 2.0f;

    public int StageIndex { get; set; }
    public bool IsPlaying { get; set; }

    public StageData GetStageData
    {
        get => soStageData.stageDatas[StageIndex];
    }

    private void Awake()
    {
        s_Root = this;

        Screen.SetResolution(720, 1280, true);
    }

    public void GameStart()
    {
        StartCoroutine(IGameStart());
    }

    private IEnumerator IGameStart()
    {
        IsPlaying = true;

        yield return new WaitForSeconds(k_StartDelay);

        ComDefensePlayer.Root.SetUp(SkillId.MagicMissile);
        ComUIDefenseSkillSelector.Root.Reset();
        StartCoroutine(ComDefenseSpawner.Root.Spawn());
    }

    public void GameOver()
    {
        Debug.Log("GameOver");

        IsPlaying = false;
        ComUIDefenseInGame.Root.Close();
        ComUIDefenseLobby.Root.Open();
    }
}
