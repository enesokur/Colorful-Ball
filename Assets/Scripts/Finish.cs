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
    [SerializeField]
    private AudioClip _finishSound;
    private GameObject _player;
    
    private void Start() {
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player = GameObject.Find("Player");
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.CompareTag("Player")){
            AudioSource.PlayClipAtPoint(_finishSound,_player.transform.position+new Vector3(0f,10f,-10f));
            _uiManagerScript.ShowFinishScreen();
            _gameManagerScript.gameStart = false;
            _gameManagerScript.gameEnded = true;
            _finishScreenCoin.text = (_gameManagerScript.gold).ToString();
        } 
    }
}
