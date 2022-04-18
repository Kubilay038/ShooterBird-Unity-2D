using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anamenu : MonoBehaviour
{
    public Text puanText;
    public Text puan;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("enyuksekpuankayit");
        int puanGelen = PlayerPrefs.GetInt("puankayit");
        puanText.text = "High Score=" + highScore;
        puan.text = "Puan=" + puanGelen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene("level3");
    }
    public void exit()
    {
        Application.Quit();
    }
}
