using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;


public class AdsController : MonoBehaviour
{
    //private string storeID = "4257029";
    private string storeID = "4257025";
    private static string videoAd = "video";

    private void Start()
    {
        Monetization.Initialize(storeID, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VideoAd();
        }
    }

    public static void VideoAd()
    {
        if (Monetization.IsReady(videoAd))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAd) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }
    }
}
