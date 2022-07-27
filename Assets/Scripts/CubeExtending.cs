using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExtending : MonoBehaviour
{
    private float xScale;
    [SerializeField]
    private int _speed;
    private void Start() {
        xScale = this.transform.localScale.x;
    }
    private void FixedUpdate() {
        xScale += _speed*Time.fixedDeltaTime;
        this.transform.localScale = new Vector3(xScale,this.transform.localScale.y,this.transform.localScale.z);
        if(this.transform.localScale.x >= 8.5f){
            _speed = -_speed;
        }
        else if(this.transform.localScale.x <= 2f){
            _speed = -_speed;
        }
    }
}
