using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    int zoom = 40;
    int normal = 60;
    float smooth = 2;
    public Camera cam;
    private bool isZoomed = false;
         
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetComponent<Camera>().fieldOfView == 60)
            {
                isZoomed = false;
            }
            if (GetComponent<Camera>().fieldOfView == 40)
            {
                isZoomed = true;
            }

            if (!isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, smooth);
            }
             
            if (isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, smooth);
                
            }
        }
    }
}
