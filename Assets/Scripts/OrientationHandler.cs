using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OrientationHandler : MonoBehaviour
{ 
    public TextMeshProUGUI mainTextTMP;
    public GameObject chapterPanel;
    public GameObject scrollArea;
    public GameObject mainScreen;

    void Start()
    {
        
    }
    void Update()
    {
        if (FindObjectOfType<Camera>().pixelHeight >  FindObjectOfType<Camera>().pixelWidth) 
        {
            chapterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0,100f);
            chapterPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -150);
            scrollArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0,1520f);
            mainScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        }
        else
        {
            chapterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0,170f);
            chapterPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -130);
            scrollArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0,1470f);
            mainScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(-300,0);

        }
    }
}
