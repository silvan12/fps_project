using UnityEngine;
using MLAPI;

public class Flashlight : NetworkBehaviour
{
    public Light flashlight;
    public Light playerLight;
    public AudioSource source;

    public AudioClip sound;

    void Start()
    {
        if (IsLocalPlayer)
        {
            flashlight.enabled = true;
            playerLight.enabled = true;
        }
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            Toggle();
        }
    }

    void Toggle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            playerLight.enabled = !playerLight.enabled;

            source.PlayOneShot(sound);
        }
    }
}