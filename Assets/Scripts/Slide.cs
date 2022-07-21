using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField]
    private Vector3 leftPos;
    [SerializeField]
    private Vector3 rightPos;

    private Vector3 tempLeftPos;
    private Vector3 tempRightPos;
    private bool reachedRightPos = false;
    private bool reachedLeftPos = true;
    [SerializeField]
    private GameObject _slideHand;
    [SerializeField]
    private GameObject _slideText;

    private void Start() {
        if(PlayerPrefs.HasKey("firstGame") == false){
            PlayerPrefs.SetInt("firstGame",1);
        }
        else{
            _slideHand.SetActive(false);
            _slideText.SetActive(false);
        }
        tempLeftPos = leftPos;
        tempRightPos = rightPos;
    }

    private void Update() {
        if(reachedLeftPos == true){
            this.transform.localPosition = Vector3.Lerp(leftPos,rightPos,1.5f*Time.deltaTime);
            leftPos = this.transform.localPosition;
        }
        else if(reachedRightPos == true){
            this.transform.localPosition = Vector3.Lerp(rightPos,leftPos,1.5f*Time.deltaTime);
            rightPos = this.transform.localPosition;
        }
        if(Vector3.Distance(this.transform.localPosition,rightPos) < 0.3f){
            reachedLeftPos = false;
            reachedRightPos = true;
            leftPos = tempLeftPos;
        }
        if(Vector3.Distance(this.transform.localPosition,leftPos) < 0.3f){
            reachedRightPos = false;
            reachedLeftPos = true;
            rightPos = tempRightPos;
        }
    }
}
