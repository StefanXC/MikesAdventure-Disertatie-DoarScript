using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour//, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{

    /*[SerializeField]string androidGameId;
    [SerializeField] string iosGameId;
    string gameId;
    [SerializeField] bool testMode = true;

    [SerializeField] Button RewardAdBTN;

    //[SerializeField] RewardAdBTNScript rewardedAdBTN;


    private void Awake()
    {
        if (Advertisement.isInitialized)
        {
            Debug.Log("Advertisment este initializat");
            //LoadInterstitialAd();
        }
        else
        { }
        
        
            InitializeAds();  
        
    }




    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosGameId : androidGameId;

        Advertisement.Initialize(gameId, testMode, this);

    }

    public void OnInitializationComplete()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Unity Ads incarcate complet. ");
        //LoadInterstitialAd();
        //rewardedAdBTN.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       // throw new System.NotImplementedException();
        Debug.Log($"Unity Ads nu s-au incarcat : {error.ToString()}-{message}");
    }
    
    //-------------------- R E C L A M A  F A R A  R E C O M P E N S A ----------------------------//
                                                                                                  //
    public void LoadInterstitialAd()                                                             //
    {                                                                                           //
        Advertisement.Load("Interstitial_Android",this);                                       //
    }                                                                                         //
                                                                                             //
    //-------------------- R E C L A M A  F A R A  R E C O M P E N S A ---------------------//



    //----------------------R E C L A M A  C U  R E C O M P E N S A ------------------------------//
                                                                                                 //
    public void LoadRewardedAd()                                                                //
    {                                                                                          //
        Advertisement.Load("Rewarded_Android",this);                                          //
    }                                                                                        //
                                                                                            //
                                                                                           //
    //----------------------R E C L A M A  C U  R E C O M P E N S A ----------------------//

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //throw new System.NotImplementedException();
        Advertisement.Show(placementId,this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
       // throw new System.NotImplementedException();
        Debug.Log($"Unity Ads nu s-au Afisat {placementId} : {error.ToString()}-{message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnUnityAdsShowStart");

        Time.timeScale = 0f;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {       
        Debug.Log("OnUnityAdsShowComplete"+ showCompletionState);
        if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            Debug.Log("Recompensa");
            FindObjectOfType<PlayerManager>().DubleazaBani();
            RewardAdBTN.interactable = false;
        }
        Time.timeScale = 1f;


        //throw new System.NotImplementedException();
        
    }
    */
}
