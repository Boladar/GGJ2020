using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFlashlight : MonoBehaviour
{
    private Color colorRed = Color.red;
    private Vector3 target;
    public new Transform camera;
    
    void Update()
    {
       // target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 3, Camera.main.nearClipPlane);
        camera = Camera.main.GetComponent<Transform>();
        target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + camera.forward * 10);
        Debug.DrawLine(camera.position,target,colorRed);
        //Debug.Log("T" + target);    
    }
}
