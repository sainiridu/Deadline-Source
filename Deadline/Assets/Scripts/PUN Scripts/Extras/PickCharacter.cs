using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PickCharacter : MonoBehaviour
{
    public string PickedPlayer;
      public void PickPlayer1(){

    DontDestroyOnLoad(this.gameObject);      
          
    PickedPlayer = "Player1";

    
    SceneManager.LoadScene(3);   
    }


     public void PickPlayer2(){

    DontDestroyOnLoad(this.gameObject);      
          
    PickedPlayer = "Player2";

    
    SceneManager.LoadScene(3);   
    }
}
