using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class PlayerController : MonoBehaviour
{
    // RigidBody2D component attached to the player. We will use this to apply physics to the player.
    private Rigidbody2D playerRigidbody;

    // The speed at which the player will walk. This is a serialized field so that we can change it in the inspector.
    [SerializeField] private float walkSpeed = 750f;

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
    [SerializeField] private int keys = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        // Get the RigidBody2D component attached to the player. GetComponent<T>() is a generic method that returns the component of type T attached to the game object.
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk(0);
        Jump();
        
    }
    
    // Player Walk function that takes in a float parameter for the direction the player is walking in.
    private void Walk(float direction)
    {
        // If the player is facing right and the direction is less than 0, or the player is facing left and the direction is greater than 0, then flip the player sprite.
        if ((isFacingRight && direction < 0) || (!isFacingRight && direction > 0))
        {
            Flip();
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(Vector2.left * (walkSpeed * Time.deltaTime), ForceMode2D.Force);
            direction = -1;

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(Vector2.right * (walkSpeed * Time.deltaTime), ForceMode2D.Force);
            direction = 1;
        }
        else
        {
            direction = 0;
        }
    }
    
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
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
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}