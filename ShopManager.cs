using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject Ability;
    public GameObject Weapon;

    private int shop = 0;

    public void openshop(string shopname)
    {
        switch (shopname)
        {
            case "Ability" :
                shop = 1;
                Ability.SetActive(true); // 능력상점 활성화
                break;
            case "Weapon" :
                shop = 2;
                Weapon.SetActive(true); // 무기상점 활성화
                break;        
            case "exit" :
                if(shop == 1)
                    Ability.SetActive(false); // 능력상점 비활성솨
                else if(shop == 2)
                    Weapon.SetActive(false); // 무기상점 비활성솨
                shop = 0;
                break;
        }
    }
}
