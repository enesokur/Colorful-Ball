using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile;
public class MainMenuManager : MonoBehaviour
{
    private GameObject[,] levelStars2DArray = new GameObject[10,3];
    private GameObject canvasObject;
    [SerializeField]
    private AudioSource _backGroundMusic;
    private bool[] _isPlayable = new bool[10];
    [SerializeField]
    private GameObject[] levels = new GameObject[10];

    private void Start() {
        RuntimeManager.Init();
        canvasObject = GameObject.Find("Canvas");
        AssignStarReferences();
        setStars();
        setOpacityOfLevels();
        _isPlayable[0] = true;
        if(PlayerPrefs.GetInt("audio") == 0 && PlayerPrefs.HasKey("audio")){
            AudioListener.volume = 0f;
        }
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void AssignStarReferences(){
        for(int i=0;i<levelStars2DArray.GetLength(0);i++){
            for(int j=0;j<levelStars2DArray.GetLength(1);j++){
               levelStars2DArray[i,j] = canvasObject.transform.Find("Level"+(i+1)).transform.GetChild(j+1).gameObject;
            }
        }
    }
    private void setStars(){
        for(int i=0;i<levelStars2DArray.GetLength(0);i++){
            for(int j=0;j<PlayerPrefs.GetInt("level"+(i+1));j++){
                levelStars2DArray[i,j].SetActive(true);
                _isPlayable[i+1] = true;
            }
        }
    }

    public void LoadLevel(int index){
        if(_isPlayable[index-1] == true){
            SceneManager.LoadScene(index);
        }
    }

    public void setOpacityOfLevels(){
        for(int i=1;i<levels.Length;i++){
            if(_isPlayable[i] == true){
                var temp = levels[i].GetComponent<Image>().color;
                temp.a = 1f;
                levels[i].GetComponent<Image>().color = temp;
            }
        }
    }
}
