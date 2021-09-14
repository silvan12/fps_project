using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // public Slider staminaBar;

    public CharacterController controller;

    public float moveSpeed = 12f;
    public float jumpHeight = 3f;
   
    // public float maxStamina = 300f;
    // public float rechargeStamina = 0.5f;
    // public float sprintStaminaUse = 2f;


    public float gravity = -20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;

    private bool _isGrounded;

    // private void Start()
    // {
    //     staminaBar.maxValue = maxStamina;
    //     staminaBar.value = maxStamina;
    // }


    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        // if (Input.GetKey(KeyCode.LeftShift) && staminaBar.value > 0)
        // {
        //     staminaBar.value -= sprintStaminaUse;
        //     Debug.Log("sprinting");
        // }
        // else if (staminaBar.value < staminaBar.maxValue)
        // {
        //     staminaBar.value += rechargeStamina;
        // }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (moveSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }
}