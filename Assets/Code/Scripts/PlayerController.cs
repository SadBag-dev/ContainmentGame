using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController:MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    public Rigidbody2D player;
    [SerializeField] private int playerSpeed;
    [SerializeField] private int playerSprintSpeed;


    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();

        player.linearVelocity = moveDirection * playerSpeed;
        Debug.Log(player.linearVelocity);

        if (sprintAction.IsPressed())
        {
            playerSpeed = playerSprintSpeed;
        }
    }

}
