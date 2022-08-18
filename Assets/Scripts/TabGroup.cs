//script made with the help of this video https://www.youtube.com/watch?v=211t6r12XPQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public Color selectedColor;
    public Color hoverColor;
    public Color defaultColor;
    public List<GameObject> ObjectsToSwap;

    public void Subscribe(TabButton tabButton) 
    {
        if(tabButton == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(tabButton);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            button.background.color = hoverColor;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();

    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = selectedColor;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < ObjectsToSwap.Count; i++)
        {
            if(i == index)
            {
                ObjectsToSwap[i].SetActive(true);
            }
            else
            {
                ObjectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {   
            if(selectedTab != null && button == selectedTab){ continue; }
            button.background.color = defaultColor;

        }
    }
}
