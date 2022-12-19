using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public enum PlayerFaction
    {
        None = 0,
        USA = 1,
        USSR = 2
    }
    
    public static List<Resolution> Resolutions;
    
    //UI Changers
    public static string UIMoneyMark = "$";

    //Gameplay Changers
    public static PlayerFaction Faction;
}
