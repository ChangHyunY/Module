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
        OnClose,
    }

    [Space]
    public Animator[] m_Animators;
    public GameObject[] m_ControlledObjects;
    [Space]
    public GameObject m_StageCell;
    public Transform m_CellRoot;
    public SimpleScrollSnap m_ScrollSnap;

    const int k_MaxCellLength = 5;

    private UIStageCell[] m_Cells;

    public void OnEventGameStart()
    {
        foreach(Animator animator in m_Animators)
        {
            animator.SetBool(AnimationId.OnClose.ToString(), true);
        }

        foreach(GameObject obj in m_ControlledObjects)
        {
            obj.SetActive(false);
        }

        ComUIDefenseInGame.Root.Open();
        ComDefense.Root.GameStart();
    }

    protected override void OnInit()
    {
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
    }

    protected override void OnOpen()
    {
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