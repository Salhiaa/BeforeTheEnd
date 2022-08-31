using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    public bool inverted;
    Rigidbody2D rb;
    private float inputX;

    // Animation
    [Header("Sprite")]
    [SerializeField] SpriteRenderer srPlayer;
    Animator animPlayer;
    int CrowLayer;
    int BaseLayer;

    // Input action map
    private InputActionMap playerMap;
    // Crow Powers
    //private CrowPowers crow;

    // Ground Check
    [Header("Ground Check")]
    [SerializeField] Transform groundCollision;
    [SerializeField] LayerMask ground;
    private bool isGrounded;



    private void Start()
    {
        // Set player position
        transform.position = GameManager.Instance.spawnPoint;

        // Get rigidBody
        rb = GetComponent<Rigidbody2D>(); 

        // Set animator and animation layers
        animPlayer = GetComponent<Animator>();
        CrowLayer = animPlayer.GetLayerIndex("Crow Layer");
        BaseLayer = animPlayer.GetLayerIndex("Base Layer");

        // ActionMaps
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerMap = playerInput.actions.FindActionMap("Player");
        playerMap.Enable();
        playerInput.actions.FindActionMap("Interaction").Enable();

        // Find crow
        //crow = GetComponentInChildren<CrowPowers>();
    }
    
    private void FixedUpdate()
    {
        // Set velocity
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        // Test if player touches ground
        isGrounded = Physics2D.OverlapCircle(groundCollision.position, .2f, ground); // magic number whatever
        
        // Launch jump after preparation animation
        if (srPlayer.sprite.name == "PPsaut0008" || srPlayer.sprite.name == "PPsautWCrow0008")
        {
            animPlayer.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            GetComponent<SFXManager>().PlayJump();
        }
        // Landing
        if (animPlayer.GetBool("isJumping") && rb.velocity.y < 0.01 && isGrounded)
        {
            animPlayer.SetBool("isJumping", false);
        }
    }

    // Player walk
    public void Move(InputAction.CallbackContext context)
    {
        // Move and check if movement is inverted
        if (!inverted)
            inputX = context.ReadValue<Vector2>().x;
        else
            inputX = -context.ReadValue<Vector2>().x;

        // Play and flip animation
        if (inputX > 0)
        {
            animPlayer.SetBool("isWalking", true); 
            srPlayer.flipX = true;
        }
        else if (inputX < 0)
        {
            animPlayer.SetBool("isWalking", true); 
            srPlayer.flipX = false;
        } else
        {
            animPlayer.SetBool("isWalking", false);
        }
    }

    // Player Jump
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            animPlayer.SetTrigger("takeOff");
        }
    }

    // Add/Remove crow
    public void switchAnimationLayer(bool hasCrow)
    {
        if (hasCrow)
        {
            animPlayer.SetLayerWeight(CrowLayer, 1);
            animPlayer.SetLayerWeight(BaseLayer, 0);
        }
        else
        {
            animPlayer.SetLayerWeight(CrowLayer, 0);
            animPlayer.SetLayerWeight(BaseLayer, 1);
        }
    }

    // Disable movement for dialogue
    public void switchToDialogue()
    {
        playerMap.Disable();
        //crow.ToggleVision();
    }
    // Re-enable movement
    public void switchToMovement()
    {
        playerMap.Enable();
        //crow.ToggleVision();
    }
}
