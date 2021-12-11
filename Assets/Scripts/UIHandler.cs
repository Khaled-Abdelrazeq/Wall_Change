using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{

    private void Start()
    {
        ShowAd();
    }
    

    public void onStartGameClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void onExitGameClicked()
    {
        Application.Quit();
    }

    public void onBackClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowAd()
    {
        AdsController.VideoAd();
    }
}
