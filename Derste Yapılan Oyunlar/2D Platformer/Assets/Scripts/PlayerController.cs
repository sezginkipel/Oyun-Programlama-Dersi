using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class PlayerController : MonoBehaviour
{
    // RigidBody2D component attached to the player. We will use this to apply physics to the player.
    private Rigidbody2D playerRigidbody;

    // The speed at which the player will walk. This is a serialized field so that we can change it in the inspector.
    [SerializeField] private float walkSpeed = 12312f;

    // The force at which the player will jump. 
    [SerializeField] private float jumpForce = 1500f;

    // A boolean to check if the player is on the ground. We will use this to check if the player can jump.
    private bool isGrounded = false;

    // A boolean to check if the player is facing right. We will use this to flip the player sprite.
    private bool isFacingRight = true;
    
    // TMP_Text component attached to the player. We will use this to display the coin count.
    public TMP_Text coinText;
    
    // The coin of the player. This is a serialized field so that we can change it in the inspector.
    [SerializeField] private int coins = 0;
    
    // TMP_Text component attached to the player. We will use this to display the keys.
    public TMP_Text keyText;
    
    // The number of keys the player has. This is a serialized field so that we can change it in the inspector.
    [SerializeField] private int collectedKeys = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        // Get the RigidBody2D component attached to the player. GetComponent<T>() is a generic method that returns the component of type T attached to the game object.
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }
    
    // Player Walk function that takes in a float parameter for the direction the player is walking in.
    private void Walk()
    {
        // Get the horizontal input from the player. This will be a value between -1 and 1.
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Create a new Vector2 with the horizontal input and 0 for the y component.
        Vector2 walk = new Vector2(horizontalInput, 0);
        
        // Apply the walk force to the player.
        playerRigidbody.AddForce(walk * (walkSpeed * Time.deltaTime));
        
        // If the player is walking right and is not facing right, flip the player sprite.
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        // If the player is walking left and is facing right, flip the player sprite.
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }
    
    // Player Flip function that flips the player sprite.
    private void Flip()
    {
        // Flip the boolean for isFacingRight.
        isFacingRight = !isFacingRight;
        
        // Get the local scale of the player.
        Vector3 localScale = transform.localScale;
        
        // Flip the x component of the local scale.
        localScale.x *= -1;
        
        // Set the local scale of the player to the new local scale.
        transform.localScale = localScale;
    }
    
    
    


    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jump = new Vector2(0, jumpForce);
            playerRigidbody.AddForce(new Vector2(0f, 0f));
            playerRigidbody.AddForce(jump, ForceMode2D.Force);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin_Default"))
        {
            print("Coin collected!");
            coins += 10;
            coinText.text = "Coins: " + coins;
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.CompareTag("Key_Default"))
        {
            print("Key collected!");
            collectedKeys++;
            keyText.text = "Keys: " + collectedKeys;
            Destroy(other.gameObject);
        }
    }
}