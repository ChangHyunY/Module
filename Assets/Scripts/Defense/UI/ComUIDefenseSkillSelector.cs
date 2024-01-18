using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO
public class ComUIDefenseSkillSelector : MonoBehaviour
{
    private static ComUIDefenseSkillSelector s_Root;
    public static ComUIDefenseSkillSelector Root => s_Root;

    private Canvas m_Canvas;

    public ComUISkillContent[] m_ComUISkillContents;
    public UnityEngine.UI.Button m_ButtonRefresh;

    private bool m_CanRefresh = true;

    private void Awake()
    {
        s_Root = this;

        m_Canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        m_Canvas.enabled = false;
    }

    private void Update()
    {
        if(UnityEngine.InputSystem.Keyboard.current.qKey.wasPressedThisFrame)
        {
            OnOpen();
        }
    }

    public void OnOpen()
    {
        Time.timeScale = 0f;
        m_Canvas.enabled = true;
        m_ButtonRefresh.interactable = m_CanRefresh;

        SetUp();
    }

    public void Close()
    {
        Time.timeScale = 1f;
        m_Canvas.enabled = false;
    }

    public void SetUp()
    {
        SkillBuff[] buffs = ComDefensePlayer.Root.SkillAgent.GetRandomBuffs();
        for(int i = 0; i < buffs.Length; ++i)
        {
            m_ComUISkillContents[i].SetUp(buffs[i]);
        }
    }

    public void OnEventRefresh()
    {
        m_CanRefresh = false;

        SetUp();
    }
}
