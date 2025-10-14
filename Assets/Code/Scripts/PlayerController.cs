using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    InputAction sneakAction;
    public Rigidbody2D player;
    [SerializeField] private float playerWalkSpeed;
    [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float playerSneakSpeed;
    private float playerSpeed;
    private float playerStamina;
    private float maxStamina = 100;
    private float minStamina = 0;
    public float staminaLossRate;
    public float staminaRecoveryRate;
    private bool isSprinting;
    public bool isSneaking;



    private void Start()
    {
        playerSpeed = playerWalkSpeed;
        playerStamina = maxStamina;
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        sneakAction = InputSystem.actions.FindAction("Sneak");
    }

    void FixedUpdate()
    {
        PlayerMovement();
        Stamina();
        Debug.Log(playerStamina);
    }

    void PlayerMovement()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        player.linearVelocity = moveDirection * playerSpeed;
        //Sprinting
        if (sprintAction.IsPressed())
        {
            isSprinting = true;
            playerSpeed = playerSprintSpeed;
        }
        else
        {
            isSprinting = false;
            playerSpeed = playerWalkSpeed;
        }
        //Sneaking
        if (sneakAction.IsPressed() && isSprinting == false)
        {
            isSneaking = true;
            playerSpeed = playerSneakSpeed;
        }
        else
        {
            isSneaking = false;
        }

    }
    void Stamina()
    {
        if (isSprinting == true)
        {
            playerStamina -= staminaLossRate * Time.deltaTime;
            playerStamina = Mathf.Clamp(playerStamina, minStamina, maxStamina);
        }

        if (isSprinting == false)
        {
            playerStamina += staminaRecoveryRate * Time.deltaTime;
            playerStamina = Mathf.Clamp(playerStamina, minStamina, maxStamina);
        }
    }
}
