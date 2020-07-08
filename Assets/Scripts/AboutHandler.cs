using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutHandler : MonoBehaviour
{
    public GameObject about;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            FindObjectOfType<GoogleMobileAdsDemoScript>().destroyAds();
            Application.Quit();
        }   
    }

    public void AboutTheApp(){
        if(about.activeInHierarchy != true){
            about.SetActive(true);
        }else{
            about.SetActive(false);
        }
        Debug.Log("Version 1.0.0");
    }
    public void ExitApp(){
        FindObjectOfType<GoogleMobileAdsDemoScript>().destroyAds();
        Application.Quit();
    }
}
