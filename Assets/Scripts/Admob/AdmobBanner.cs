using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobBanner : MonoBehaviour
{
# if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-5810037512419048/8509983476";
# elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
# else
    private string _adUnitId = "unused";
# endif

    private BannerView _bannerView;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });

        RequestConfiguration requestConfiguration = new RequestConfiguration();
        requestConfiguration.TestDeviceIds.Add("B9CF6CC5410F2E4AE26EF852C3597145");

        MobileAds.SetRequestConfiguration(requestConfiguration);

        CreateBannerView();
        LoadAd();
    }

    private void CreateBannerView()
    {
        if (_bannerView != null)
        {
            this.DestroyAd();
        }

        AdSize adaptiveSize =
            AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        _bannerView = new BannerView(_adUnitId, adaptiveSize, AdPosition.Bottom);
        _bannerView.OnBannerAdLoaded += this.HandleBannerAdLoaded;
    }

    private void LoadAd()
    {
        var adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }

    private void DestroyAd()
    {
        _bannerView.Destroy();
        _bannerView = null;
    }

    public void HandleBannerAdLoaded()
    {
        _bannerView.Show();
    }
}
