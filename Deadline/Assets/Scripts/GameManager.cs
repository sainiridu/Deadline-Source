
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] public TextMeshProUGUI m_KillerName;
    [SerializeField] public TextMeshProUGUI m_KilledName;
    
    [SerializeField] public TextMeshProUGUI m_ScoreBoxP1;

    [SerializeField] public TextMeshProUGUI m_ScoreBoxP2;

    
    public int m_ScoreP1 = 0;
    public int m_ScoreP2 = 0;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // private void Update()
    // {
    //     if (time_Remaining > 0)
    //     {
    //         time_Remaining -= Time.deltaTime;

    //         m_Timer.text = time_Remaining.ToString();
    //     }

    //     else
    //     {
    //         Debug.Log("Time Ran Out");
    //     }
    // }

    public void UpdateKillFeed(string killerName, string killedName)
    {
        m_KillerName.text = killerName;
        m_KilledName.text = killedName;

        GameOverScreen.SetActive(true);


        m_ScoreBoxP1.text = m_ScoreP1.ToString();
        m_ScoreBoxP2.text = m_ScoreP2.ToString();

        StartCoroutine(HideKillInfo(GameOverScreen));

    }
    IEnumerator HideKillInfo(GameObject GameOverScreen)
    {

        yield return new WaitForSeconds(5f);
        GameOverScreen.SetActive(false);
    }



}
