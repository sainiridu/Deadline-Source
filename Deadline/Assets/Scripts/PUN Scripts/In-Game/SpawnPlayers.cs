using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;

    public GameManager gameManager;

    public string character;
    
    PhotonView view;
    public float minX, minY, minZ, maxX, maxY, maxZ;

    private void Awake()
    {
        view = GetComponent<PhotonView>();

         character = GameObject.Find("MainMenu").gameObject.GetComponent<MainMenu>().playerModel;
        //view.RPC("GetManager", RpcTarget.All);
        
    }
    private void Start()
    {


            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            // Vector3 randomPosition = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y,spawnPoint.transform.position.z);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", character), randomPosition, Quaternion.identity);
       
}



    [PunRPC]

    void GetCharacter()
    {
       
    }


}