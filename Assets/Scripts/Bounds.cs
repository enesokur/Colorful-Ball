using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField]
    private Transform _vectorLeft;
    [SerializeField]
    private Transform _vectorRight;
    [SerializeField]
    private Transform _vectorForward;
    [SerializeField]
    private Transform _vectorBack;
    private GameManager gameManager;
    private Player _player;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void LateUpdate() {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x,_vectorLeft.position.x,_vectorRight.position.x);
        position.z = Mathf.Clamp(position.z,_vectorBack.position.z,_vectorForward.position.z);
        this.transform.position = position;
        if(gameManager.gameStart == true){
            _vectorForward.transform.position += new Vector3(0f,0f,_player.forwardSpeed)*Time.deltaTime;
            _vectorBack.transform.position += new Vector3(0f,0f,_player.forwardSpeed)*Time.deltaTime;
        }
    }
}
