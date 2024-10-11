using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    public TMP_Text scoreText;
    
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    
    [SerializeField] private float score = 0.0f;
    
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + score;
        }
    }
}
