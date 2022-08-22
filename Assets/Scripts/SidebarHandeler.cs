using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SidebarHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Button arrowButton;
    
    private MenuHandelerScript MHS;
    private GameObject Sidebar;
    void Start()
    {   


        //Get the MenuHandelerScript for acces (MHS)
        MHS = this.GetComponent<MenuHandelerScript>();

        //Get the Sidebar gameobject from MHS
        Sidebar = MHS.SidebarCanvas;

         
        //check if the sidebar is active
        if(!MHS.SidebarActive)
        {
            //Transform the Sidebar to closed position
            Sidebar.transform.position = Sidebar.transform.position - new Vector3(-250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = "<";
        }
               
        Debug.Log(Sidebar.transform.position);
    }

    public void ArrowButton()
    {
        if(MHS.SidebarActive)
        {
            Sidebar.transform.position = Sidebar.transform.position - new Vector3(-250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = "<";
            MHS.SidebarActive = false;
        }
        else
        {
            Sidebar.transform.position = Sidebar.transform.position - new Vector3(250,0,0);
            //change the ArrowButtons text to '<'
            arrowButton.GetComponentInChildren<TMP_Text>().text = ">";
            MHS.SidebarActive = true;
        }
        
    }
}
