using UnityEngine;

public class BaseSigma : MonoBehaviour
{
    private GameUIScript _uiScript;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
    }

    public void OnMouseEnter()
    {
        //Temp Test Values
        _uiScript.bottomPanel.buildingName.text = "Base Sigma";
    }

    public void OnMouseExit()
    {
        _uiScript.bottomPanel.buildingName.text = "N/A";
    }
}
