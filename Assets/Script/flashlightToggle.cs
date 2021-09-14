using UnityEngine;
using System.Collections;
using UnityEditor.IMGUI.Controls;

public class flashlightToggle : MonoBehaviour
{
    public Light flashlight;
    public AudioSource source;
    public AudioClip sound;
    
    
    private void Start()
    {
        flashlight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            source.PlayOneShot(sound);
        }
    }
}
