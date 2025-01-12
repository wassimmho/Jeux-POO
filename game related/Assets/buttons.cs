using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("Story 1");

    }

    public void NextScene2()
    {
        SceneManager.LoadScene("story2");

    }

    public void NextScene3()
    {
        SceneManager.LoadScene("Choose caracter");

    }

}
