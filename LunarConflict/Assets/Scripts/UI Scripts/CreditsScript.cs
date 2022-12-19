using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    private Text _version;
    private Text _unity; 
    private Text _systemInformation;
    void Start()
    {
        _version = transform.Find("About_Version").GetComponent<Text>();
        _unity = transform.Find("About_Unity").GetComponent<Text>();
        _systemInformation = transform.Find("About_SystemInfo").GetComponent<Text>();
        
        _version.text = "Version: " + Application.version;
        _unity.text = "Made in: Unity " + Application.unityVersion;
        _systemInformation.text = "OS: " + SystemInfo.operatingSystem + "\n" +
                                 "Graphics API: " + SystemInfo.graphicsDeviceType + " (" + SystemInfo.graphicsDeviceVersion + ")";
    }
}
