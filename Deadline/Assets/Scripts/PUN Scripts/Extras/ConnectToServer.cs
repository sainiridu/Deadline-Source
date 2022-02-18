using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to Servers....");
    }

    // Update is called once per frame
    public override void OnConnectedToMaster() {
        
        Debug.Log("Connected to "+ PhotonNetwork.CloudRegion +" servers");
  
        Debug.Log("Server IP: " + PhotonNetwork.ServerAddress);

  
        Debug.Log("joining default lobby ...");
        PhotonNetwork.JoinLobby();
        
    
}
public override void OnJoinedLobby(){
    SceneManager.LoadScene(1);
}

    
}
