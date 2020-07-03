using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHandler : MonoBehaviour
{
    public Text mainText;
    public Text ChapterText;
    public TextAsset[] textAsset;
    private int chapterNumber;
    public InputField chapterInputField;
    public InputField verseInputField;
    private string prevChapterInputField;
    private string prevVerseInputField;
    void Start()
    {
        prevChapterInputField = "1";
        prevVerseInputField = "1";
        chapterNumber = 0;
        string chapterName = textAsset[chapterNumber].name;
        ChapterText.text = chapterName.Split(' ')[0];
        mainText.text = textAsset[chapterNumber].text;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        SearchByChapter();
        SearchByVerse();
    }
    private void SearchByVerse(){
        if(verseInputField.text != prevVerseInputField && verseInputField.text != "")
        {
            prevVerseInputField = verseInputField.text;
            string samp = textAsset[chapterNumber].text;
            string[] splitString = samp.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            int index = Convert.ToInt32(verseInputField.text)-1;
            if(index < splitString.Length && index >= 0){
                string finalString = textAsset[chapterNumber].text;
                for(int i = 0; i < index;i++){
                    int j = finalString.IndexOf(System.Environment.NewLine);
                    finalString = finalString.Substring(j + System.Environment.NewLine.Length);
                }
                mainText.text = finalString;
                Vector3 resetPosition = mainText.transform.position;
                resetPosition.y = 0;
                mainText.transform.position = resetPosition;
            }else
            {
                mainText.text = "";
            }
        }
    }
    private void SearchByChapter(){
        if(chapterInputField.text != prevChapterInputField && chapterInputField.text != "")
        {
            prevChapterInputField = chapterInputField.text;
            int index = Convert.ToInt32(chapterInputField.text)-1;
            if(index < textAsset.Length && index >= 0){
                chapterNumber = index;
                UpdateText();
            }
            else{
                mainText.text = "";
            }
        }else if(chapterInputField.text != Convert.ToString(chapterNumber+1)){
            chapterInputField.text = Convert.ToString(chapterNumber+1);
            prevChapterInputField = chapterInputField.text;
        }
    }
    public void ButtonNextChapter(){
        if(chapterNumber < textAsset.Length - 1){
            chapterNumber++;
            UpdateText();
        }
    }
    public void ButtonPreviousChapter(){
        if(chapterNumber != 0){
            chapterNumber--;
            UpdateText();
        }
    }
    private void UpdateText(){
        Vector3 resetPosition = mainText.transform.position;
        resetPosition.y = 0;
        mainText.transform.position = resetPosition;
        verseInputField.text = "1";
        string chapterName = textAsset[chapterNumber].name;
        ChapterText.text = chapterName.Split(' ')[0];
        mainText.text = textAsset[chapterNumber].text;
    }
}
