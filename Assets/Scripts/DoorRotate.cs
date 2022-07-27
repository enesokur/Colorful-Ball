using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    private GameObject _leftDoor;
    private GameObject _rightDoor;
    private GameObject _pivot;
    [SerializeField]
    private float _leftDoorSpeed;
    [SerializeField]
    private float _rightDoorSpeed;
    private Vector3 _leftPivot;
    private Vector3 _rightPivot;
    private GameManager _gameManagerScript;

    private void Start() {
        _leftDoor = this.transform.GetChild(0).gameObject;
        _rightDoor = this.transform.GetChild(1).gameObject;
        _pivot = this.transform.GetChild(2).gameObject;
        _leftPivot = _pivot.transform.position;
        _rightPivot = new Vector3(-_pivot.transform.position.x,_pivot.transform.position.y,_pivot.transform.position.z);
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        if(_gameManagerScript.gameStart){
            _leftDoor.transform.RotateAround(_leftPivot,Vector3.up,_leftDoorSpeed*Time.fixedDeltaTime);
            _rightDoor.transform.RotateAround(_rightPivot,Vector3.up,_rightDoorSpeed*Time.fixedDeltaTime);
            if(_leftDoor.transform.localEulerAngles.y <= 300f){
                _leftDoorSpeed = -_leftDoorSpeed;
            }
            else if(_leftDoor.transform.localEulerAngles.y >= 359f){
                _leftDoorSpeed = -_leftDoorSpeed;
            }

            if(_rightDoor.transform.localEulerAngles.y >= 60f){
                _rightDoorSpeed = -_rightDoorSpeed;
            }
            else if(_rightDoor.transform.localEulerAngles.y <= 1f){
                _rightDoorSpeed = -_rightDoorSpeed;
            }
        }
    }
}
