using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    private InterstitialAd interstitial;
    private int personalizeAds;

    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();

        personalizeAds = PlayerPrefs.GetInt("personalizeAds");
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if (personalizeAds == 1)
        {
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }
        else
        {
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder()
                .AddExtra("npa", "1")
                .Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }
    }

    public void LoadAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        LoadAd();
    }
}
