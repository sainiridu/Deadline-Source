using System.Collections;
using TMPro;
using UnityEngine;
using Photon.Pun;


public class ParticleCollisionDetection : MonoBehaviour
{

    public bool m_flag = false;

    [HideInInspector] public GameObject colObject;



    [SerializeField] public GameObject particle;

    [SerializeField] public AudioSource audioClip;

    [HideInInspector] public PlayerController controller;

    public Score score;
    PhotonView view;
    string killer_Name;
    string killed_Name;

    public bool hit = false;

    [HideInInspector] public GameObject gameManager;


    private void Start()
    {

        view = GetComponent<PhotonView>();
        controller = this.transform.parent.gameObject.GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").gameObject;

    }


    private void OnParticleCollision(GameObject other)
    {



        if (!score.isdead)
        {
            if (other == this.transform.parent.Find("GFX").gameObject)
            {

                score.isdead = true;


                PlayParticle(other.transform.position);

                PlaySound();


                //Debug.Log("Col");
                //other.transform.parent.Find("TrailFinal").gameObject.GetComponent<ParticleSystem>().Pause();
                this.gameObject.GetComponentInParent<PlayerController>().enabled = false;
                //colObject = other;

                    
                if (this.transform.parent.root.name == "Player1(Clone)")
                {
                    killer_Name = "B L U E";
                    killed_Name = "I T S E L F";
                }
                else if(this.transform.parent.root.name == "Player2(Clone)")
                 {
                    killer_Name = "R E D";
                    killed_Name = "I T S E L F";
                }


                //view.RPC("KillPlayerRPC", RpcTarget.All);
                //KillPlayerRPC();
                if (score.isdead)
                    view.RPC("UpdateKillFeedRPC", RpcTarget.All, killer_Name, killed_Name);

                StartCoroutine(KillOnce(other));
            }

            else if (other != this.transform.parent.Find("GFX").gameObject)
            {
                score.isdead = true;


                //Debug.Log("Col with enemy");
                PlayParticle(other.transform.position);
                //other.transform.parent.Find("TrailFinal").gameObject.GetComponent<ParticleSystem>().Pause();
                other.gameObject.GetComponentInParent<PlayerController>().enabled = false;
                //colObject = other;

                 if (this.transform.parent.root.name == "Player1(Clone)")
                {
                    killer_Name = "B L U E";
                }
                   
                else if(this.transform.parent.root.name == "Player2(Clone)")
                 {
                    killer_Name = "R E D";
                 }

                 if(other.transform.root.name == "Player1(Clone)")
                 {
                     killed_Name = "B L U E";
                 }

                 else if(other.transform.root.name == "Player2(Clone)")
                 {
                     killed_Name = "R E D";
                 }

                killer_Name = this.transform.root.name;
                killed_Name = other.transform.root.name;




                string incName = other.tag;
                Debug.Log(incName);


                view.RPC("UpdateScoreRPC", RpcTarget.All, incName);

                view.RPC("UpdateKillFeedRPC", RpcTarget.All, killer_Name, killed_Name);

                StartCoroutine(KillOnce(other));

            }


        }
    }


    void PlayParticle(Vector3 pos)
    {

        GameObject Explosion = Instantiate(particle, pos, Quaternion.identity);
        Destroy(Explosion, 2f);
    }

    IEnumerator KillOnce(GameObject other)
    {

        yield return new WaitForSeconds(5.5f);
        other.gameObject.GetComponentInParent<PlayerController>().enabled = true;
        score.isdead = false;
        score.health = 10f;


    }


    void PlaySound()
    {
        audioClip.Play();
    }

    


    [PunRPC]
    void KillPlayerRPC()
    {
        controller.Hit(10.0f);
    }

    [PunRPC]
    void UpdateKillFeedRPC(string killer, string killed)
    {

        if (score.isdead)
            gameManager.GetComponent<GameManager>().UpdateKillFeed(killer, killed);
    }

    [PunRPC]
    void UpdateScoreRPC(string player)
    {

        if (player == "P1")
        {
            gameManager.GetComponent<GameManager>().m_ScoreP2++;
            gameManager.GetComponent<GameManager>().m_ScoreP2 = gameManager.GetComponent<GameManager>().m_ScoreP2;

            Debug.Log(gameManager.GetComponent<GameManager>().m_ScoreP2);
        }
        else if (player == "P2")
        {
            gameManager.GetComponent<GameManager>().m_ScoreP1++;
            gameManager.GetComponent<GameManager>().m_ScoreP1 = gameManager.GetComponent<GameManager>().m_ScoreP1;

            Debug.Log(gameManager.GetComponent<GameManager>().m_ScoreP1);
        }
    }


}

