/* Script for the tokens
 * Has all the info about a token 
 * Daan Sijnja
 * V1: Made the script
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
    [SerializeField] public int lvl;
    [SerializeField] public int size;
    [SerializeField] public int totalMovement;
    [SerializeField] public int currentMovement;
    [SerializeField] public bool isHidden; 
    [SerializeField] public bool isVisable;
    [SerializeField] public bool isDead;
    [SerializeField] public Texture2D icon;
    [SerializeField] public int lightsourceRange;
    [SerializeField] public List<WeaponClass> weapons;
    [SerializeField] public int ActiveWeapon;
    [SerializeField] public List<Conditions> conditions;
    [SerializeField] public List<Vector2> previousLocation;

    // Start is called before the first frame update
    void Start()
    {
        
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
    public void setIcon(Texture2D newIcon){
        icon = newIcon;
        //! Update the icon !
    }  
    public Texture2D getIcon(){
        return icon;
    }
    public void setTokenType(TokenType type){
        tokenType = type;
        //! Update Token Color !
    }
    public TokenType getTokenType(){
        return tokenType;
    }

    public void setSize(int newSize){
        size = newSize;
        //! Update size of the token
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
    public void setLvl(int newLvl){
        lvl = newLvl;
    }
    public int getLvl(){
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
