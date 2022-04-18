using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    bool oyunbitti = true;
    OyunKontrol oyunKontrol;
    AudioSource[] sesler;
    int puan;
    float zaman = 15f;
    Rigidbody2D fizik;
    public float hiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        transform.Translate(Vector3.left * hiz * Time.deltaTime);
        zaman -= Time.deltaTime;
        if (zaman <= 0)
        {
            Destroy(gameObject);
        }
    }
}
