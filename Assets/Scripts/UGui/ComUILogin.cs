using Anchor.Unity.UGui.Panel;
using System;

public class ComUILogin : ComPanel<ComUILogin>
{
    protected override void OnInit()
    {
    }

    protected override void OnClose()
    {
    }    

    protected override void OnOpen()
    {
    }

    protected override void OnSetBenText(string[] text)
    {
    }

    protected override void OnSetData(EventArgs args)
    {
    }

    public void OnClickGoogle()
    {
        Anchor.ResourceHelper.LoadScene(Anchor.SceneId.Start);
    }

    public void OnClickGuest()
    {
        Anchor.ResourceHelper.LoadScene(Anchor.SceneId.Start);
    }
}
