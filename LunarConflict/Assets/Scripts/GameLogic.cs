using UnityEngine;
using static SettingsScript;

public class GameLogic : MonoBehaviour
{
    private GameUIScript _uiScript;

    void Awake()
    {
        _uiScript = FindObjectOfType<GameUIScript>();

        if (Faction == PlayerFaction.USSR)
            ChangeToSoviet();
        else if(Faction == PlayerFaction.USA)
            ChangeToUsa();
    }

    public void ChangeToUsa()
    {
        UIMoneyMark = "$"; 
    }

    public void ChangeToSoviet()
    {
        UIMoneyMark = "₽";
    }
}
