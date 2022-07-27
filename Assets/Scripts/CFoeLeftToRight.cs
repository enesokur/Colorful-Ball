using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFoeLeftToRight : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody rb;

    private GameManager _gameManagerScript;
    private void Start() {
        rb = this.GetComponent<Rigidbody>();
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        if(_gameManagerScript.gameStart == true){
            this.transform.Translate(new Vector3(_speed,0f,0f)*Time.fixedDeltaTime);
            if(this.transform.localPosition.x <= -3.2f){
                _speed = -_speed;
            }
            else if(this.transform.localPosition.x >=3.2f){
                _speed = -_speed;
            }
        }
    }
}
