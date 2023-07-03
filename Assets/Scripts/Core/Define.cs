
enum GameObjectBagId
{
    Normal,
    Sound,
}

public enum DialogId
{

}

public enum PanelId
{
    Login,
}

public enum SoundType
{
    BGM,
    EFT,
}

public enum SoundId
{
    eft_ui_click_blop,
}

public partial class Define
{
    private static readonly string[] k_SoundAssets =
    {
        "Assets/Resource/Sound/Assets/eft_ui_click_blop.mp3",
    };

    private static readonly string[] k_LoginAssets =
    {
        "Assets/Resource/Login/Assets/Canvas_Login.prefab",
    };

    private static readonly string[] k_StartAssets =
    {
    };


    public static string[] SoundAssets => k_SoundAssets;

    public static string[] LoginAssets => k_LoginAssets;

    public static string[] StartAssets => k_StartAssets;


    private const string k_SoundPath = "Assets/Resource/Sound/Assets/";

    public static string SoundPath => k_SoundPath;
}