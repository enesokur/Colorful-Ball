using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameEnded = false;

    private bool _isCanvasElement = false;

    private UIManager _uIManagerScript;

    [SerializeField]
    private GameObject[] _uiElements;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private TextMeshProUGUI _coinText;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _finishPosition;
    public int gold;
    private IDictionary<int, int> numOfWhiteCubesEachScene;
    public int numOfBrokenWhiteCubes;
    [SerializeField]
    private GameObject _stars;



    private void Start() {
        numOfBrokenWhiteCubes = 0;
        _uIManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
        numOfWhiteCubesEachScene = new Dictionary<int, int>(){
            {0,61},
            {1,111},
            {2,54},
            {3,88},
            {4,93},
            {5,56},
            {6,67},
            {7,64},
            {8,23},
            {9,44},
        };
    }

    private void Update() {
        DetectUIElements();
        if(Input.touchCount > 0 && gameEnded == false && _isCanvasElement != true){
            gameStart = true;
            _uIManagerScript.CloseUI();
        }
        if(gameStart == true){
            _uIManagerScript.UpdateLevelBar(_player.transform.position,_finishPosition.transform.position);
        }
    }

    private void DetectUIElements(){
        /*if(Input.touchCount > 0){
           if(_uiElements[0].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position) || 
                _uiElements[1].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position) ||
                _uiElements[2].GetComponent<BoxCollider2D>().OverlapPoint(Input.GetTouch(0).position)){
                _isCanvasElement = true;
            }
            else{
                _isCanvasElement = false;
            }
        }*/
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > 2*Screen.width/8 && touch.position.x < 6*(Screen.width/8)){
                _isCanvasElement = false;
            }
            else{
                _isCanvasElement = true;
            }
        }
    }

    public void CoinSpawn(Vector3 spawnPos){
        var coinObject = Instantiate(_coin,spawnPos + new Vector3(0f,2.5f,0f),Quaternion.Euler(140f,0f,0f));
        coinObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,200f,0f));
        Destroy(coinObject,0.5f);
        gold = (int.Parse(_coinText.text) + 5);
        _coinText.text = gold.ToString(); 
    }

    public void LevelStarManager(){
        starFxController starscript = _stars.GetComponent<starFxController>();
        int numOfWhiteCube = numOfWhiteCubesEachScene[SceneManager.GetActiveScene().buildIndex];
        if(numOfBrokenWhiteCubes > 0.6*numOfWhiteCube){
            starscript.ea = 3;
        }
        else if(numOfBrokenWhiteCubes > 0.4*numOfWhiteCube){
            starscript.ea = 2;
        }
        else{
            starscript.ea = 1;
        }
        starscript.enabled = true;    
    }
}
