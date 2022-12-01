using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOmega : MonoBehaviour
{
    private GameUIScript UIScript;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("UI").GetComponent<GameUIScript>();
    }

    public void OnMouseEnter()
    {
        //Temp Test Values
        UIScript.BuildingName.text = "Base Omega";
    }

    public void OnMouseExit()
    {
        UIScript.BuildingName.text = "N/A";
    }
}
