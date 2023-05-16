using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * A controller class that handles the player's actions
 */
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveInput; // Stores the player movement input vector
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    PlayerInput playerInput;

    bool isAlive = true;
    
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
       // playerAnimator.SetBool("IsFacingDown", true);
    }

    void Update()
    {
        // If the player has died, stop updating
        if(!isAlive)
        {
            return;
        }
        Walk();
    }

    /*
     * Input System movement check
     */
    void OnMove(InputValue value)
    {
        // If the player has died, stop moving
        if(!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>(); // Set the player movement vector to the input value
        Debug.Log(moveInput);
    }

    /*
     * Input System melee attack check
     */
    void OnMelee(InputValue value)
    {
        // If the player has died, stop attacking
        if(!isAlive)
        {
            return;
        }

        // If the melee attack button is pressed, perform a melee attack
        if(value.isPressed)
        {
            MeleeAttack();
        }
    }

    /*
     * Allows the player to walk up, down, left, right, and diagonally
     * Also sets walking and idle animations to their respective directions
     */
    void Walk()
    {
        float moveHorizontal = moveInput.x;
        float moveVertical = moveInput.y;
        Vector2 playerVelocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        playerRigidBody.velocity = playerVelocity; // Move the player based on the movement vector

        // If the player is moving up (north)
        if (moveVertical > 0f)
        {
            // Set the walking animation to its "up" direction
            playerAnimator.SetBool("IsUpPressed", true);
            playerAnimator.SetBool("IsFacingUp", true);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);
        }

        // If the player is moving down (south)
        if(moveVertical < 0f)
        {         
            // Set the walking animation to its "down" direction
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", true);
            playerAnimator.SetBool("IsFacingDown", true);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);
        }
        
        // If the player is moving right (east)
        if(moveHorizontal > 0f)
        {
            // Set the walking animation to its "right" direction
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", true);
            playerAnimator.SetBool("IsFacingRight", true);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);
        }

        // If the player is moving left (west)
        if (moveHorizontal < 0f)
        {
            // Set the walking animation to its "left" direction
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", true);
            playerAnimator.SetBool("IsFacingLeft", true);
        }

        // If the player is not moving and facing down (south)
        if (moveHorizontal == 0f && moveVertical == 0f && playerAnimator.GetBool("IsFacingDown"))
        {
            // Set the animation to its "idle down" state
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);
        }

        // If the player is not moving and facing up (north)
        if (moveHorizontal == 0f && moveVertical == 0f && playerAnimator.GetBool("IsFacingUp"))
        {
            // Set the animation to the "idle up" state
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);
        }

        // If the player is not moving and facing right (east)
        if (moveHorizontal == 0f && moveVertical == 0f && playerAnimator.GetBool("IsFacingRight"))
        {
            // Set the animation to the "idle right" state
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsLeftPressed", false);
            playerAnimator.SetBool("IsFacingLeft", false);

        }

        // If the player is not moving and facing left (west)
        if (moveHorizontal == 0f && moveVertical == 0f && playerAnimator.GetBool("IsFacingLeft"))
        {
            // Set the animation to the "idle left" state
            playerAnimator.SetBool("IsUpPressed", false);
            playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
            playerAnimator.SetBool("IsRightPressed", false);
            playerAnimator.SetBool("IsFacingRight", false);
            playerAnimator.SetBool("IsLeftPressed", false);
        }
    }

    /*
     * Allows the player to perform a melee attack
     */
    void MeleeAttack()
    {
        StartCoroutine("MeleeAttackAnimDelay"); // Start the melee attack animation delay coroutine
    }

    /*
     * Coroutine to delay the attack animation state change and prevent the player from moving during the attack animation
     */
    IEnumerator MeleeAttackAnimDelay()
    {
        playerInput.actions.Disable(); // Disable player input during animation
        playerAnimator.SetBool("IsAttacking", true); // Set the animation to the "attacking" state
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePosition; // Stop player movement during animation
        yield return new WaitForSeconds(0.5f); // Return a 0.5 second delay
        playerAnimator.SetBool("IsAttacking", false); // Stop the attack animation
        playerInput.actions.Enable(); // Re-enable player input
        playerRigidBody.constraints = RigidbodyConstraints2D.None; // Re-enable player movement
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation; // Prevent player rotation
    }
}
