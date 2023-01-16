using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GameRoundData;
using static SettingsScript;

public class VictoryScreenDataScript : MonoBehaviour
{
    public Text TimeAmount;
    public Text RemainingHPAmount;
    public Text KilledEnemiesAmount;
    public Text CreatedEntitiesAmount;

    public Text ResultText;
    public Text VictorySideText;
    public Image Left1;
    public Image Left2;
    public Image Left3;
    public Image Right1;
    public Image Right2;
    public Image Right3;
    public Image Flag1;
    public Image Flag2;

    public Sprite USAAstronaut;
    public Sprite SovietAstronaut;
    public Sprite USAFlag;
    public Sprite SovietFlag;
    
    private Sprite AstronautSprite;
    private Sprite FlagSprite;

    [Header("Audio")] 
    [SerializeField] private AudioClip victoryTheme;
    [SerializeField] private AudioClip defeatTheme;

    private void Awake()
    {
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.clip = playerWon ? victoryTheme : defeatTheme;
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerWon)
        {
            ResultText.text = "VICTORY!";
            VictorySideText.text = Faction == PlayerFaction.USSR ? "SOVIETS Wins!" : "USA Wins!";
            AstronautSprite = Faction == PlayerFaction.USSR ? SovietAstronaut : USAAstronaut;
            FlagSprite = Faction == PlayerFaction.USSR ? SovietFlag : USAFlag;
        }
        else
        {
            ResultText.text = "DEFEAT!";
            VictorySideText.text = Faction == PlayerFaction.USSR ? "USA Wins!" : "SOVIETS Wins!";
            AstronautSprite = Faction == PlayerFaction.USSR ? USAAstronaut : SovietAstronaut;
            FlagSprite = Faction == PlayerFaction.USSR ? USAFlag : SovietFlag;
        }

        ChangeGraphics();

        //I don't have an idea how to make it better, in situation when seconds/minutes are lower than 10 xd
        TimeAmount.text = (time / 60 < 10) ? "0" : "";
        TimeAmount.text += (time / 60).ToString() + ":";
        TimeAmount.text += (time % 60 < 10) ? "0" : "";
        TimeAmount.text += (time % 60).ToString();

        RemainingHPAmount.text = leftBaseHP.ToString();
        KilledEnemiesAmount.text = kills.ToString();
        CreatedEntitiesAmount.text = unitsSpawned.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ChangeGraphics()
    {
        Left1.sprite = AstronautSprite;
        Left2.sprite = AstronautSprite;
        Left3.sprite = AstronautSprite;
        Right1.sprite = AstronautSprite;
        Right2.sprite = AstronautSprite;
        Right3.sprite = AstronautSprite;
        Flag1.sprite = FlagSprite;
        Flag2.sprite = FlagSprite;
    }
}
