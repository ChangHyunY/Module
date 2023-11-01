
enum GameObjectBagId
{
    Normal,
}

public enum DialogId
{
    CommonDialog,
    DamageText,
}

public enum PanelId
{
    Login,
    Start,
    Demo,
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

public enum DamageId
{
    Default,
    Critical,
    Dodge,
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
        "Assets/Resource/Start/Assets/Canvas_Start.prefab",
    };

    private static readonly string[] k_DemoAssets =
    {
        "Assets/Resource/Demo/Assets/Canvas_Demo.prefab",
        "Assets/Resource/Demo/Assets/CommonDialog.prefab",
        "Assets/Resource/Demo/Assets/Cube.prefab",
        "Assets/Resource/Demo/Assets/TMP_Damage.prefab",
    };


    public static string[] SoundAssets => k_SoundAssets;
    public static string[] LoginAssets => k_LoginAssets;
    public static string[] StartAssets => k_StartAssets;
    public static string[] DemoAssets => k_DemoAssets;


    private const string k_SoundPath = "Assets/Resource/Sound/Assets/";

    public static string SoundPath => k_SoundPath;
}