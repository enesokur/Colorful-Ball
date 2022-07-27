using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    private UIManager _uiManagerScript;
    private GameManager _gameManagerScript;
    [SerializeField]
    private TextMeshProUGUI _finishScreenCoin;
    
    private void Start() {
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.CompareTag("Player")){
            _uiManagerScript.ShowFinishScreen();
            _gameManagerScript.gameStart = false;
            _gameManagerScript.gameEnded = true;
            _finishScreenCoin.text = (_gameManagerScript.gold).ToString();
        } 
    }
}
