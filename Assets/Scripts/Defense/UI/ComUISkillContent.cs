using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComUISkillContent : MonoBehaviour
{
    public Image icon;
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI content;
    public Button select;

    private SkillBuff m_Buff;

    public void SetUp(SkillBuff buff)
    {
        m_Buff = buff;
        icon.sprite = buff.icon;
        title.text = buff.title;
        content.text = buff.content;
    }

    public void OnEventSkillSelect()
    {
        ComDefensePlayer.Root?.SkillAgent.Edit(m_Buff);
        ComUIDefenseSkillSelector.Root.Close();
    }
}
