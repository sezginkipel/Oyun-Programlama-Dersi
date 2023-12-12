using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElmaKontrol : MonoBehaviour
{
    public GameObject saglamElma;
    public GameObject curukElma;

    private void Start()
    {
        StartCoroutine(ElmaOlustur());
    }


    private IEnumerator ElmaOlustur()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int rastgeleSayi = UnityEngine.Random.Range(0, 2);
            Vector3 rastgeleKonum = new Vector3(UnityEngine.Random.Range(-7f, 6.3f), 6f, 1);

            Instantiate(rastgeleSayi == 0 ? saglamElma : curukElma, rastgeleKonum, Quaternion.Euler(0,0, Random.Range(0, 360)));
        }
    }
}