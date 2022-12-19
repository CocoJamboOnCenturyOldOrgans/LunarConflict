using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public enum PlayerFaction
    {
        None = 0,
        USA = 1,
        USSR = 2
    }
    
    //UI Changers
    public static string UIMoneyMark = "$";

    //Gameplay Changers
    public static PlayerFaction Faction;
}
