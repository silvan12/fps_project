using UnityEngine;
using System.Collections;
using UnityEditor.IMGUI.Controls;

public class flashlightToggle : MonoBehaviour
{
    public Light flashlight;
    public Light playerLight;
    public AudioSource source;
    public AudioClip sound;
    
    
    private void Start()
    {
        flashlight.enabled = false;
        playerLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            playerLight.enabled = !playerLight.enabled;

            source.PlayOneShot(sound);
        }
    }
}
