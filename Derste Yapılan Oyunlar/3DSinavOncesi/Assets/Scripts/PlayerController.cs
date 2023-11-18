using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // Karakterin rigidBody komponentini tutacağımız değişken.
    public float speed = 1300f; // Karakterimizin ne kadar hızlı hareket edeceği.
    public float jumpPower = 950f; // Karakterin zıplama kuvveti.
    public int paramiktari = 0;
    public bool isGrounded = true; // Karakterimiz yerde mi değil mi bilgisini saklayacak değişkenimiz.
    
    // int -> Tam sayı bkz: 1,2,3,4,5
    // float -> Ondalıklı sayılar bkz: 1.34, 56.4, 78.32 gibi(decimal vb. kullanılabilir alternatif olarak)
    // bool -> True/False olarak değer alabilir, doğru-yanlış gibi kontroller kullanılabilir.
    // bool -> Bkz: isGrounded karakter yerdeyse true olur.
    // string -> Karakter dizisi, metin ifadelerini tutar.
    
    void Start() // Oyun başladığında 1 kere çalışır. 
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Rigidbody türündeki değişkenimizin içine...
        // Rigidbody komponentini atamış oluyoruz.
    }
    void Update() // Update her bir kare çiziminde çalışır. (FPS sayısı kadar çalışır.)
                  // FPS: Frame per Second / Saniyedeki kare sayısı.
    {

        Move(); // Move metodunu çağırdık. Çağrılmayan metod çalışmaz.
        Jump(); // 

    }
    void Move() // Metod - Fonksiyon
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(Vector3.forward * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(Vector3.back * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(Vector3.left * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(Vector3.right * (speed * Time.deltaTime));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Space tuşuna basıldıysa ve isGrounded true ise.
        {
            playerRigidbody.AddForce(Vector3.up * jumpPower); // Vector3.up ile y ekseninde 1 değeri alınır ve zıplama
            // kuvveti ile çarpılarak zıplaması sağlanır. y ekseni yükseklik.
            
            isGrounded = false; // Karakter zıpladığı zaman isGrounded false oluyor.
        }
    }
    
    void OnCollisionEnter(Collision carpilanNesne) // Çarpışma gerçekleştiği zaman çalışır.
    {
        if (carpilanNesne.gameObject.CompareTag("ground")) // Çarpışan objenin tagı Ground ise...
        {
            isGrounded = true; // isGrounded true olur. Yani karakter yerde. 
        }
    }
    
    // Yukarıdaki metodla ilgili bir soru hazıla
    // Eğer karakterimiz zıpladıktan sonra tekrar zıplamak isterse ne olur?

    

    private void OnTriggerEnter(Collider other) // Trigger ile çarpışma gerçekleştiği zaman çalışır.
    {
        if (other.gameObject.CompareTag("para"))
        {
            paramiktari++;
            Destroy(other.gameObject); // Çarpışan objeyi yok eder.
        }
    }
}
