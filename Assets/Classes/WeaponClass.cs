/* Script for weapons
 * weapon class for info about weapons
 * Daan Sijnja
 * V1: Made the script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass : MonoBehaviour
{   
    public enum weaponTags {
        ammunition,
        finesse,
        heavy,
        light,
        loading,
        range,
        reach,
        special,
        thrown,
        twohanded,
        versatile
    }

    public enum damageType {
        bludgeoning,
        slashig,
        piercing
    }

    [SerializeField] public string weaponName;
    [SerializeField] public int minRange;
    [SerializeField] public int maxRange;
    [SerializeField] public damageType damagetype;
    [SerializeField] public List<weaponTags> weapontags;
    [SerializeField] public string damage;

    public void setWeaponName(string newWeaponName){
        weaponName = newWeaponName;
    }

    public string getWeaponName(){
        return weaponName;
    }

    public void setRange(int newMinRange, int newMaxRange){
        minRange = newMinRange;
        maxRange = newMaxRange;
    }

    public void setWeaponTag(weaponTags newWeapontag){
        weapontags.Add(newWeapontag);
    }

    public List<weaponTags> getWeaponTags(){
        return weapontags;
    }

    public void setDamageType(damageType newDamageType){
        damagetype = newDamageType;
    }

    public damageType getDamageType(){
        return damagetype;
    }

    public void setDamage(string newDamage){
        damage = newDamage;
    }

    public string getDamage(){
        return damage;
    }

}
