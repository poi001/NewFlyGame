
public class DefineClass
{
    //플레이어 스탯
    //스피드
    public const int PlayerStat_MinSpeed = 1;
    public const float PlayerStat_SpeedValue = 2.0f;
    //무게
    public const int PlayerStat_MinWeight = 1;
    public const int PlayerStat_MaxWeight = 20;
    public const float PlayerStat_WeightValue = 1.5f;
    //HP
    public const int PlayerStat_MinHP = 0;
    //MP
    public const int PlayerStat_MinMP = 0;

    //애니메이션 Parameters
    //플레이어
    public const string PlayerAnimationParameter_Up = "Up";
    public const string PlayerAnimationParameter_Sprint = "Sprint";
    public const string PlayerAnimationParameter_Damaged = "Damaged";

    //Tag와 Layer
    //Tag
    public const string Tag_Obstacle = "Obstacle";
    public const string Tag_Item = "Item";
    public const string Tag_Player = "Player";

    //Layer
    public const int Layer_Player = 6;
    public const int Layer_PlayerDamaged = 7;
    public const int Layer_Obstacle = 8;
    public const int Layer_Item = 9;

    //UI
    //UI Name
    public const string UI_HP = "HPUIBackGround";
    public const string UI_Skill = "SkillUIBackGround";
    public const string UI_Distance = "DistanceUI";
    public const string UI_Timer = "TimerUI";
    public const string UI_GameResult = "GameResultBackGround";
    public const string UI_Options = "GameResultBackGround";

    //Scene
    //Scene Name
    public const string Scene_ManMenu = "TitleScene";
    public const string Scene_Stage1 = "Stage1Scene";
}