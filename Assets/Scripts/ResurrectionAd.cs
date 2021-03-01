using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class ResurrectionAd : MonoBehaviour
{
    private RewardedAd rewarded;
    
    private GameObject mainCamera;
    [SerializeField] private GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("music");

        mainCamera = GameObject.Find("Main Camera");

        //mainCamera.GetComponent<DoubleAd>().rewardedAd = new RewardedAd(mainCamera.GetComponent<DoubleInit>().adUnitId);
        rewarded = mainCamera.GetComponent<ResInit>().rewardedAd;


        // Called when an ad request has successfully loaded.
        rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewarded.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewarded.OnAdClosed += HandleRewardedAdClosed;
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("reklam yüklendi");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        Debug.Log("reklam yüklenemedi");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("reklam açýldý");
        
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("reklam gösterilirken bir hata oluþtu");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
        music.GetComponent<AudioSource>().Play();


        //MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("ödül alýndý");
        gameObject.GetComponent<GameOver>().OneChance();

    }

    public void CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif

        rewarded = new RewardedAd(adUnitId);

        rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        rewarded.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewarded.LoadAd(request);
    }


    public void UserChoseToWatchAd()
    {
        if (rewarded.IsLoaded())
        {
            rewarded.Show();
        }
    }
}
