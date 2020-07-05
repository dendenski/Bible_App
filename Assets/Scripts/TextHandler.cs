using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextHandler : MonoBehaviour
{
    public TextMeshProUGUI mainTextTMP;
    public string chapterText;
    public InputField chapterInputField;
    public InputField verseInputField;
    private string prevChapterInputField;
    private string prevVerseInputField;
    public BookDataHolder[] bookList;
    private int bookNumber;
    private int chapterNumber;
    private BookDropDownManager bookDropDownManager;
    private int chapterCount;
    void Start()
    {
        bookDropDownManager = GetComponent<BookDropDownManager>();
        prevChapterInputField = "1";
        prevVerseInputField = "1";
        chapterNumber = 0;
        bookNumber = bookDropDownManager.bookIndex;
        chapterText = bookList[bookDropDownManager.bookIndex].bookName;
        chapterCount = bookList[bookDropDownManager.bookIndex].chapterCount;
        mainTextTMP.text = GenerateChapter(0);
    }
    private string GenerateChapter(int index){
        string sampleText = "";
        for(int i = index; i < bookList[bookNumber].verseCount[chapterNumber]; i++){
            string test = "";
                if(index == i){
                    test = "<b><i>"+ bookList[bookNumber].verseString[chapterNumber,i] + "</i></b>";
                }else{
                    test = bookList[bookNumber].verseString[chapterNumber,i];
                }
            sampleText = sampleText + test +"\n";
        }
        return sampleText;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        
        if(bookDropDownManager.bookIndex < bookList.Length){
            SearchByBook();
            SearchByChapter();
            SearchByVerse();
        }else{
            if(mainTextTMP.text !=""){
                chapterText = "";
                mainTextTMP.text = "";
                chapterInputField.text = "1";
                verseInputField.text = "1";
            }
        }
    }
    private void SearchByBook(){
        if(bookList[bookDropDownManager.bookIndex].bookName != chapterText){
            chapterText = bookList[bookDropDownManager.bookIndex].bookName;
            chapterCount = bookList[bookDropDownManager.bookIndex].chapterCount;
            bookNumber = bookDropDownManager.bookIndex;
            chapterInputField.text = "1";
            UpdateText();
        }
    }
    private void SearchByChapter(){
        if((chapterInputField.text != prevChapterInputField)
        && (chapterInputField.text != ""))
        {
            prevChapterInputField = chapterInputField.text;
            int index = Convert.ToInt32(chapterInputField.text)-1;
            if(index < chapterCount && index >= 0){
                chapterNumber = index;
            }
            else{
                //mainTextTMP.text = "";
                chapterNumber = chapterCount-1;
                chapterInputField.text = ""+ chapterCount;
            }
            UpdateText();
        }
    }
    private void SearchByVerse(){
        if(verseInputField.text != prevVerseInputField && verseInputField.text != "")
        {
            prevVerseInputField = verseInputField.text;
            int index = Convert.ToInt32(verseInputField.text)-1;
            if(index < bookList[bookNumber].verseCount[chapterNumber] && index >= 0){
                mainTextTMP.text = GenerateChapter(index);
            }else
            {
                //mainTextTMP.text = "";
                mainTextTMP.text = GenerateChapter(bookList[bookNumber].verseCount[chapterNumber]-1);
                verseInputField.text = "" + (bookList[bookNumber].verseCount[chapterNumber]);
            }
                Vector3 resetPosition = mainTextTMP.transform.position;
                resetPosition.y = 0;
                mainTextTMP.transform.position = resetPosition;
        }
    }
    public void ButtonNextChapter(){
        if(chapterNumber < chapterCount - 1){
            chapterNumber++;
            chapterInputField.text = Convert.ToString(chapterNumber+1);
            prevChapterInputField = chapterInputField.text;
            UpdateText();
        }
    }
    public void ButtonPreviousChapter(){
        if(chapterNumber != 0){
            chapterNumber--;
            chapterInputField.text = Convert.ToString(chapterNumber+1);
            prevChapterInputField = chapterInputField.text;
            UpdateText();
        }
    }
    private void UpdateText(){
        Vector3 resetPosition = mainTextTMP.transform.position;
        resetPosition.y = 0;
        mainTextTMP.transform.position = resetPosition;
        verseInputField.text = "1";
        chapterText = bookList[bookNumber].bookName;
        mainTextTMP.text = GenerateChapter(0);
    }
}
