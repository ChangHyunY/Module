using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComDefensePlayer : MonoBehaviour
{
    private static ComDefensePlayer s_Root;
    public static ComDefensePlayer Root => s_Root;

    public List<GameObject> m_SkillPrefabs = new List<GameObject>();
    public Transform m_SkillRoot;

    private SkillAgent m_SkillAgent;
    private StateAgent m_StateAgent;

    #region Property
    public SkillAgent SkillAgent
    {
        get => m_SkillAgent;
    }

    public StateAgent StateAgent
    {
        get => m_StateAgent;
    }
    #endregion

    private void Awake()
    {
        s_Root = this;
    }

    public void SetUp(SkillId id)
    {
        StageData stageData = ComDefense.Root.GetStageData;
        m_StateAgent = new StateAgent(stageData);

        m_SkillAgent = new SkillAgent(this, m_SkillRoot);
        m_SkillAgent.Add(id);
    }

    private void Update()
    {
        m_SkillAgent?.Casting();
    }
}
