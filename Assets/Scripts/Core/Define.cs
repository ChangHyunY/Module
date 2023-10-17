
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
    Start,
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

    private static readonly string[] k_LobbyAssets =
    {
    };


    public static string[] SoundAssets => k_SoundAssets;
    public static string[] LoginAssets => k_LoginAssets;
    public static string[] StartAssets => k_StartAssets;
    public static string[] LobbyAssets => k_LobbyAssets;


    private const string k_SoundPath = "Assets/Resource/Sound/Assets/";

    public static string SoundPath => k_SoundPath;
}