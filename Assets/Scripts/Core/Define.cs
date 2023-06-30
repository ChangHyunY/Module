
enum GameObjectBagId
{
    Normal,
}

public enum DialogId
{

}

public enum PanelId
{
    Login,
}

public partial class Define
{
    private static readonly string[] k_LoginAssets =
    {
        "Assets/Resource/Login/Assets/Canvas_Login.prefab",
    };

    private static readonly string[] k_StartAssets =
    {
    };

    public static string[] LoginAssets => k_LoginAssets;

    public static string[] StartAssets => k_StartAssets;
}