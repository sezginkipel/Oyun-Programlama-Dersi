using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Using ile kullanacağımız namespace'leri belirtiyoruz.

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    public TMP_Text scoreText;
    private Animator _playerAnimator;
    
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    private float _currentSpeed = 0;
    
    [SerializeField] private float score = 0.0f;
    [SerializeField] private int keyCount = 0;
    
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        _currentSpeed = _playerRigidbody.linearVelocity.x;
        _playerAnimator.SetFloat("playerSpeed", _currentSpeed);
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerRigidbody.AddForce(UnityEngine.Vector2.left * (_speed * Time.deltaTime));
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerRigidbody.AddForce(UnityEngine.Vector2.right * (_speed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _playerRigidbody.AddForce(UnityEngine.Vector2.up * (_jumpForce * Time.deltaTime));
        }
    }
    
    void RotatePlayer()
    {
        if (_currentSpeed > 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
        }else if (_currentSpeed < 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 180, 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + score;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            keyCount++;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (keyCount > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }else
            {
                Debug.Log("Bölümü bitirmek için anahtara ihtiyacın var!");
            }
        }
    }
}
