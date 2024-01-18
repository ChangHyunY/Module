using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DanielLochner.Assets.SimpleScrollSnap;

public class ComUIDefenseLobby : MonoBehaviour
{
    public enum AnimationId
    {
        OnClose,
    }

    public Animator[] m_Animators;
    public GameObject[] m_ControlledObjects;
    [Space]
    public GameObject m_StageCell;
    public Transform m_CellRoot;
    public SimpleScrollSnap m_ScrollSnap;

    const int k_MaxCellLength = 5;

    private UIStageCell[] m_Cells;

    private void Start()
    {
        m_Cells = new UIStageCell[k_MaxCellLength];
        for(int i = 0; i < k_MaxCellLength; ++i)
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

        ComDefense.Root.GameStart();
    }
}

public class UIStageCell
{
    public RectTransform rt;
    public Image image;
    public TMPro.TextMeshProUGUI title;
}