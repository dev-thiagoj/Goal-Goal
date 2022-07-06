using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using System;

public class AdMobInterstitial : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        RequestAndLoadInterstitial();
    }

    private void RequestAndLoadInterstitial()
    {
        Debug.Log("Requesting Insterstitial ad.");

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9050671709974299~1041476470";
#elif UNITY_IPHONE
        string adUnitId = "unexpected_platform";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitial != null) interstitial.Destroy();

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAdMob()
    {
        if (interstitial != null && interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial ad is not ready yet.");
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Loaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Interstitial Ad Load Failed: "
                            + args);
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Opening");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Closed");
        GameManager.Instance.LoadPlayScene();
        GameManager.Instance.ChangeStateToPlay();
    }
}
