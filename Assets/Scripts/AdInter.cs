using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdInter : MonoBehaviour
{

    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
        RequestInterstitial();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    public void ShowInter()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }


}