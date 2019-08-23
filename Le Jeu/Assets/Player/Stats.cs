using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    GameObject Player;
    public Vector3 checkPoint;
    private double hydratation = 0;

    //pour le checkpoint
    public bool activated = false;
    private bool inRanged = false;

    void Start()
    {
        Player = gameObject.transform.gameObject;
        hydratation = 100;
        InvokeRepeating("Deshydratation",0f, 1.0f);
        //Total de 15 minutes avant la deshydratation du perso
    }

    void Update()
    {
        Debug.Log(checkPoint);
        if(hydratation <= 0)
        {
            if (activated == true)
            {
                transform.position = checkPoint;
                hydratation = 100;
            }
            else
            {
                //Default respawn
                transform.position = new Vector3(0, 4, 6f);
                hydratation = 100;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && inRanged == true)
        {
            activated = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            inRanged = true;
            if(activated == false)
            {
                checkPoint = collision.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            inRanged = false;
        }
    } 

    void Deshydratation()
    {
        //hydratation -= 0.12f;
        // pour faire un test de 10 sec // hydratation -= 10;
        hydratation -= 10;
    }
}
