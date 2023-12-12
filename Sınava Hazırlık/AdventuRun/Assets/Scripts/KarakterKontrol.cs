using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KarakterKontrol : MonoBehaviour
{
    public Rigidbody2D karakterRb;
    public float karakterHiz = 400f;
    public float karakterZiplamaGucu = 720f;

    public float paraMiktari = 0f;
    public float anahtarMiktari = 0f;
    
    public TMP_Text paraMetin;
    public TMP_Text anahtarMetin;
    

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        KarakteriYurut();
        Zipla();
    }

    void KarakteriYurut()
    {
        //Karakteri yürüt
        if (Input.GetKey(KeyCode.RightArrow))
        {
            karakterRb.AddForce(Vector2.right * (karakterHiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            karakterRb.AddForce(new Vector2(-karakterHiz * Time.deltaTime, 0));
        }
    }

    void Zipla()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            karakterRb.velocity =  Vector2.up * (karakterZiplamaGucu * Time.deltaTime);
        }
    }
    
    void OnTriggerEnter2D(Collider2D carpilanNesne)
    {
        if (carpilanNesne.gameObject.CompareTag("Para"))
        {
            paraMiktari++;
            paraMetin.text = "Para Miktarı: " + paraMiktari;
            Destroy(carpilanNesne.gameObject);
        }
        else if (carpilanNesne.gameObject.CompareTag("Engel"))
        {
            paraMiktari--;
            paraMetin.text = "Para Miktarı: " + paraMiktari;
            Debug.Log("Engele çarptınız! 1 para kaybettiniz!");
        }
        else if (carpilanNesne.gameObject.CompareTag("Anahtar"))
        {
            anahtarMiktari++;
            anahtarMetin.text = "Anahtar Miktarı: " + anahtarMiktari;
            Destroy(carpilanNesne.gameObject);
            Debug.Log("Anahtarı aldınız!");
        }
        else if (carpilanNesne.gameObject.CompareTag("Bitis"))
        {
            if (anahtarMiktari > 0)
            {
                print("Oyunu Kazandınız! Yeterli Anahtara sahipsin!");
            }
            else
            {
                print("Anahtara ihtiyacın var! Geri dön ve bir anahtar bul!");
            }
        }
    }
}