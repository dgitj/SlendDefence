﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	Rigidbody myBody;
	private float lifeTimer = 4f;
	private float timer;
	private bool hitSomething = false;
	
    // Start is called before the first frame update
    void Start()
    {
		myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);


    }

    // Update is called once per frame
    void Update()
    {

        myBody = GetComponent<Rigidbody>();

        //transform.rotation = Quaternion.LookRotation(myBody.velocity);

        timer += Time.deltaTime;
		if(timer >= lifeTimer){
			Destroy(gameObject);
		}
		if(!hitSomething){
 
            transform.rotation  = Quaternion.LookRotation(myBody.velocity);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
		if(collision.collider.tag != "Arrow")
		{
			hitSomething = true;
			Stick();
		}
	}
	
	
	private void Stick(){
       
        myBody.constraints = RigidbodyConstraints.FreezeAll;
		
	}
}
