using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursunKontrol : MonoBehaviour
{
    float zaman = 0.7f;
    Rigidbody fizik;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        zaman -= Time.deltaTime;
        if (zaman<=0)
        {
            Destroy(gameObject);
        }
    }
  
}
