using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private int _settingsButtonControl = 0; // 0 closed 1 open
    private int _soundButtonControl; // 0 closed 1 open
    [SerializeField]
    private GameObject _redlineObject;
    private Animator _settingsAnimator;

    private void Start() {
        _settingsAnimator = GameObject.Find("SettingsLayout").GetComponent<Animator>();
        if(PlayerPrefs.HasKey("audio") == false){
            PlayerPrefs.SetInt("audio",1);
            _soundButtonControl = 1;
        }
        else if(PlayerPrefs.GetInt("audio") == 0){
            _redlineObject.SetActive(true);
            AudioListener.volume = 0f;
            _soundButtonControl = 0;
        }
        else if(PlayerPrefs.GetInt("audio") == 1){
            _soundButtonControl = 1;
        }
    }
    
    public void SettingsButtonControl(){
        if(_settingsButtonControl == 0){
            _settingsAnimator.SetTrigger("downClip");
            _settingsButtonControl = 1;
        }
        else if(_settingsButtonControl == 1){
            _settingsAnimator.SetTrigger("upClip");
            _settingsButtonControl = 0;
        }
    }

    public void SoundButtonControl(){
        Debug.Log(_soundButtonControl);
        if(_soundButtonControl == 0){
            _redlineObject.SetActive(false);
            _soundButtonControl = 1;
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("audio",1);
        }
        else if(_soundButtonControl == 1){
            _redlineObject.SetActive(true);
            _soundButtonControl = 0;
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("audio",0);
        }
    }
}
