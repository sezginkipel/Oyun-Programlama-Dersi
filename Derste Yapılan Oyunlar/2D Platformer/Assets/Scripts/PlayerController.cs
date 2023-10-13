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
    
    // TMP_Text component attached to the player. We will use this to display the score.
    public TMP_Text scoreText;
    
    // The score of the player. This is a serialized field so that we can change it in the inspector.
    [SerializeField] private int score = 0;
    
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
        Walk(1);
        Jump();
        
    }
    
    // Player Walk function that takes in a float parameter for the direction the player is walking in.
    public void Walk(float direction)
    {
        // If the player is facing right and the direction is less than 0, or the player is facing left and the direction is greater than 0, then flip the player sprite.
        if ((isFacingRight && direction < 0) || (!isFacingRight && direction > 0))
        {
            Flip();
        }

        // Set the velocity of the player to the direction multiplied by the walk speed.
        playerRigidbody.velocity = new Vector2(direction * walkSpeed * Time.deltaTime, playerRigidbody.velocity.y);
    }
    
    // Flip function that flips the player sprite.
    private void Flip()
    {
        // Set the isFacingRight boolean to the opposite of what it was.
        isFacingRight = !isFacingRight;

        // Get the local scale of the player. This is a Vector3 that contains the x, y, and z scale of the player.
        Vector3 playerScale = transform.localScale;

        // Set the x scale of the player to the opposite of what it was.
        playerScale.x *= -1;

        // Set the local scale of the player to the new player scale.
        transform.localScale = playerScale;
    }
    
    // Player Jump function that makes the player jump.
    public void Jump()
    {
        // If the player is on the ground, then add a force to the player in the up direction.
        if (isGrounded)
        {
            playerRigidbody.AddForce(Vector2.up * (jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
    
    // OnCollisionEnter2D is called when the player collides with another collider.
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with the ground, then set the isGrounded boolean to true.
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    // OnCollisionExit2D is called when the player stops colliding with another collider.
    private void OnCollisionExit2D(Collision2D other)
    {
        // If the player stops colliding with the ground, then set the isGrounded boolean to false.
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    // OnTriggerEnter2D is called when the player enters a trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters a trigger collider with the tag "Coin", then destroy the coin.
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}