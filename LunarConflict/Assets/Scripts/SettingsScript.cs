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

    public enum ChoosenMap
    {
        None = 0,
        Flat = 1,
        Hole = 2,
        TwoHills = 3
    }
    
    public static List<Resolution> Resolutions;
    
    //UI Changers
    public static string UIMoneyMark = "$";

    //Gameplay Changers
    public static PlayerFaction Faction = Application.isEditor ? PlayerFaction.USA : PlayerFaction.None;
    public static ChoosenMap Map = Application.isEditor ? ChoosenMap.Flat : ChoosenMap.None;

    public static bool IsPlayer(PlayerFaction faction) => faction == Faction;
}
