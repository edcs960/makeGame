using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiCS : MonoBehaviour
{
    public Animator anim;
    public GameObject player; 
    public int Health;

    public Transform Muzzle_Pos;
    public GameObject Hit_Muzzle;

    private float fDestroyTime = 13.0f;
    private float fTickTime;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // player 게임 오브젝트를 태그를 이용하여 찾음
        player.GetComponent<PlayerCS>().Monster = this.gameObject; // player 스크립트에 있는 monster 변수로 접근
    }

    void DamageEffect() // 데미지 이펙트 효과
    {
        GameObject muzzle = Instantiate(Hit_Muzzle,Muzzle_Pos.position,Quaternion.identity);
        Destroy(muzzle,1f);
    }

    public void GetDamage(int dmg)
    {
        Health -= dmg;
        if(Health>=0)
        {
            fTickTime += Time.deltaTime; // 딜레이 줄려고 하였으나 실패한것 같음..?
            if(fTickTime >= fDestroyTime)
                DamageEffect();
        }
        

        if(Health <= 0)
        {
            ZombiDead();
            Destroy(this.gameObject,1f);
            player.GetComponent<PlayerCS>().Monster = null;
        }
    }
    void ZombiDead(){
        anim.SetInteger("AnimState",1); // 애니메이션의 AnimState가 1일때 죽는 모션 실행
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
