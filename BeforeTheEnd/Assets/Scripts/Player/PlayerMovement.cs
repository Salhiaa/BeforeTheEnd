using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animPlayer;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform groundPoint;
    [SerializeField] LayerMask ground;

    [SerializeField] SpriteRenderer srPlayer; //, srOizo;

    private float inputX;
    private bool isGrounded;
    //public bool crowRested;

    private bool inverted = false;

    private void Start()
    {
        transform.position = GameManager.instance.getSpawnPoint();
        //rb = GetComponent<Rigidbody2D>(); 
        //animPlayer = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        //print(GetComponent<SpriteRenderer>().sprite.name);
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, ground); // magic number whatever
        
        //Si l'animation de préparation au saut est complète
        if (GetComponent<SpriteRenderer>().sprite.name == "PPsaut0008" || GetComponent<SpriteRenderer>().sprite.name == "PPsautWCrow0008")
        {
            animPlayer.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            GetComponent<SFXManager>().PlayJump();
        }
        //Si le joueur vient d'atterrir
        if (animPlayer.GetBool("isJumping") && rb.velocity.y < 0.01 && isGrounded)
        {
            animPlayer.SetBool("isJumping", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!inverted)
            inputX = context.ReadValue<Vector2>().x;
        else
            inputX = -context.ReadValue<Vector2>().x;

        if (inputX > 0)
        {
            animPlayer.SetBool("isWalking", true); 
            srPlayer.flipX = true;
            
        }
        else if (inputX < 0)
        {
            animPlayer.SetBool("isWalking", true); 
            srPlayer.flipX = false;
        } else if (inputX == 0)
        {
            animPlayer.SetBool("isWalking", false);
        }
    }

    //Player Jump
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            animPlayer.SetTrigger("takeOff");
        }
    }

    //Invert controls (level 3 : shore)
    public void invertControls()
    {
        inverted = !inverted;
    }

    //Add/remove crow
    public void switchAnimationLayer(bool hasCrow)
    {
        if (hasCrow)
        {
            animPlayer.SetLayerWeight(animPlayer.GetLayerIndex("Crow Layer"), 1);
            animPlayer.SetLayerWeight(animPlayer.GetLayerIndex("Base Layer"), 0);
        }
        else
        {
            animPlayer.SetLayerWeight(animPlayer.GetLayerIndex("Crow Layer"), 0);
            animPlayer.SetLayerWeight(animPlayer.GetLayerIndex("Base Layer"), 1);
        }
    }
}
