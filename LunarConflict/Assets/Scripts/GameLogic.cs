using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject game;
    private GameUIScript _uiScript;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();

        if (SettingsScript.SideIsSoviet)
            ChangeToSoviet();
        else
            ChangeToUsa();
    }

    public void ChangeToUsa()
    {
        SettingsScript.UIMoneyMark = "$"; 
    }

    public void ChangeToSoviet()
    {
        SettingsScript.UIMoneyMark = "₽";
    }
}
