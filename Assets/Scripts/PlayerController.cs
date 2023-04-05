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

    Vector2 moveInput; // Stores the player movement vector
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    bool isAlive = true;
    
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        Walk();
    }

    void OnMove(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Walk()
    {
        // bool isWalking = Mathf.Abs(playerRigidBody.velocity) > Mathf.Epsilon;
        // Vector2 playerVelocity;
        //if (isWalking)
        //  {
        //playerVelocity = new Vector2(playerRigidBody.velocity.x, moveInput.y * moveSpeed);
        //playerRigidBody.AddForce(moveInput * moveSpeed, ForceMode2D.Impulse);
        float moveHorizontal = moveInput.x;
        float moveVertical = moveInput.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
            if(moveVertical > 0f)
            {
                
                playerAnimator.SetBool("IsUpPressed", true);
                playerAnimator.SetBool("IsFacingUp", true);
                playerAnimator.SetBool("IsDownPressed", false);
                playerAnimator.SetBool("IsFacingDown", false);
            }
            else if(moveVertical < 0f)
            {
                playerAnimator.SetBool("IsUpPressed", false);
                playerAnimator.SetBool("IsFacingUp", false);
                playerAnimator.SetBool("IsDownPressed", true);
                playerAnimator.SetBool("IsFacingDown", true);
            }
            else if(moveVertical == 0f && playerAnimator.GetBool("IsFacingDown"))
            {
                playerAnimator.SetBool("IsUpPressed", false);
                playerAnimator.SetBool("IsFacingUp", false);
                playerAnimator.SetBool("IsDownPressed", false);
               // playerAnimator.SetBool("IsFacingDown", false);
            }

        else if (moveVertical == 0f && playerAnimator.GetBool("IsFacingUp"))
        {
            playerAnimator.SetBool("IsUpPressed", false);
            //playerAnimator.SetBool("IsFacingUp", false);
            playerAnimator.SetBool("IsDownPressed", false);
            playerAnimator.SetBool("IsFacingDown", false);
        }
        // }
    }
}
