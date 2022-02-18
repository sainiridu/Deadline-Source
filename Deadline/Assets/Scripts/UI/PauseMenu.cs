using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_Disable1;

    [SerializeField] private GameObject m_Disable2;

    [SerializeField] private GameObject m_Enable1;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_Enable1.activeSelf == false && m_Disable1.activeSelf == true && m_Disable2.activeSelf == true)
            {
                m_Enable1.SetActive(true);
                m_Disable1.SetActive(false);
                m_Disable2.SetActive(false);
            }

            else if (m_Enable1.activeSelf == true && m_Disable1.activeSelf == false && m_Disable2.activeSelf == false)
            {
                m_Enable1.SetActive(false);
                m_Disable1.SetActive(true);
                m_Disable2.SetActive(true);

            }
        }
    }
}
