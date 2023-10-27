using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10f;
    
    private Animator playerAnimator;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();

        if (transform.position.y <= -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    // Control player Movement with keyboard
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontalInput, 0, verticalInput);
        playerRigidbody.AddForce(playerMovement * (speed * Time.deltaTime));
    }
    
    // Control player Animation
    void Animate()
    {
        playerAnimator.SetBool("isRunning", playerRigidbody.velocity.z != 0);
        playerAnimator.SetBool("isFalling", playerRigidbody.velocity.y < -10);
    }
    
    
}
