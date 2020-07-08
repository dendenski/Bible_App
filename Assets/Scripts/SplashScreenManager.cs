using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplashScreenManager : MonoBehaviour
{
    public CanvasGroup splashScreen;
    public CanvasGroup mainScreen;
    public CanvasGroup logoScreen;
    private bool fadeOutStarted;
    private bool SplashScreenWaitStarted;
    private bool logoSplashScreenWaitStarted;
    private bool fadeOutLogoStarted;
    void Start()
    {
        mainScreen.interactable = false;
        mainScreen.blocksRaycasts = false;

        fadeOutStarted = false;
        SplashScreenWaitStarted = false;

        fadeOutLogoStarted = false;
        logoSplashScreenWaitStarted = true;
    }
    void Update()
    {
        DevLogo();
        AppTitle();
    }
    private void AppTitle(){
        if(SplashScreenWaitStarted){
            StartCoroutine(SplashScreenWait());
            SplashScreenWaitStarted = false;
        }
        if(fadeOutStarted && splashScreen.alpha > 0){
            StartCoroutine(SplashScreenFade());
            fadeOutStarted = false;
        }
        if(splashScreen.alpha <= 0 && splashScreen.gameObject.activeInHierarchy){
            splashScreen.gameObject.SetActive(false);
            mainScreen.interactable = true;
            mainScreen.blocksRaycasts = true;
            splashScreen.interactable = false;
            splashScreen.blocksRaycasts = false;
            FindObjectOfType<GoogleMobileAdsDemoScript>().RequestBanner();
        }
    }
    public IEnumerator SplashScreenWait(){
        yield return new WaitForSeconds(2f);
        fadeOutStarted = true;
    }
    public IEnumerator SplashScreenFade(){
        yield return new WaitForSeconds(.1f);
        splashScreen.alpha -= .05f;
        fadeOutStarted = true;
    }

    private void DevLogo(){
        if(logoSplashScreenWaitStarted){
            StartCoroutine(SplashScreenLogoWait());
            logoSplashScreenWaitStarted = false;
        }
        if(fadeOutLogoStarted && logoScreen.alpha > 0){
            StartCoroutine(SplashScreenLogoFade());
            fadeOutLogoStarted = false;
        }
        if(logoScreen.alpha <= 0 && logoScreen.gameObject.activeInHierarchy){
            logoScreen.gameObject.SetActive(false);
            SplashScreenWaitStarted = true;
        }
    }


    public IEnumerator SplashScreenLogoWait(){
        yield return new WaitForSeconds(2f);
        fadeOutLogoStarted = true;
    }
    public IEnumerator SplashScreenLogoFade(){
        yield return new WaitForSeconds(.1f);
        logoScreen.alpha -= .05f;
        fadeOutLogoStarted = true;
    }
}
