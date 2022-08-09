using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonMusic : MonoBehaviour
{
    private static SingletonMusic objectInstance = null;

    private void Awake() {
        if(objectInstance == null){
            objectInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start() {
        SceneCheck();
    }

    private void SceneCheck(){
        if(SceneManager.GetActiveScene().name == "Main Menu" && this != objectInstance){
            Destroy(this.gameObject);
        }
    }
}
