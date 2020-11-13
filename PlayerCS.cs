using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCS : MonoBehaviour
{
    public Animator anim;
    public GameObject Monster;
    public int dmg;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Monster == null)
        {
            PlayerAnim();
        }
        else if(Monster != null)
        {
            PlayerAttackAnim();
        }
    }

    public void SetDamage()
    {
        Monster.GetComponent<ZombiCS>().GetDamage(dmg); // 플레이어가 몬스터에게 공격하여 데미지를 입히는 코드
    }

    void PlayerAnim()
    {
        anim.SetInteger("AnimState",0);
    }

    void PlayerAttackAnim()
    {
        anim.SetInteger("AnimState",1);
    }

    void PlayerMove()
    {
        
    }
    
}
