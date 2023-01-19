using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsScript;

public class MinimapCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up, Faction == PlayerFaction.USA ? 0 : 180);
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Faction == PlayerFaction.USA ? -10 : 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
