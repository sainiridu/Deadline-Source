using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }


    public void ControlsButton()
    {
        SceneManager.LoadScene("Controls");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackButtonSettings()
    {
        SceneManager.LoadScene("Settings");

    }
}
