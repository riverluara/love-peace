using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public GameObject cameraFather;
    public Transform target;
    public float rotatespeed;
    public float scalespeed;
    public float min;
    public float max;
    public Transform obj;
    public float cameraSpeed;
    public float distance = 50f;
    public float height = 10f;
    float rotationDamping = 3f;

    private bool isLock = false;
    private Vector3 fCurrentRotation;
    private float currentSacale;
    private Vector3 currentRotation;
    private Vector3 lastMousePosition;

    public float desiredZRotationangle;
    public float currentZRotationangle;
    public float desiredXRotationAngle;
    public float desiredYRotationAngle;

    // Use this for initialization
    void Start()
    {
        //currentRotation = transform.eulerAngles;
        lastMousePosition = Input.mousePosition;
        //cameraFather.transform.position = obj.position + new Vector3(0, 5, -50);
        //cameraFather.transform.rotation = obj.rotation;

        desiredZRotationangle = obj.eulerAngles.z;
        currentZRotationangle = transform.eulerAngles.z;
        desiredXRotationAngle = obj.eulerAngles.x;
        desiredYRotationAngle = obj.eulerAngles.y;

        currentRotation.y = transform.eulerAngles.y;

        
        currentRotation.x = transform.eulerAngles.x;


        lastMousePosition = Input.mousePosition;

    }

    // Update is called once per frame
    void Update()
    {
        changeView();
    }



    void LateUpdate()
    {
        
    }

    private void changeView()
    {
        


        if (obj != null && Input.GetMouseButton(0) )
        {
            isLock = false;
        }
        else if (!Input.GetMouseButton(0))
        {
            isLock = true;
        }


        if (isLock)
        {
            camera_Follow();
            currentRotation.x = obj.eulerAngles.x;
            currentRotation.y = obj.eulerAngles.y;
            currentRotation.z = obj.eulerAngles.z;
        }
        else
        {
            camera_Rotate();

            
            
            /*transform.eulerAngles = obj.eulerAngles;

            currentRotation.x += mouseDelta.y * rotatespeed * Time.deltaTime;
            currentRotation.y += mouseDelta.x * rotatespeed * Time.deltaTime;

            currentRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentZRotationangle);

            transform.eulerAngles.x = currentRotation.x;*/


        }
        /*else if (!Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x <= Screen.width && Input.mousePosition.x >= Screen.width - 60)
            {
                cameraFather.transform.Translate(new Vector3(1, 0, 0) * cameraSpeed * Time.deltaTime);
            }
            else if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= 60)
            {
                cameraFather.transform.Translate(new Vector3(1, 0, 0) * -cameraSpeed * Time.deltaTime);
            }
            if (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 60)
            {
                cameraFather.transform.Translate(new Vector3(0, 0, 1) * -cameraSpeed * Time.deltaTime);
            }
            else if (Input.mousePosition.y >= Screen.height - 60 && Input.mousePosition.y <= Screen.height)
            {
                cameraFather.transform.Translate(new Vector3(0, 0, 1) * cameraSpeed * Time.deltaTime);
            }
        }*/



        //transform.LookAt (camerachild.position);

        
        //transform.position = target.position;
        //cameraFather.transform.eulerAngles = fCurrentRotation;
        //transform.eulerAngles = currentRotation;

    }

    private void camera_Rotate()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;

        if (!obj)
            return;

        float desiredYRotationAngle = obj.eulerAngles.y;
        float currentYRotationAngle = transform.eulerAngles.y;

        float desiredXRotationAngle = obj.eulerAngles.x;
        float currentXRotationAngle = transform.eulerAngles.x;

        float desiredZRotationangle = obj.eulerAngles.z;
        float currentZRotationangle = transform.eulerAngles.z;

        currentYRotationAngle = Mathf.LerpAngle(currentYRotationAngle, desiredYRotationAngle, rotationDamping * Time.deltaTime);

        currentXRotationAngle = Mathf.LerpAngle(currentXRotationAngle, desiredXRotationAngle, rotationDamping * Time.deltaTime);

        currentZRotationangle = Mathf.LerpAngle(currentZRotationangle, desiredZRotationangle, rotationDamping * Time.deltaTime);

        Quaternion currentRotation1 =  Quaternion.Euler(currentXRotationAngle, currentYRotationAngle, currentZRotationangle);

        transform.position = obj.position;
        transform.position -= currentRotation1 * Vector3.forward * distance;
        transform.position += transform.up * height;
        transform.LookAt(obj, obj.up);
        currentRotation.x += mouseDelta.y * rotatespeed * Time.deltaTime;
        currentRotation.y += mouseDelta.x * rotatespeed * Time.deltaTime;


        transform.eulerAngles = currentRotation;

        
    } 

    private void camera_Follow()
    {
        if (!obj)
            return;

        float desiredYRotationAngle = obj.eulerAngles.y;
        float currentYRotationAngle = transform.eulerAngles.y;

        float desiredXRotationAngle = obj.eulerAngles.x;
        float currentXRotationAngle = transform.eulerAngles.x;

        float desiredZRotationangle = obj.eulerAngles.z;
        float currentZRotationangle = transform.eulerAngles.z;

        currentYRotationAngle = Mathf.LerpAngle(currentYRotationAngle, desiredYRotationAngle, rotationDamping * Time.deltaTime);

        currentXRotationAngle = Mathf.LerpAngle(currentXRotationAngle, desiredXRotationAngle, rotationDamping * Time.deltaTime);

        currentZRotationangle = Mathf.LerpAngle(currentZRotationangle, desiredZRotationangle, rotationDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(currentXRotationAngle, currentYRotationAngle, currentZRotationangle);

        currentSacale = 0;
        currentSacale = Input.mouseScrollDelta.y * scalespeed * Time.deltaTime;
        if (currentSacale != 0)
            currentSacale = Mathf.Clamp(currentSacale, min, max);
        Debug.Log(currentSacale);
        

        transform.position = obj.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(obj, obj.up);

        transform.position += transform.up * height;
        
    }

}
