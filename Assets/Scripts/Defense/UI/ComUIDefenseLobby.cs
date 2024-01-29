using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Anchor.Unity.UGui.Panel;
using DanielLochner.Assets.SimpleScrollSnap;

public class ComUIDefenseLobby : ComPanel<ComUIDefenseLobby>
{
    public enum AnimationId
    {
        IsPlaying,
    }

    [Space]
    public GameObject m_StageCell;
    public Transform m_CellRoot;
    public SimpleScrollSnap m_ScrollSnap;

    const int k_MaxCellLength = 5;

    private Animator m_Animators;
    private UIStageCell[] m_Cells;

    public void OnEventGameStart()
    {
        m_Animators.SetBool(AnimationId.IsPlaying.ToString(), true);
    }

    protected override void OnInit()
    {
        m_Animators = GetComponent<Animator>();
        m_Cells = new UIStageCell[k_MaxCellLength];
        for (int i = 0; i < k_MaxCellLength; ++i)
        {
            m_Cells[i] = new UIStageCell()
            {
                rt = m_StageCell.GetComponent<RectTransform>(),
                image = m_StageCell.GetComponentInChildren<Image>(),
                title = m_StageCell.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            };

            m_Cells[i].image.color = new Color(Random.value, Random.value, Random.value);
            m_ScrollSnap.AddToBack(m_StageCell);
        }
    }

    protected override void OnClose()
    {
        ComUIDefenseInGame.Root.Open();
        ComDefense.Root.GameStart();
    }

    /// <summary>
    /// Animator Event
    /// </summary>
    private void OnCloseEvent()
    {        
        Close();
    }

    protected override void OnOpen()
    {
        m_Animators.SetBool(AnimationId.IsPlaying.ToString(), false);
    }    

    protected override void OnSetData(System.EventArgs args)
    {
    }

    protected override void OnSetBtnText(string[] text)
    {
    }
}

public class UIStageCell
{
    public RectTransform rt;
    public Image image;
    public TMPro.TextMeshProUGUI title;
}