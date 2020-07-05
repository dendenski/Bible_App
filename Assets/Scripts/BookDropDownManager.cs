using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookDropDownManager : MonoBehaviour
{
    private string[] bookList= {
        "Genesis",
        "Exodus",
        "Leviticus",
        "Numbers",
        "Deuteronomy",
        "Joshua",
        "Judges",
        "Ruth",
        "1 Samuel",
        "2 Samuel",
        "1 Kings",
        "2 Kings",
        "1 Chronicles",
        "2 Chronicles",
        "Ezra",
        "Nehemiah",
        "Esther",
        "Job",
        "Psalms",
        "Proverbs",
        "Ecclesiastes",
        "The Song of Solomon",
        "Isaiah",
        "Jeremiah",
        "Lamentations",
        "Ezekiel",
        "Daniel",
        "Hosea",
        "Joel",
        "Amos",
        "Obadiah",
        "Jonah",
        "Micah",
        "Nahum",
        "Habakkuk",
        "Zephaniah",
        "Haggai",
        "Zechariah",
        "Malachi",
        "Matthew",
        "Mark",
        "Luke",
        "John",
        "Acts",
        "Romans",
        "1 Corinthians",
        "2 Corinthians",
        "Galatians",
        "Ephesians",
        "Philippians",
        "Colossians",
        "1 Thessalonians",
        "2 Thessalonians",
        "1 Timothy",
        "2 Timothy",
        "Titus",
        "Philemon",
        "Hebrews",
        "James",
        "1 Peter",
        "2 Peter",
        "1 John",
        "2 John",
        "3 John",
        "Jude",
        "Revelation"
    };
    public string SelectedBook;
    public int bookIndex;
    string previousText;
    Dropdown.OptionData newData;
    List<Dropdown.OptionData> dataList = new List<Dropdown.OptionData>();
    public Dropdown dropDown;
    int dataIndex;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.ClearOptions();
        for(int i= 0; i < bookList.Length;i++){
            newData = new Dropdown.OptionData();
            newData.text = bookList[i];
            dataList.Add(newData);
        }

        foreach (Dropdown.OptionData message in dataList)
        {
            dropDown.options.Add(message);
            dataIndex = dataList.Count - 1;
        }
        bookIndex = PlayerPrefs.GetInt ("bookIndex");
        previousText = dropDown.options[bookIndex].text;
        SelectedBook = dropDown.options[bookIndex].text;
        dropDown.value = bookIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if(previousText != dropDown.options[dropDown.value].text){
            previousText = dropDown.options[dropDown.value].text;
            SelectedBook = dropDown.options[dropDown.value].text;
            bookIndex = dropDown.value;
        }
    }
}
