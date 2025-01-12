using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ennemie : MonoBehaviour
{
    public Canvas canvas;

    public void Start()
    {
        canvas.gameObject.SetActive(false);


    }
    public void canvasennemieNO()
    {
        canvas.gameObject.SetActive(true);


    }




    public void canvasennemieSP()
    {
        canvas.gameObject.SetActive(true);

    }


    //public void hit()
    //{



    //}
}
