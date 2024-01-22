using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Anchor.Unity.UGui.Panel;
using System;
using TMPro;

public class ComUIDefenseInGame : ComPanel<ComUIDefenseInGame>
{
    [Space]
    public Button btnGameSpeed;
    public Button btnChest;
    public Scrollbar scrollExp;
    public TextMeshProUGUI progress;
    public TextMeshProUGUI timer;

    [Space]
    public GameObject skillBar;
    public Image[] skillIcons;
    public TextMeshProUGUI[] skillLevels;

    public float SetExp
    {
        set => scrollExp.size = value;
    }

    protected override void OnInit()
    {
        skillBar.SetActive(false);
    }

    protected override void OnClose()
    {
    }

    protected override void OnOpen()
    {
        skillBar.SetActive(true);
    }

    protected override void OnSetBtnText(string[] text)
    {
    }

    protected override void OnSetData(EventArgs args)
    {
    }

    public void Reset()
    {
        scrollExp.size = 0;
        progress.text = $"0/0";
        timer.text = "00:00";
    }
}