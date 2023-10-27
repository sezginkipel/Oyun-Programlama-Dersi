using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 650f;
    [SerializeField] private float jumpForce = 450f;
    
    private Animator playerAnimator;
    
    public List<CinemachineVirtualCamera> playerCams = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera currentCam = null;
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
        ChangeCam();
        Jump();

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
    
    // Control player Jump with Space key
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerRigidbody.velocity.y == 0)
        {
            playerRigidbody.AddForce(0, 0, 0);
            playerRigidbody.AddForce(Vector3.up * (jumpForce * Time.deltaTime), ForceMode.Impulse);
        }
    }
    
    // Control player Animation
    void Animate()
    {
        playerAnimator.SetBool("isRunning", playerRigidbody.velocity.z != 0);
        playerAnimator.SetBool("isFalling", playerRigidbody.velocity.y < -10);
    }
    
    
    // Change player camera when press C
    public void IsActiveCam(CinemachineVirtualCamera cam)
    {
        if (currentCam != null) // if currentCam is not null
        {
            currentCam.Priority = 0; // set currentCam priority to 0, so it will not be active
        }
        cam.Priority = 10; // set cam priority to 10, so it will be active
        currentCam = cam; // set currentCam to cam
    }
    
    // Change player camera when press C key
    void ChangeCam()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerCams.Count > 0)
            {
                int index = playerCams.IndexOf(currentCam);
                if (index == playerCams.Count - 1)
                {
                    IsActiveCam(playerCams[0]);
                }
                else
                {
                    IsActiveCam(playerCams[index + 1]);
                }
            }
        }
    }



}
