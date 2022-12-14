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
        _uiScript.buildingName.text = "Base Sigma";
    }

    public void OnMouseExit()
    {
        _uiScript.buildingName.text = "N/A";
    }
}
