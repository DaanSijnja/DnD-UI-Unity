using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInfoHandeler : MonoBehaviour
{
    [SerializeField] public Button arrowButton;
    

    private MenuHandelerScript MHS;
    private GameObject ObjectInfo;
    void Start()
    {   
        //Get the MenuHandelerScript for acces (MHS)
        MHS = this.GetComponent<MenuHandelerScript>();

        //Get the Object Info gameobject from MHS
        ObjectInfo = MHS.ObjectinfoCanvas;

        //check if the Object Info is active
        if(!MHS.ObjectInfoActive)
        {
            //Transform the Object Info to closed position
            ObjectInfo.transform.position = ObjectInfo.transform.position - new Vector3(-250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = ">";
        }
               
    }

    public void ArrowButton()
    {
        if(MHS.ObjectInfoActive)
        {
            ObjectInfo.transform.position = ObjectInfo.transform.position - new Vector3(250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = ">";
            MHS.ObjectInfoActive = false;
        }
        else
        {
            ObjectInfo.transform.position = ObjectInfo.transform.position - new Vector3(-250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = "<";
            MHS.ObjectInfoActive = true;
        }
        
    }
}
