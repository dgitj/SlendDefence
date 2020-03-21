using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float force = 20f;
    public AudioSource sound;
    private int shoottimer;



    // Update is called once per frame
    void Update()
    {
        shoottimer += 1;
        
        if (Input.GetMouseButtonDown(0) && shoottimer > 10)
        {
            GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
            shoottimer = 0;
            

            Rigidbody rb = go.GetComponent<Rigidbody>();


            rb.velocity = cam.transform.forward * force;
            sound.Play();


        }
        
    }
}
