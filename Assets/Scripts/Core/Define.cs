
enum GameObjectBagId
{
    Normal,
}

public enum DefaultAssetId
{
    CommonDialog,
    DamageText,
}

public enum DialogId
{
    CommonDialog,
    DamageText,
    HpBar,
}

public enum PanelId
{
    Main,
    Login,
    Start,
    Demo,

    DefenseLobby,
    DefenseInGame,
    DefenseSkillSelector,
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

public enum SkillType
{
    Normal,
    Fire,
    Ice,
    Lightning,
    Physicis,
    Wind,
}

public enum SkillStatusType
{
    Cooldown,
    SkillRange,
    MoveSpeed,
    DefaultDamage,
    Pentrate,
    CastCount,
    InitCount,
    ExplosionRange,
    ExplosionDamage,
}

public enum SkillId
{
    MagicMissile,
    Fireball,
    Icebolt,
}

public enum SkillBuffId
{
    MagicMissile,
    MagicMissileEnforce,
    MagicMissileCombo,
    MagicMissileSpread,
    MagicMissileSpreadEnforce,
    MagicMissileSalvo,
    MagicMissilePenetrate,
    MagicMissileExplosion,
    MagicMissileExplosionEnforce,

    Fireball,
    FireballExplosionExpansion,
    FireballExplosionEnforce,
    FireballFlame,
    FireballBurn,
    FireballEnforce,
    FireballCombo,
    FireballCombo2,

    Icebolt,
    IceboltEnforce,
    IceboltEntreme,
    IceboltTriangle,
    IceboltChill,
    IceboltPenetrate,
    IceboltCombo,
    IceboltImpact,
    IceboltSalvo,
    IceboltSpread,

    Thunderbolt,
    ThunderboltEnforce,
    ThunderboltStun,
    ThunderboltCombo,

    Log,
    LogEnforce,
    LogCombo,
    LogExpansion,
    LogImpact,

    PulseLaser,
    PulseLaserEnforce,

    FocusLaser,
    FocusLaserEnforce,
    FocusLaserRefraction,
    FocusLaserCombo,
    FocusLaserFocus,
    FocusLaserFocusExplosion,

    Frost,
    FrostEnforce,
    FrostExpansion,
    FrostCombo,

    ChainLightning,

    Meteor,

    Tornado,

    ElectronmicNet,

    Grenade,

    Hurricane,

    BallTypeLightning,
}

public partial class Define
{
    private static readonly string[] k_SoundAssets =
    {
        "Assets/Resource/Sound/Assets/eft_ui_click_blop.mp3",
    };

    private static readonly string[] k_BuiltInAssets=
    {
        "Assets/Resource/BuiltIn/Assets/Canvas_Main.prefab",
    };

    private static readonly string[] k_DefaultAssets =
    {
        "Assets/Resource/Default/Assets/CommonDialog.prefab",
        "Assets/Resource/Default/Assets/DamageText.prefab",
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
        "Assets/Resource/Demo/Assets/Cube.prefab",
        "Assets/Resource/Demo/Assets/HUD_HpBar.prefab",
    };

    private static readonly string[] k_DefenseAssets =
    {
        "Assets/Resource/Defense/UI/Assets/Canvas_DefenseIngame.prefab",
        "Assets/Resource/Defense/UI/Assets/Canvas_Lobby.prefab",
        "Assets/Resource/Defense/UI/Assets/Canvas_SkillSelector.prefab",
    };


    public static string[] SoundAssets => k_SoundAssets;
    public static string[] BuiltInAssets => k_BuiltInAssets;
    public static string[] DefaultAssets => k_DefaultAssets;
    public static string[] LoginAssets => k_LoginAssets;
    public static string[] StartAssets => k_StartAssets;
    public static string[] DemoAssets => k_DemoAssets;
    public static string[] DefenseAssets => k_DefenseAssets;


    private const string k_SoundPath = "Assets/Resource/Sound/Assets/";

    public static string SoundPath => k_SoundPath;
}