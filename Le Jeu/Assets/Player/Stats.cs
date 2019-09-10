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
        //InvokeRepeating("Deshydratation",0f, 1.0f);
        //Total de 15 minutes avant la deshydratation du perso
    }

    void Update()
    {
        Debug.Log(checkPoint);
        if(hydratation <= 0)
        {
            transform.position = checkPoint;
            hydratation = 100;
        }

        if (Input.GetKey(KeyCode.O))
        {
            hydratation = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            if (Input.GetKey(KeyCode.Q))
            {
                checkPoint = collision.transform.position;
            }
        }

        if (collision.tag == "Mob")
        {
            takeDmg(collision.GetComponent<MobStats>().dmg);
        }
    }

    void Deshydratation()
    {
        //hydratation -= 0.12f;
        // pour faire un test de 10 sec // hydratation -= 10;
        hydratation -= 10;
    }

    public void takeDmg(int dmg)
    {
        hydratation -= dmg;
    }
}
