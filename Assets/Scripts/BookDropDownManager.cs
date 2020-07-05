using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookDropDownManager : MonoBehaviour
{
    Dropdown.OptionData m_NewData;
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();
    public Dropdown m_Dropdown;
    int m_Index;
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
    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown.ClearOptions();
        for(int i= 0; i < bookList.Length;i++){
            m_NewData = new Dropdown.OptionData();
            m_NewData.text = bookList[i];
            m_Messages.Add(m_NewData);
        }

        foreach (Dropdown.OptionData message in m_Messages)
        {
            m_Dropdown.options.Add(message);
            m_Index = m_Messages.Count - 1;
        }
        previousText = m_Dropdown.options[0].text;
        SelectedBook = m_Dropdown.options[0].text;
        bookIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(previousText != m_Dropdown.options[m_Dropdown.value].text){
            previousText = m_Dropdown.options[m_Dropdown.value].text;
            SelectedBook = m_Dropdown.options[m_Dropdown.value].text;
            bookIndex = m_Dropdown.value;
        }
    }
}
