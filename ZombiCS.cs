using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiCS : MonoBehaviour
{
    MonsterManager Manager;
    public Animator anim;
    public GameObject player; 

    //private float StartTime = 0f;
    private float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        Manager.isSpawn = false;
        Manager.Health = 50;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // player 게임 오브젝트를 태그를 이용하여 찾음
        player.GetComponent<PlayerCS>().Monster = this.gameObject; // player 스크립트에 있는 monster 변수로 접근
    }

    public void GetDamage(int dmg)
    {
        Manager.Health -= dmg;
    }

    void ZombiDead(){
        anim.SetInteger("ZomAnimState",2); // 애니메이션의 ZomAnimState가 1일때 죽는 모션 실행
    }

    void ZombiAttack(){
        anim.SetInteger("ZomAnimState",1); // 애니메이션의 ZomAnimState가 1일때 죽는 모션 실행
    }
    
    void ZombiMove()
    {
        if(Manager.Direction == 1)
        {
           this.transform.position += new Vector3(moveSpeed * Time.deltaTime * -1,0,0);
        }
        else if(Manager.Direction == 2)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime,0,0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) // 여기는 쟤랑 만나면 자동으로 들어가져
    {
        if(other.gameObject.tag == "Monster")
        {
            ZombiAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Health > 0)
        {
            ZombiMove();
        }
        else if(Manager.Health <= 0)
        {
            ZombiDead();
            Destroy(this.gameObject,2f);
            player.GetComponent<PlayerCS>().Monster = null;
            Manager.isSpawn = true;
        }
    }
}
