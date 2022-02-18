using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class InputManager : MonoBehaviour
{

    private PlayerController controller;
    PhotonView view;

    private void Start() {
        view = GetComponent<PhotonView>();

        if(view.IsMine)
        {
            controller = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
        }
    }
    public void GoToHome()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1);
    }

    public void BoostPressed(){

        controller.BoostButton();
    }

    public void JumpPressed(){

        controller.JumpButton();
    }


}
