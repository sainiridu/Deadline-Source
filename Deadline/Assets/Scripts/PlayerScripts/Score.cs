using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private PlayerController m_StopMovement;

    [SerializeField] private GameObject colObj;

    GameManager gameManager;
    [SerializeField] public GameObject collided;


    public float health = 10;
    public bool isdead = false;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {

        if (health <= 0 && !isdead)
        {
            isdead = true;
            

        }
    }



}
