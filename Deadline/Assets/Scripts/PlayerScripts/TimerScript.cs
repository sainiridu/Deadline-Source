using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimerScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_Timer;

    [SerializeField] public TextMeshProUGUI endScreenWin;

    [SerializeField] public TextMeshProUGUI endScreenLoose;

    [SerializeField] public GameObject homeButton;
    [SerializeField] public GameObject endPanel;




    PhotonView view;
    public GameManager gameManager;

    public float time_Remaining = 15;



    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //PhotonNetwork.AutomaticallySyncScene();
        //UpdateTime();
        view.RPC("UpdateTimeRPC", RpcTarget.All);


    }

    void UpdateTime()
    {


    }

    [PunRPC]
    void UpdateTimeRPC()
    {
        if (time_Remaining > 0)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)

                time_Remaining -= Time.deltaTime / 2;

            m_Timer.text = time_Remaining.ToString("#");
        }

        else
        {
            Debug.Log("Time Ran Out");

            EndGame();
        }
    }



    public void EndGame()
    {
        if (gameManager.GetComponent<GameManager>().m_ScoreP1 > gameManager.GetComponent<GameManager>().m_ScoreP2)
        {
            endScreenWin.text = "BLUE WON THE MATCH";

            endScreenLoose.text = "RED LOST";

            homeButton.SetActive(true);

            endPanel.SetActive(true);

            Time.timeScale = 0.1f;
        }


        else if (gameManager.GetComponent<GameManager>().m_ScoreP2 > gameManager.GetComponent<GameManager>().m_ScoreP1)
        {
            endScreenWin.text = "RED WON THE MATCH";

            endScreenWin.text = "BLUE LOST";

            homeButton.SetActive(true);

            endPanel.SetActive(true);

            Time.timeScale = 0.1f;
        }

        else if (gameManager.GetComponent<GameManager>().m_ScoreP2 == gameManager.GetComponent<GameManager>().m_ScoreP1)
        {

            endScreenWin.text = "MATCH DRAW";

            endScreenWin.text = " ";

            homeButton.SetActive(true);

            endPanel.SetActive(true);

            Time.timeScale = 0.1f;
        }
    }
}
