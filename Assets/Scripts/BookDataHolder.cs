using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BookDataHolder : MonoBehaviour
{
    public string[,] verseString = new string[200,200];
    public TextAsset bookData;
    public string bookName;
    public int chapterCount;
    public int[] verseCount;
    void Awake()
    {
        bookName = gameObject.name;
        TextToStringArray();    // save verses in string array
        CountChapter();         // count chapter in the book
        CountVerse();           // count verse per chapter
    }
    void Start()
    {
        bookName = gameObject.name;
        TextToStringArray();    // save verses in string array
        CountChapter();         // count chapter in the book
        CountVerse();           // count verse per chapter
    }
    private void CountChapter(){
        for(int i = 0; i < 200 ; i++){
            chapterCount = i;
            if(verseString[i,0] == null){
                break;
            }
        }
    }
    private void CountVerse(){
        verseCount = new int[chapterCount];
        for(int j = 0;j < chapterCount;j++){
            for(int i = 0; i < 200 ; i++){
                verseCount[j] = i;
                if(verseString[j,i] == null){
                    break;
                }
            }
        }
    }
    private void TextToStringArray(){
        string[] textArray = bookData.text.Split("\n"[0]);
        foreach(string verse in textArray){
            string firstWord = verse.Substring(0, verse.IndexOf(" "));
            
            if(firstWord[firstWord.Length - 1] == ':'){
                //Debug.Log(firstWord);
                firstWord = firstWord.Remove(firstWord.Length - 1);
                //Debug.Log(firstWord);
            }
            int chapterNumber = Convert.ToInt32(firstWord.Substring(0, firstWord.IndexOf(":")))-1;
            int verseNumber = Convert.ToInt32(firstWord.Substring(firstWord.IndexOf(":") + 1))-1;
            verseString[chapterNumber,verseNumber] = verse;
        }
    }
}
