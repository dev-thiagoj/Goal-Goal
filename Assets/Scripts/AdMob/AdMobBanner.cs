using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using System;
using Singleton;

public class AdMobBanner : Singleton<AdMobBanner>
{
    public string adUnitId = "ca-app-pub-9050671709974299~1041476470";

    private BannerView bannerView;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        RequestAndLoadBannerAd();
    }

    public void RequestAndLoadBannerAd()
    {
        Debug.Log("Requesting Banner Ad");

        // These ad units are configured to always serve test ads.

/*#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "unexpected_platform";
#else
        string adUnitId = "unexpected_platform";
#endif*/

        // Clean up banner before reusing
        if (bannerView != null) bannerView.Destroy();

        // Create a 320x50 banner at botton of the screen
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Add Event Handlers

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += HandleOnAdLoaded;

        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;

        // Called when an ad is shown.
        this.bannerView.OnAdOpening += HandleOnAdOpening;

        // Called when the ad is closed.
        this.bannerView.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request
        AdRequest request = new AdRequest.Builder().Build();

        // Load a banner ad
        bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Banner Ad Loaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Banner Ad Load Failed: "
                            + args);

        RequestAndLoadBannerAd();
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Banner Ad Opening");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Banner Ad Closed");
    }
}
