using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    public float frequency = 0.5f;

    public Material m_material1;
    public Material m_material2;
    public Material m_material3;
    void Start()
    {
        m_material1 = GetComponent<MeshRenderer>().material;
        changematerial();

    }
    void changematerial()
    {
        StartCoroutine(SwitchOne());
    }

    IEnumerator SwitchOne()
    {
        yield return new WaitForSeconds(frequency);
        GetComponent<MeshRenderer>().material = m_material1;

        yield return new WaitForSeconds(frequency);
        GetComponent<MeshRenderer>().material = m_material2;

        yield return new WaitForSeconds(frequency);
        GetComponent<MeshRenderer>().material = m_material3;
        changematerial();
    }
}

    

