using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public InputField inputField;
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        menuPanel.SetActive(false);
    }

    public void Join()
    {
        string ipAddressInput = inputField.text;
        if (ipAddressInput.Length <= 0)
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = "127.0.0.1";
        }
        else
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipAddressInput;
        }
        NetworkManager.Singleton.StartClient();
        menuPanel.SetActive(false);
    }

    public void Copy()
    {
        string ipAddress = new WebClient().DownloadString("http://icanhazip.com");
        GUIUtility.systemCopyBuffer = ipAddress;
    }
}
