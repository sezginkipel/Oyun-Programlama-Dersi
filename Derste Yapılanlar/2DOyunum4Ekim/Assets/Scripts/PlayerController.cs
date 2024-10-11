using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    public float _speed = 5.0f;
    public float _jumpForce = 5.0f;
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
}
