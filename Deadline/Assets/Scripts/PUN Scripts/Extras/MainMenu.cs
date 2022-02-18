using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class MainMenu : MonoBehaviourPunCallbacks
{
    public TMP_InputField create_Input;
    public TMP_InputField join_Input;

    public string playerModel;


    public void CreateRoom()
    {
        DontDestroyOnLoad(this.gameObject);

        playerModel = "Player1";

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom(create_Input.text, roomOptions);
        Debug.Log("Room Created.");
    }


    public void JoinRoom()
    {
        DontDestroyOnLoad(this.gameObject);
        playerModel = "Player2";

        PhotonNetwork.JoinRoom(join_Input.text);

    }

    public void JoinRandomRoom()
    {
        DontDestroyOnLoad(this.gameObject);
        playerModel = "Player2";
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined");
        PhotonNetwork.LoadLevel(2);
    }


    public void SettingsButton()
    {   
        SceneManager.LoadScene("Settings");
        
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
