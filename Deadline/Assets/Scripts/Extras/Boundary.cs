using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    public TimerScript time;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(" Col");
        //if(other.gameObject.CompareTag("Player"))
        time.EndGame();
    }



}
