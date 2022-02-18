using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;
using Photon.Realtime;


public class PowerUpSpawn : MonoBehaviour
{

    public float frequency = 10f;
public GameObject Pow1;
public GameObject Pow2;
   

    
    void Start()
    {
        
        TurnOnOff();

    }
    void TurnOnOff()
    {
        StartCoroutine(SwitchOne());
    }

    IEnumerator SwitchOne()
    {
        yield return new WaitForSeconds(frequency);
       Pow1.SetActive(false);
       Pow2.SetActive(false);

       yield return new WaitForSeconds(frequency);
       Pow1.SetActive(true);
       Pow2.SetActive(true);
        TurnOnOff();
    }
}
