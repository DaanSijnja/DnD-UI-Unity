using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is3D = false;
    public GameObject gameController;
    Grabber _grabber_script;
    [SerializeField] float cameraSpeed;
    [SerializeField] float cameraZoomspeed;
    [SerializeField] GameObject lightObj;
    Quaternion rot;
    void Start()
    {
        _grabber_script = gameController.GetComponent<Grabber>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(is3D == false){

            float moveH = Input.GetAxis("Horizontal")*(cameraSpeed/100);
            float moveV = Input.GetAxis("Vertical")*(cameraSpeed/100);

            float deltaToPlane = transform.position.y - 0;

            float Zoom = Input.mouseScrollDelta.y*deltaToPlane*(cameraZoomspeed/100); 


            transform.Translate(moveH,moveV,Zoom);
            
            rot.eulerAngles = new Vector3 (90,-90,0);
            transform.rotation = rot;

            if(Input.GetKeyDown(KeyCode.F)){
                GameObject selectedObj = _grabber_script.selectedObject;
                Debug.Log(selectedObj);
                transform.position = new Vector3(selectedObj.transform.position.x, transform.position.y,selectedObj.transform.position.z);
            }
        }
        else{

        }

        


        lightObj.transform.position = transform.position;
    }
}
