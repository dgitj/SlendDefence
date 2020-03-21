using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerView : MonoBehaviour
{
    public bool Seen;

	public bool PlayerSeen()
	{
	bool res;
	res = false;
	if(GetComponent<Renderer>().isVisible) //Check if Camera is turned towards the GameObject first
		{
   		RaycastHit hit;
   		// Calculate Ray direction
   		Vector3 direction = Camera.main.transform.position - transform.position;
   		if(Physics.SphereCast(transform.position, 45f, direction, out hit, Mathf.Infinity))
   			{
      		if(hit.collider.tag != "Player") //hit something else before the camera
      			{
         		//Debug.Log("Player seen!");
         		res = true;
      			}
   			}
		}
	return res;
	}

    void Start()
    {
    	Seen = false;
        
    }

    void Update()
    {
        if (Seen)
        {

        }
        else
        {
            Seen = PlayerSeen();
        }        
        }
}
