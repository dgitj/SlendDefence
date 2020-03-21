using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCastle : MonoBehaviour
{

    private int damage;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            //damage
            print("Damage taken!");
            Destroy(other.gameObject);
            damage += 10;

        }
    }


            // Update is called once per frame
            void Update()
    {
        
    }
}
 