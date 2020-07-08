using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeEffect : MonoBehaviour
{

    private float firstTouch;
    public TextHandler textHandler;
    private float lastTouch;
    public CanvasGroup mainScreen;
    void Start()
    {
        firstTouch = 0;
        lastTouch = 0;
    }
    void Update()
    {
        if(mainScreen.interactable){
            //TouchInput();
            MouseInput();
        }
    }
    private void MouseInput(){
        Vector2 touchPosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            firstTouch = touchPosition.x;
        }
        if(Input.GetMouseButton(0)){
            //do nothing
        }
        if(Input.GetMouseButtonUp(0)){
            lastTouch = touchPosition.x;
            SwipeAction();
        }
    }
    public void TouchInput(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition =  Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began){
                firstTouch = touchPosition.x;
            }
            if(touch.phase == TouchPhase.Moved){
                //do nothing
            }
            if(touch.phase == TouchPhase.Ended){
                lastTouch = touchPosition.x;
                SwipeAction();
            }
        }
    }
    private void SwipeAction(){
        if (FindObjectOfType<Camera>().pixelHeight >  FindObjectOfType<Camera>().pixelWidth) 
        {
            if((firstTouch - lastTouch) > 3.5f){
                textHandler.ButtonNextChapter();
            }else if((firstTouch - lastTouch) < -3.5f){
                textHandler.ButtonPreviousChapter();
            }
        }
        else
        {
            if((firstTouch - lastTouch) > 7f){
                textHandler.ButtonNextChapter();
            }else if((firstTouch - lastTouch) < -7f){
                textHandler.ButtonPreviousChapter();
            }
        }
    }
}
