using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleToGrid : MonoBehaviour
{   
    Texture maptexture;
    float pixelHeight;
    float pixelWidth;
    float gridWidth;
    float gridHeigth;

    public float gridsize;

    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        maptexture = GetComponent<Renderer>().material.mainTexture;

        pixelHeight = maptexture.height;
        pixelWidth = maptexture.width;

        gridHeigth = pixelHeight/gridsize;
        gridWidth = pixelWidth/gridsize;
        float xscale = gridHeigth/10;
        float zscale = gridWidth/10;

        Debug.Log("Size is " + pixelHeight + " by " + pixelWidth);

        transform.localScale = new Vector3(xscale,1,zscale);
        transform.position = new Vector3((10*xscale)/2-0.5f,0,(10*zscale)/2-0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
