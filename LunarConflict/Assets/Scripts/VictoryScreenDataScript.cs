using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GameRoundData;

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

    // Start is called before the first frame update
    void Start()
    {
        TimeAmount.text = "99:99";
        RemainingHPAmount.text = leftBaseHP.ToString();
        KilledEnemiesAmount.text = kills.ToString();
        CreatedEntitiesAmount.text = unitsSpawned.ToString();

        if (playerWon)
            USAWin();
        else
            SovietWin();

    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SovietWin()
    {
        ResultText.text = "LOSE!";
        VictorySideText.text = "SOVIETS Wins!";
        Left1.sprite = SovietAstronaut;
        Left2.sprite = SovietAstronaut;
        Left3.sprite = SovietAstronaut;
        Right1.sprite = SovietAstronaut;
        Right2.sprite = SovietAstronaut;
        Right3.sprite = SovietAstronaut;
        Flag1.sprite = SovietFlag;
        Flag2.sprite = SovietFlag;
    }

    public void USAWin()
    {
        ResultText.text = "VICTORY!";
        VictorySideText.text = "USA Wins!";
        Left1.sprite = USAAstronaut;
        Left2.sprite = USAAstronaut;
        Left3.sprite = USAAstronaut;
        Right1.sprite = USAAstronaut;
        Right2.sprite = USAAstronaut;
        Right3.sprite = USAAstronaut;
        Flag1.sprite = USAFlag;
        Flag2.sprite = USAFlag;
    }
}
