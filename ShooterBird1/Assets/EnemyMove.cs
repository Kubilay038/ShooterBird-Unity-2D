using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
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
        transform.Translate(Vector3.up * hiz * Time.deltaTime);
        zaman -= Time.deltaTime;
        if (zaman <= 0)
        {
            Destroy(gameObject);
        }

    }
  
}
