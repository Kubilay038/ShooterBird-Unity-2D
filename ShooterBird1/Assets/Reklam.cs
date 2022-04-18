using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour
{
    static Reklam reklamkontrol;
    void Start()
    {
        if (reklamkontrol==null)
        {
            DontDestroyOnLoad(gameObject);
            reklamkontrol = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
      MobileAds.Initialize(initStatus => { });
    }


  
    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9002302223126070/9108400658";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9002302223126070/4263321985";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    private void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }



    void Update()
    {
        //if (this.interstitial.IsLoaded())
        //{
        //    this.interstitial.Show();
        //}
    }
}
