using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private float _speed;
    private Touch _touch;
    private CharacterController ch;
    [SerializeField]
    private float _pushForce;
    [SerializeField]
    public float forwardSpeed;
    [SerializeField]
    private  GameObject _breakablePlayerObject;
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _breakableFriendObject;
    private UIManager _uiManagerScript;
    private void Start() {
        ch = this.GetComponent<CharacterController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update() {
        if(_gameManager.gameStart == true){
            ch.Move(new Vector3(0f,0f,forwardSpeed)*Time.deltaTime);
        }
        if(Input.touchCount > 0){
            if(_gameManager.gameStart == true){
                _touch = Input.GetTouch(0);
                if(_touch.phase == TouchPhase.Moved){
                    ch.Move(new Vector3(_touch.deltaPosition.x*_speed,0f,_touch.deltaPosition.y*_speed)*Time.deltaTime);
                }
            }
        }
        this.transform.position = new Vector3(this.transform.position.x,0.641f,this.transform.position.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if(rb != null && !hit.transform.CompareTag("Obstacle")){
            rb.AddForce(hit.moveDirection*_pushForce);
        }
        if(hit.transform.CompareTag("Obstacle")){
            PlayerExplode();
        }
        if(hit.transform.CompareTag("Friend")){
            CubeFriendExplode(hit.transform.gameObject);
            _gameManager.CoinSpawn(hit.transform.position);
        }
    }

    private void PlayerExplode(){
        _gameManager.gameStart = false;
        _gameManager.gameEnded = true;
        _uiManagerScript.ShowRestartButton();
        var breakableBAll = Instantiate(_breakablePlayerObject,this.transform.position,Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(this.transform.position,1f);
        foreach(Collider collider in colliders){
            Rigidbody rbfound = collider.transform.gameObject.GetComponent<Rigidbody>();
            if(rbfound != null){
                rbfound.AddExplosionForce(100f,breakableBAll.transform.position,1f);
            }
        }
        CameraControl cameraScript = Camera.main.transform.GetComponent<CameraControl>();
        cameraScript.StartCameraShakeRoutine();
        Destroy(this.transform.gameObject);
    }

    private void CubeFriendExplode(GameObject hitFriend){
        var breakableCube =Instantiate(_breakableFriendObject,new Vector3(hitFriend.transform.position.x,0.216f,hitFriend.transform.position.z),Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(hitFriend.transform.position,0.5f);
        Destroy(breakableCube.transform.gameObject,3f);
        foreach(Collider collider in colliders){
            //Physics.IgnoreCollision(collider,this.GetComponent<Collider>());
            Rigidbody rbfriend = collider.transform.gameObject.GetComponent<Rigidbody>();
            if(rbfriend != null){
                rbfriend.AddExplosionForce(100f,breakableCube.transform.position,1f);
            }
        }
        Destroy(hitFriend.transform.gameObject);
    }
}
