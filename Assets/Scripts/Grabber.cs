//Grabber script
// A script that enables to grab players and enemies
// https://www.youtube.com/watch?v=uNCCS6DjebA The tutorial I used

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Grabber : MonoBehaviour
{   
    private GameObject draggedObject;
    public GameObject selectedObject;

    public int girdsize;
    // Update is called once per frame
    void Update()
    {   
        //Get Left mouse button input
        if(Input.GetMouseButton(0))
        {
            //*!* later add some check if the click isnt in one of the menus

            if(draggedObject == null){
                //If draggedObject is empty Cast a ray to see if it hits something
                RaycastHit hit = CastRay();

                if(hit.collider != null){
                    //Check if the raycast hit has a collider
                    if(!hit.collider.CompareTag("drag")){
                        //Return if the object does'nt have the 'drag' tag
                        return;
                    }

                    //Set the object to be dragged
                    draggedObject = hit.collider.gameObject;
                    //Set the selectect object to the dragged object
                    selectedObject = draggedObject;
                    //Make the curser invisable
                    Cursor.visible = false;
                }
                

            }
            else{
                //Move the dragobject position to the curser posistion
                DropAndDrag(0f);
            }
        }else{
            if(draggedObject != null){
                //place the object down
                DropAndDrag(0f);
                //*!* add snapping to a grid
                SnapToGrid();
                //make the curser visable again
                Cursor.visible = true;
                //make the dragged object empty
                draggedObject = null;
            }
            
        }

        
    }

    private void DropAndDrag(float objYpos){
    //Function for dragging the object
    // Input: Float => the height that the object has to be lifted

        //New vector3 position
        Vector3 position = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(draggedObject.transform.position).z
            );
        //Make the postion a world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        //Trasform the postion of the object
        draggedObject.transform.position = new Vector3(worldPosition.x,objYpos,worldPosition.z);
    }

    private void SnapToGrid(){
       float cXpos = draggedObject.transform.position.x;
       float cYpos = draggedObject.transform.position.y;
       float cZpos = draggedObject.transform.position.z;

    
        draggedObject.transform.position = new Vector3(Mathf.Round((cXpos/girdsize))*girdsize,cYpos,Mathf.Round((cZpos/girdsize))*girdsize);
    }

    private RaycastHit CastRay(){
    //Raycast function See the YT link for more info
        Vector3 screenMousePosFar  = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.farClipPlane
            );

        Vector3 screenMousePosNear  = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.nearClipPlane
            );

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;

    }
}
