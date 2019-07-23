using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public GameObject hitBox;
    private int distance = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitBox.GetComponent<CircleCollider2D>().offset = new Vector2(distance,0);
            hitBox.tag = "Sword goes woosh";
            Collider2D[] ennemy = new Collider2D[5];
            hitBox.GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), ennemy);
            //ennemy[0].GetComponentInParent<Script>().damage(dmgValue);
        } else if (Input.GetKeyUp(KeyCode.F))
        {
            hitBox.GetComponent<CircleCollider2D>().offset = new Vector2(0, 0);
            hitBox.tag = "Sword goes woosh";
        }
    }
}
