using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour
{
    public string myGameId = "5435942";
    public string adUnitId = "Banner_Android";
    public bool adStarted;
    private bool testMode = true;

    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    void Start()
    {
        Advertisement.Initialize(myGameId, testMode);
        Advertisement.Banner.SetPosition(bannerPosition);
    }

    void Update()
    {
        if(Advertisement.isInitialized && !adStarted)
        {
            Advertisement.Banner.Load(adUnitId);
            Advertisement.Banner.Show(adUnitId);
            adStarted = true;
        }
    }
}
