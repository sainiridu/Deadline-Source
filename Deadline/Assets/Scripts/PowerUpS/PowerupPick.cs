using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPick : MonoBehaviour
{

    [SerializeField] public GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Jump"))
            {
                PlayParticle(this.transform.position);

                other.transform.root.Find("Player").gameObject.GetComponent<PlayerController>().canJump = true;
                this.gameObject.SetActive(false);
            }


            if (this.gameObject.CompareTag("Boost"))
            {
                PlayParticle(this.transform.position);


                other.transform.root.Find("Player").gameObject.GetComponent<PlayerController>().canBoost = true;
                this.gameObject.SetActive(false);
            }
        }

    }

    void PlayParticle(Vector3 pos)
    {

        GameObject Explosion = Instantiate(particle, pos, Quaternion.identity);
        Destroy(Explosion, 2f);
    }
}
