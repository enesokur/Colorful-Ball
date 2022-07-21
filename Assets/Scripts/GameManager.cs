using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameEnded = false;

    private bool _isCanvasElement = false;

    private UIManager _uIManagerScript;

    [SerializeField]
    private GameObject[] _uiElements;
    private void Start() {
        _uIManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update() {
        DetectUIElements();
        if(Input.touchCount > 0 && gameEnded == false && _isCanvasElement != true){
            gameStart = true;
            _uIManagerScript.CloseUI();
        }
    }

    private void DetectUIElements(){
        if(Input.touchCount > 0){
            if(_uiElements[0].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position) || 
                _uiElements[1].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position) ||
                _uiElements[2].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position)){
                _isCanvasElement = true;
            }
            else{
                _isCanvasElement = false;
            }
        }
    }
}
