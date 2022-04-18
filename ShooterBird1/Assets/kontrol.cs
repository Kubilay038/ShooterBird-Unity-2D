using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{
    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;

    Rigidbody2D fizik;

    int puan = 0;

    public Text puanText;

    bool oyunbitti = true;

    OyunKontrol oyunKontrol;

    AudioSource []sesler;

    int highScore = 0;

    public GameObject Kursun;

    float atesZamani = 0;

    public float atesGecenSure;

    public Transform KursunNeredenCiksin;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        highScore = PlayerPrefs.GetInt("enyuksekpuankayit");
    }

    
    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            Instantiate(Kursun, KursunNeredenCiksin.position,Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(0)&& oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
            sesler[0].Play();
        }

        Animasyon();
    }
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.1f)
        {
            kusAnimasyonZaman = 0;

            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puan")
        {
            puan++;
            puanText.text = "puan = " + puan;
            sesler[1].Play();


        }
        if (col.gameObject.tag=="engel")
        {
            oyunbitti = false;
            sesler[2].Play();
            oyunKontrol.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan>highScore)
            {
                highScore = puan;
                PlayerPrefs.SetInt("enyuksekpuankayit", highScore);
            }
            Invoke("anaMenuyeDon", 2);

        }

        if (col.gameObject.tag == "Enemy")
        {
            oyunbitti = false;
            sesler[3].Play();
            oyunKontrol.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan > highScore)
            {
                highScore = puan;
                PlayerPrefs.SetInt("enyuksekpuankayit", highScore);
            }
            Invoke("anaMenuyeDon",2);

        }

        if (col.gameObject.tag == "Coin")
        {
            puan++;
            puanText.text = "puan = " + puan;
            sesler[1].Play();


        }

    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("anamenu");

    }
}
