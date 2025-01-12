using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Characters : MonoBehaviour
{
    public void buttonwarrior()
    {
        PlayerPrefs.SetInt("warrior", 0);
        SceneManager.LoadScene("gameplay");
    }

    public void buttonmage()
    {
        PlayerPrefs.SetInt("warrior", 1);
        SceneManager.LoadScene("gameplay");

    }

    public void buttonassasin()
    {
        PlayerPrefs.SetInt("warrior", 2);
        SceneManager.LoadScene("gameplay");

    }

    public void buttontheif()
    {
        PlayerPrefs.SetInt("warrior", 3);
        SceneManager.LoadScene("gameplay");

    }

}
