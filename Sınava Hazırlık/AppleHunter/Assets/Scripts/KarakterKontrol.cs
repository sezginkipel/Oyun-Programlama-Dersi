using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*
  
        public float hiz = 3f;
        public float toplananElmaSayisi = 0;
        public float toplamParaMiktari = 0;
        public float tasinabilecekElmaSayisi = 5;
    
        public TMP_Text paraMetin;
        public TMP_Text elmaMetin;

    
    */
    
    
    
    
    
    
    

    /*
    void KarakterHareket()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, (hiz * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, (-hiz * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((-hiz * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((hiz * Time.deltaTime), 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D carpilanNesne)
    {
        if (carpilanNesne.gameObject.CompareTag("Elma_Saglam"))
        {
            if (toplananElmaSayisi < tasinabilecekElmaSayisi)
            {
                toplananElmaSayisi++;
                elmaMetin.text = "Elma: " + toplananElmaSayisi;
                Destroy(carpilanNesne.gameObject);
            }
            else
            {
                Destroy(carpilanNesne.gameObject);
            }
        }
        else if (carpilanNesne.gameObject.CompareTag("Elma_Curuk"))
        {
            toplamParaMiktari -= 5;
            paraMetin.text = "Para: " + toplamParaMiktari;
            Destroy(carpilanNesne.gameObject);
        }
        else if (carpilanNesne.gameObject.CompareTag("Pazar"))
        {
            toplamParaMiktari += toplananElmaSayisi * 5;
            toplananElmaSayisi = 0;
            paraMetin.text = "Para: " + toplamParaMiktari;
            elmaMetin.text = "Elma: " + toplananElmaSayisi;
        }
    }*/
}