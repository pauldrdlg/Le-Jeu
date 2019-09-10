using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public GameObject hitBox;
    private int distance = 8;
    private int dmg = 10;

    List<GameObject> mob = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D range)
    {
        if (range.gameObject.tag == "Mob")
        {
            mob.Add(range.gameObject);
            //Debug.Log("Enemy in range");
        }
    }
    void OnTriggerExit2D(Collider2D range)
    {
        if (range.gameObject.tag == "Mob")
        {
            mob.Remove(range.gameObject);
            //Debug.Log("Enemy out of range");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitBox.GetComponent<CircleCollider2D>().offset = new Vector2(distance,0);
            hitBox.tag = "Sword goes woosh";
            Collider2D[] ennemy = new Collider2D[5];
            hitBox.GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), ennemy);
            foreach (GameObject target in mob)
            {
                target.GetComponent<MobStats>().takeDmg(dmg);
            }
            
        } else if (Input.GetKeyUp(KeyCode.F))
        {
            hitBox.GetComponent<CircleCollider2D>().offset = new Vector2(0, 0);
            hitBox.tag = "Sword goes woosh";
        }
    }
}
