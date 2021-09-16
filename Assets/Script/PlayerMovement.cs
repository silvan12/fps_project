using UnityEngine;
using MLAPI;
public class PlayerMovement : NetworkBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 12f; // Movement speed
    public float jumpHeight = 3f; // Jump height
    public float gravity = -20f; // Gravity
    public float mouseSens = 100f;

    public Transform groundCheck; // Small cube below playermodel 
    public LayerMask groundMask;  // ground mask
    public Transform playerBody; // player
    public Camera playerCamera; // first person player camera

    private float _groundDistance = 0.4f; // radius of ground check
    private Vector3 _velocity; // velocity used for falling speed
    private bool _isGrounded; // if on ground
    private float _xRotation = 0f; // 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (!IsLocalPlayer)
        {
            playerCamera.GetComponent<AudioListener>().enabled = false;
            playerCamera.GetComponent<Camera>().enabled = false;
        }
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            Move();
            Jump();
            Look();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (moveSpeed * Time.deltaTime));
    }

    void Jump()
    {
  
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(_velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}