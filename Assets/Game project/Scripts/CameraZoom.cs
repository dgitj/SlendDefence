using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public int zoom;
    public int normal = 60;
    public float smooth = 5;
    public GameObject crosshairZoom;
    public GameObject crosshairNormal;
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            crosshairNormal.SetActive(false);
            crosshairZoom.SetActive(true);
            
        }

        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
            crosshairZoom.SetActive(false);
            crosshairNormal.SetActive(true);
        }

    }
}