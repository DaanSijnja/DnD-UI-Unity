/* Script for the tokens
 * Has all the info about a token 
 * Daan Sijnja
 * V1: Made the script
 * V2: added AC, nextHP and vision
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TokenInfo : MonoBehaviour
{
    // deze enums mischien apparte classes van maken
    public enum TokenType {
        player,
        enemy,
        ally
        };
    public enum Conditions {
        blinded,
        charmed,
        deafened,
        frightened,
        grappled,
        incapacitated,
        invisable, 
        paralyzed,
        petrified,
        poisened,
        prone,
        restrained,
        stunned,
        unconscious,
        exhaustionI,
        exhaustionII,
        exhaustionIII,
        exhaustionIV,
        exhaustionV,
        exhaustionVI,
        };

    //Input fields
    [SerializeField] public string tokenname;
    [SerializeField] public TokenType tokenType;
    [SerializeField] public float currentHP;
    [SerializeField] public float maxHP;
    [SerializeField] public float nextHP;
    [SerializeField] public float lvl;
    [SerializeField] public int AC;
    [SerializeField] public int vision;
    [SerializeField] public int initative;
    [SerializeField] public int size;
    [SerializeField] public int totalMovement;
    [SerializeField] public int currentMovement;
    [SerializeField] public bool isHidden; 
    [SerializeField] public bool isVisable;
    [SerializeField] public bool isDead;
    [SerializeField] public Sprite tokenIcon;
    [SerializeField] public int lightsourceRange;
    [SerializeField] public List<WeaponClass> weapons;
    [SerializeField] public int ActiveWeapon;
    [SerializeField] public List<Conditions> conditions;
    [SerializeField] public List<Vector2> previousLocation;


    //Mats
    [SerializeField] private Material playerMaterial;
    [SerializeField] private Material enemyMaterial;
    [SerializeField] private Material allyMaterial;
    //Token mesh
    private Renderer thisRenderer;
    //Token Childs
    private Transform Icon;
    // Start is called before the first frame update
    void Start()
    {   
        //get the renderer
        thisRenderer = this.GetComponent<Renderer>();

        float localyscale = transform.localScale.y;
        //setScale
        transform.localScale = new Vector3(size,localyscale,size);

        //get Child object Icon
        Icon = transform.GetChild(0);
        
        //set Icon
        if(tokenIcon != null){
            SpriteRenderer iconRenderer = Icon.GetComponent<SpriteRenderer>();
            iconRenderer.sprite = tokenIcon;
        }

        //use the right material for each type
        switch(tokenType)
        {
            case TokenType.player:
                thisRenderer.material = playerMaterial;
            break;

            case TokenType.enemy:
                thisRenderer.material = enemyMaterial;
            break;

            case TokenType.ally:
                thisRenderer.material = allyMaterial;
            break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//

//Info Functions

    /** HP Functions **/
    public void setMaxHP(float setHP){
        maxHP = setHP;
        currentHP = maxHP;
    }
    public void setCurrentHP(float setHP){
        currentHP = setHP;
        if(currentHP > maxHP){ currentHP = maxHP; }
    }
    public float getCurrentHP(){
        return currentHP;
    }  
    public float getMaxHP(){
        return maxHP;
    }
    public void setNextHP(int newNextHP){
       nextHP = newNextHP;
    } 
    public void setAC(int newAC){
       AC = newAC;
    }  
    public float getAC(){
        return AC;
    }
    public void setVision(int newVision){
       vision = newVision;
    } 
    public float getVision(){
        return vision;
    }

    /**visablity, hidden and death**/
    public void setHidden(bool i){
        isHidden = i;
    }
    public void setVisablity(bool i){
        isVisable = i;
    }  

    public void setDead(bool i){
        isDead = i;
    }
    /**name, icon, size and type**/
    public string getTokenName(){
        return tokenname;
    }
    public void setTokenName(string newName){
        tokenname = newName;
    }
    public void setIcon(Sprite newIcon){
        tokenIcon = newIcon;
        //! Update the icon !
    }  
    public Sprite getIcon(){
        return tokenIcon;
    }
    public void setTokenType(TokenType type){
        tokenType = type;
        switch(tokenType)
        {
            case TokenType.player:
                thisRenderer.material = playerMaterial;
            break;

            case TokenType.enemy:
                thisRenderer.material = enemyMaterial;
            break;

            case TokenType.ally:
                thisRenderer.material = allyMaterial;
            break;

        }
    }
    public TokenType getTokenType(){
        return tokenType;
    }

    public void setSize(int newSize){
        size = newSize;
        float localyscale = transform.localScale.y;
        transform.localScale = new Vector3(size, localyscale, size);
    }
    public int getSize(){
        return size;
    }

    /**Movement**/
    public void setMaxMovement(int setMovement){
        totalMovement = setMovement;
    }
    public int getMaxMovement(){
        return totalMovement;
    }
    public void setCurrentMovement(int setMovement)
    {
        currentMovement = setMovement;
    }
    public int getCurrentMovement(){
        return currentMovement;
    }

    /**Conditions**/
    public void AddCondition(Conditions condition){
        if(!conditions.Contains(condition)){
            conditions.Add(condition);
        }
    }
    public void removeCondition(Conditions condition){
       if(conditions.Contains(condition)){
            conditions.Remove(condition);
        } 
    }
    public List<Conditions> getConditions(){
        return conditions;
    }

    /**Lvl**/
    public void setLvl(float newLvl){
        lvl = newLvl;
    }
    public float getLvl(){
        return lvl;
    }

    /**Light Source**/
    public void setLightSource(int range){
        lightsourceRange = range;
    }
    public int getLightSource(){
        return lightsourceRange;
    }
}   
