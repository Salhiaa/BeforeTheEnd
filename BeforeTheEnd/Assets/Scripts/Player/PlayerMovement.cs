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

    [SerializeField] SpriteRenderer srPlayer, srOizo;

    private float inputX;
    private bool isGrounded;

    private bool inverted = false;

    private void Start()
    {
        transform.position = GameManager.instance.getSpawnPoint();
        //rb = GetComponent<Rigidbody2D>(); 
        //animPlayer = GetComponent<Animator>();
    }
    
    private void Update()
    {
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
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
            srOizo.flipX = true;
        }
        else if (inputX < 0)
        {
            srPlayer.flipX = false;
            srOizo.flipX = false;
            animPlayer.SetBool("isWalking", true);
        } else if (inputX == 0)
        {
            animPlayer.SetBool("isWalking", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, ground); // magic number whatever
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            GetComponent<SFXManager>().PlayJump();
        }
    }

    public void invertControls()
    {
        inverted = !inverted;
    }

}
