using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSafezone : MonoBehaviour
   
{
    public Animator animator;
    public Vector3 closest_position;
    public Goto Goto;
    public PlayerView playerview;
    GameObject closest = null;
    

    public GameObject FindClosestSafezone()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Safezone");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    //Walk towards the closest Gameobject, returned by the function "FindClosestSafezone"
    public void WalkToSafezone()
    {
        Vector3 closest_position = closest.transform.position;
        Goto.TargetPosition = closest_position;
        //animator.SetBool("shooting", true);
        Goto.speed = 10;
    }   

     public void ResetVisibility()
     {
        playerview.Seen = false;
        //animator.SetBool("notAttacked", true);
        
    }

     // Update is called once per frame
     void Update()
     {
        FindClosestSafezone();
        
     }

    void Start()
    {
        animator = GetComponent<Animator>();

    }

}
