using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity.UGui.Panel;
using System;

//TODO
public class ComUIDefenseSkillSelector : ComPanel<ComUIDefenseSkillSelector>
{
    public ComUISkillContent[] m_ComUISkillContents;
    public UnityEngine.UI.Button m_ButtonRefresh;

    private bool m_CanRefresh = true;

    protected override void OnInit()
    {
        m_ButtonRefresh.onClick.AddListener(() =>
        {
            m_CanRefresh = false;
            SetUp();
        });
    }

    protected override void OnOpen()
    {
        Time.timeScale = 0f;
        m_ButtonRefresh.interactable = m_CanRefresh;

        SetUp();
    }

    protected override void OnClose()
    {
        Time.timeScale = 1f;
    }

    protected override void OnSetData(EventArgs args)
    {
    }

    protected override void OnSetBtnText(string[] text)
    {
    }

    public void SetUp()
    {
        SkillBuff[] buffs = ComDefensePlayer.Root.SkillAgent.GetRandomBuffs();
        for(int i = 0; i < buffs.Length; ++i)
        {
            m_ComUISkillContents[i].SetUp(buffs[i]);
        }
    }

    public void Reset()
    {
        m_CanRefresh = true;
    }
}
