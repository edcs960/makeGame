using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    GameObject Ability;
    GameObject Weapon;

    private int shop;
    public void openshop(string shopname)
    {
        switch (shopname)
        {
            case "Ability" :
                Ability = GameObject.FindGameObjectWithTag("Abilityshop");
                shop = 1;
                Ability.SetActive(true);
                break;
            case "Weapon" :
                Weapon = GameObject.FindGameObjectWithTag("Weaponshop");
                shop = 2;
                Weapon.SetActive(true);
                break;        
            case "exit" :
                if(shop == 1)
                    Ability.SetActive(false);
                else if(shop == 2)
                    Weapon.SetActive(false);
                shop = 0;
                break;
        }
    }
}
