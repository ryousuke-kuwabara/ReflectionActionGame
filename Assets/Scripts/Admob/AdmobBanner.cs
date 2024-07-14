/*
 * using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobBanner : MonoBehaviour
{
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-8762130636007787/8190542983";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-8762130636007787/9312052962";
#else
    private string _adUnitId = "unused";
#endif

    private BannerView _bannerView;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });

        CreateBannerView();
        LoadAd();
    }

    private void CreateBannerView()
    {
        if (_bannerView != null)
        {
            DestroyAd();
        }

        AdSize adaptiveSize =
            AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        _bannerView = new BannerView(_adUnitId, adaptiveSize, AdPosition.Bottom);
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
}
*/