using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHelperScript : MonoBehaviour
{
    public static string ConvertToPercentageValue(float value) 
    { return (Mathf.RoundToInt(value * 100) + "%"); }
}
