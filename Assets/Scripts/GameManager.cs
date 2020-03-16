using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    private InterstitialAd interstitial;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3484489003477619/7074041944";
        #elif UNITY_IPHONE
                                string adUnitId = "ca-app-pub-3484489003477619/7074041944";
        #else
                                string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void LoadAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);

            LoadAd();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
