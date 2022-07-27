using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollow : MonoBehaviour
{
    private GameObject _player;
    [SerializeField]
    private float _speed;
    private Rigidbody rb;

    private void Start() {
        _player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(_player != null){
            if(Vector3.Distance(_player.transform.position,this.transform.position) < 15f){
                Vector3 directionToPlayer = _player.transform.position - this.transform.position;
                rb.velocity = directionToPlayer.normalized*_speed;
            }
        }
    }
}
