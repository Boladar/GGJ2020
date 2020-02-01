using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFlashlight : MonoBehaviour
{
    private Color colorRed = Color.red;
    private Vector3 target;
    private float currentTime;

    [SerializeField]
    private float waitingTime;

    [SerializeField]
    private float pointingDownSpeed;
        
    public float smoothSpeed = 0.125f;
    public GameObject cube;
    public Transform camera;

    private Vector3 RandomCoord()
    {
        int randomNumber = Random.Range(1, 100);
        if(randomNumber == 1)
        {
            
            return new Vector3(target.x + Random.Range(-4f,4f), target.y + Random.Range(-4f, 8f));        
        }
        else
        {
            return target;
        }
    }
    private bool MouseIsMoving()
    {
        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse Y") < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        camera = Camera.main.GetComponent<Transform>();

        if(MouseIsMoving())
        {
            //Debug.Log("yes");
            target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + camera.forward * 10);           
            currentTime = waitingTime;
            
        }         
        if(!MouseIsMoving())
        {
            //Debug.Log("No");
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                Debug.Log("cur time 0s");
                cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y - (Time.deltaTime * pointingDownSpeed), cube.transform.position.z);
                //cube.transform.position = Vector3.Lerp(cube.transform.position, RandomCoord(), smoothSpeed);
            }
        }
       if(currentTime > 0)
       {
           Debug.Log("To mouse pos");
           cube.transform.position = Vector3.Lerp(cube.transform.position, target + RandomCoord() , smoothSpeed);
       }
        Debug.DrawLine(camera.position, target, colorRed);
        
        #region Comment  
        /*camera = Camera.main.GetComponent<Transform>();


        //Debug.Log("Mouse Position: " + Camera.main.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition));
        //Debug.Log("Mouse position without camera: " + Input.mousePosition);


        var targetPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        var smoothedPos = Vector3.Lerp(cube.transform.position, targetPos, smoothSpeed * Time.deltaTime);
       
        
       // Debug.DrawLine(camera.position,smoothedPos,colorRed);
       

        

           
        //Debug.Log("T" + target);    


        //target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 3, Camera.main.nearClipPlane);
        // target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(target.x, target.y * 0.1f * Time.deltaTime) + camera.forward * 10);

        //target += Vector3.up * 0.25f;
        //target.y += target.y * 0.1f * Time.deltaTime;
        //cube.transform.position += Vector3.up * 0.1f * Time.deltaTime;*/

        #endregion
    }

}
