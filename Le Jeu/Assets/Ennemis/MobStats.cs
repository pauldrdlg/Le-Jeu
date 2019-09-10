using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    public int hp, dmg;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        dmg = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getDmg()
    {
        return dmg;
    }

    public void dealDmg(GameObject player)
    {
        player.GetComponent<Stats>().takeDmg(dmg);
    }

    public void takeDmg(int eDmg)
    {
        hp -= eDmg;
        if (hp <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
            
        }
    }
}
