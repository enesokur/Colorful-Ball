using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _settingsButtonControl = 0; // 0 closed 1 open
    private Animator _settingsAnimator;
    private int _soundButtonControl = 1; // 0 closed 1 open
    [SerializeField]
    private GameObject _redlineObject;
    [SerializeField]
    private GameObject[] _uiElements;
    [SerializeField]
    private GameObject _restartButton;

    [SerializeField]
    private Image _levelBar;
    [SerializeField]
    private GameObject _finishScreen;
    

    private void Start() {
        _settingsAnimator = GameObject.Find("SettingsLayout").GetComponent<Animator>();
        if(PlayerPrefs.HasKey("audio") == false){
            PlayerPrefs.SetInt("audio",1);
        }
        else if(PlayerPrefs.GetInt("audio") == 0){
            _redlineObject.SetActive(true);
            AudioListener.volume = 0f;
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

    public void CloseUI(){
        for(int i = 0;i < _uiElements.Length;i++){
            _uiElements[i].SetActive(false);
        }
    }

    public void ShowRestartButton(){
        _restartButton.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateLevelBar(Vector3 playerPos,Vector3 finisPos){
        _levelBar.fillAmount = (playerPos.z-4.85f) / finisPos.z;
    }

    public void ShowFinishScreen(){
        _finishScreen.SetActive(true);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
