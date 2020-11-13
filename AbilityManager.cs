using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static int money; // 재화

    public static int Str; // 공격력?
    public static int Dex; // 공격속도
    public static int Int; // 크리티컬 확률
    public static int Luk; // 흭득 재화 2배

    // Start is called before the first frame update
    void Start()
    {
        money = 1000;
        Str = 0;
        Dex = 0;
        Int = 0;
        Luk = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text[] mainCosts = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        mainCosts[2].text = money.ToString();
    }
}
