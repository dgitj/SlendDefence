using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public System.Random rand = new System.Random(123);
    public GameObject theEnemy1;
    public GameObject theEnemy2;
    public GameObject theEnemy3;
    public GameObject theEnemy4;
    public int distance = 160;
    private int x;
    private int z;
    private int enemyCount;
    private int help;
    private int chosen_enemy;

    
    void Start()
    {
        StartCoroutine(EnemyDrop(1000000, 3f));
    }
    IEnumerator EnemyDrop(int number, float time_between)
    {
        while (true)
        {
            int[] help2 = { -distance, distance };
            //selects 0 or 1
            help = rand.Next(0, 2);

            if (help == 0)
            {
                x = rand.Next(-distance, distance);
                z = distance;
            }
            else
            {
                x = help2[rand.Next(0, 2)];
                z = rand.Next(0, distance);
            }

            chosen_enemy = rand.Next(0, 7);
            if (chosen_enemy == 0 || chosen_enemy == 5)
            {
                Instantiate(theEnemy1, new Vector3(x, 0f, z), Quaternion.identity);
            }
            if (chosen_enemy == 1 || chosen_enemy == 6)
            {
                Instantiate(theEnemy2, new Vector3(x, 0f, z), Quaternion.identity);
            }
            if (chosen_enemy == 2)
            {
                Instantiate(theEnemy3, new Vector3(x, 0f, z), Quaternion.identity);
            }
            else
            {
                Instantiate(theEnemy4, new Vector3(x, 0f, z), Quaternion.identity);
            }


            if (enemyCount == 5)
            {
                time_between = 3.75f;
            }
            if (time_between > 1f && (enemyCount % 10) == 0)
            {
                time_between -= 0.25f;
            }
            yield return new WaitForSeconds(time_between);
            enemyCount += 1;
        }
    }


}
