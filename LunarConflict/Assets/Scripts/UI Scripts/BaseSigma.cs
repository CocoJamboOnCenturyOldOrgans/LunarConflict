using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSigma : MonoBehaviour
{
    private GameUIScript UIScript;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("EventManagement").GetComponent<GameUIScript>();
    }

    public void OnMouseEnter()
    {
        //Temp Test Values
        UIScript.BuildingName.text = "Base Sigma";
    }

    public void OnMouseExit()
    {
        UIScript.BuildingName.text = "N/A";
    }
}
