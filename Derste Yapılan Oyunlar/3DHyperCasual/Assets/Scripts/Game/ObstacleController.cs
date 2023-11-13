using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * (Time.deltaTime * 10));
    }
}
