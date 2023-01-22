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
        Moon = 1,
        Mars = 2,
        Weird = 3
    }

    public enum AIDifficulty
    {
        None = 0,
        Easy = 1,
        Medium = 2,
        Hard = 3,
        Impossible = 4
    }
    
    public static List<Resolution> Resolutions;
    
    //UI Changers
    public static string UIMoneyMark = "$";

    //Gameplay Changers
    public static PlayerFaction Faction = Application.isEditor ? PlayerFaction.USA : PlayerFaction.None;
    public static ChoosenMap Map = Application.isEditor ? ChoosenMap.Weird : ChoosenMap.None;
    public static AIDifficulty AIDiff = Application.isEditor ? AIDifficulty.Medium : AIDifficulty.None;
    
    public static bool IsPlayer(PlayerFaction faction) => faction == Faction;
}
