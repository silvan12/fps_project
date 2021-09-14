using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;

    public float hitRange = 3f;
    public float hitPower = 100f;
    
    public Transform playerBody;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // If mouse clicked (activates only once while mouse held down)
        // 0 for mouse1
        if (Input.GetMouseButtonDown(0))
        {
            // If raycast hits something in range hitRange
            if (Physics.Raycast(ray, out hitData, hitRange))
            {
                // If tag has "Push"
                if (hitData.transform.CompareTag("Push"))
                {
                    // Debug.DrawRay(ray.origin, ray.direction * 10);
                    hitData.rigidbody.AddForce(transform.forward * hitPower);
                }
            }
        }

        
    }
}