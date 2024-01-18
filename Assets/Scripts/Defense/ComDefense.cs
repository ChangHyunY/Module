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
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(ComDefenseSpawner.Root.Spawn());
        ComDefensePlayer.Root.SetUp(SkillId.MagicMissile);
    }
}
