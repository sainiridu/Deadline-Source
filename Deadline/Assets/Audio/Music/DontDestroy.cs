using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update() {
        
        
         if(SceneManager.GetActiveScene().name == "LevelScene"){
             Destroy(this.gameObject);
         }
    }
}
