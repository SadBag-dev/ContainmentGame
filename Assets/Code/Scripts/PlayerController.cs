using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController:MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    InputAction sneakAction;
    public Rigidbody2D player;
    [SerializeField] private float playerWalkSpeed;
    [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float playerSneakSpeed;
    private float playerSpeed;
    private bool isSprinting;
    public bool isSneaking;
    


    private void Start()
    {
        playerSpeed = playerWalkSpeed;
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        sneakAction = InputSystem.actions.FindAction("Sneak");
    }

    void FixedUpdate()
    {
        PlayerMovement();
        Debug.Log(isSprinting);

    }

    void PlayerMovement()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        player.linearVelocity = moveDirection * playerSpeed;

        if (sprintAction.IsPressed())
        {
            isSprinting = true;
            playerSpeed = playerSprintSpeed;
        }else
        {
            isSprinting = false;
            playerSpeed = playerWalkSpeed;
        }

        if (sneakAction.IsPressed() && isSprinting == false)
        {
            isSneaking = true;
            playerSpeed = playerSneakSpeed;
        } else
        {
            isSneaking = false;
        }

    }

}
