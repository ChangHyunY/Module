using System;
using Anchor.Unity;
using Anchor.Unity.UGui.Panel;

public class ComUIStart : ComPanel<ComUIStart>
{
    protected override void OnClose()
    {
    }

    protected override void OnInit()
    {
    }

    protected override void OnOpen()
    {
    }

    protected override void OnSetBtnText(string[] text)
    {
    }

    protected override void OnSetData(EventArgs args)
    {
    }

    public void OnGameStart()
    {
        ResourceHelper.LoadScene(SceneId.Defense, Define.DemoAssets);
    }
}
