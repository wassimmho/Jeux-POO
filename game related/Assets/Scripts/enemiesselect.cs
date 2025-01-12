using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class select2 : MonoBehaviour
{
    public void buttonwarrior()
    {
        PlayerPrefs.SetInt("enemie", 0);

    }

    public void buttonmage()
    {
        PlayerPrefs.SetInt("enemie", 1);
    }

    public void buttonassasin()
    {
        PlayerPrefs.SetInt("enemie", 2);
    }

    public void buttontheif()
    {
        PlayerPrefs.SetInt("enemie", 3);
    }
}
