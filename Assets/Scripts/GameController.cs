using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{   
    
    public GameObject selectedObject;

    [SerializeField] private GameObject tokenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Remove! this is for testing
        GameObject newToken = Instantiate(tokenPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        TokenInfo tokenScript = newToken.GetComponent<TokenInfo>();
        tokenScript.tokenIcon = Resources.Load<Sprite>("Sprites/Monsters/103_Draft_Horse");
        tokenScript.tokenType = TokenInfo.TokenType.ally;
        tokenScript.weapons.Add(Resources.Load<WeaponClass>("Prefabs/Weapons/club"));
        tokenScript.tokenname = "Horse";
  
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
