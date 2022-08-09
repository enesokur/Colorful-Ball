using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraControl : MonoBehaviour
{
    private Player _player;
    private GameManager _gameManager;
    public GameObject Stars;
    private Vector3 direction;

    private void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = Stars.transform.position - Camera.main.transform.position;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update() {
        if(_gameManager.gameStart){
            this.transform.position += new Vector3(0f,0f,_player.forwardSpeed)*Time.deltaTime;
        }
        FollowCamera();
    }
    IEnumerator CameraShakeRoutine(float duration,float magnitude){
        Vector3 originalPosition = this.transform.position;
        float elapsedTime = 0f;
        while(duration > elapsedTime){
            this.transform.position += new Vector3(Random.Range(-0.5f,0.5f)*magnitude,Random.Range(-0.5f,0.5f)*magnitude,0f);
            elapsedTime += Time.deltaTime;
            yield return null;
            this.transform.position = originalPosition;
        }
        this.transform.position = originalPosition;
    }

    public void StartCameraShakeRoutine(){
        StartCoroutine(CameraShakeRoutine(0.2f,0.6f));
    }
    private void FollowCamera(){
        Stars.transform.position = Camera.main.transform.position + direction;
    }
}
