using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] private Text version;
    [SerializeField] private Text unity; 
    [SerializeField] private Text systemInformation;
    void Start()
    {
        version.text = "Version: " + Application.version;
        unity.text = "Made in: Unity " + Application.unityVersion;
        systemInformation.text = "OS: " + SystemInfo.operatingSystem + "\n" +
                                 "Graphics API: " + SystemInfo.graphicsDeviceType + " (" + SystemInfo.graphicsDeviceVersion + ")";
    }
}
