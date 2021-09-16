using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public Light playerLight;
    public AudioSource source;

    public AudioClip sound;

    void Start()
    {
        flashlight.enabled = false;
        playerLight.enabled = false;
    }

    void Update()
    {
        Toggle();
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