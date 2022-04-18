using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject arkaPlanBir;
    public GameObject arkaPlanİki;
    public float arkaPlanHiz = -1.5f;
    public GameObject Enemy;
    public GameObject Coin;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;

   

    Rigidbody2D fizikBir;
    Rigidbody2D fizikİki;

    float uzunluk = 0;

    public GameObject engel;
    public int kacAdetEngel = 5;
    GameObject[] engeller;

    float degisimZaman = 0;
    int sayac = 0;
    bool oyunBitti = true;
    

    void Start()
    {
        StartCoroutine(olustur());
        //StartCoroutine(coinolustur());
        fizikBir = arkaPlanBir.GetComponent<Rigidbody2D>();
        fizikİki = arkaPlanİki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(arkaPlanHiz, 0);
        fizikİki.velocity = new Vector2(arkaPlanHiz, 0);

        uzunluk = arkaPlanBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdetEngel];

        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaPlanHiz, 0);
        }
       
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(randomPos.x, Random.Range(-randomPos.y, randomPos.y), 0);
                Instantiate(Enemy, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            yield return new WaitForSeconds(donguBekleme);
        }
    }
    //IEnumerator coinolustur()
    //{
    //    yield return new WaitForSeconds(baslangicBekleme);
    //    while (true)
    //    {
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Vector3 vec = new Vector3(randomPos.x, Random.Range(-randomPos.y, randomPos.y), 0);
    //            Instantiate(Coin, vec, Quaternion.identity);
    //            yield return new WaitForSeconds(olusturmaBekleme);
    //        }
    //        yield return new WaitForSeconds(donguBekleme);
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        if (oyunBitti)
        {
            if (arkaPlanBir.transform.position.x <= -uzunluk)
            {
                arkaPlanBir.transform.position += new Vector3(uzunluk * 2f, 0);
            }
            if (arkaPlanİki.transform.position.x <= -uzunluk)
            {
                arkaPlanİki.transform.position += new Vector3(uzunluk * 2f, 0);
            }


            //----------------

            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f)
            {
                degisimZaman = 0;
                float Yeksenim = Random.Range(1.46f, 3.46f);
                engeller[sayac].transform.position = new Vector3(18, Yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;     //5 engel ürettikden sonra baştaki sona geçsin diye yazıldı bu kod
                }
            }
        }
       

    }
    public void oyunbitti()
    {
        for( int i = 0; i < engeller.Length; i++ )
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikİki.velocity = Vector3.zero;
        }
        oyunBitti = false;
    }
}
