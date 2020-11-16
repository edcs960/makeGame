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
        Manager.coll = 0;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // player 게임 오브젝트를 태그를 이용하여 찾음
        player.GetComponent<PlayerCS>().Monster = this.gameObject; // player 스크립트에 있는 monster 변수로 접근
    }

    public void GetDamage(int dmg) // 데미지 관리 함수
    {
        Manager.Health -= dmg; 
    }
    void ZombiDead(){
        anim.SetInteger("ZomAnimState",2); // 애니메이션의 ZomAnimState가 2일때 죽는 모션 실행
    }

    void ZombiAttack(){
        anim.SetInteger("ZomAnimState",1); // 애니메이션의 ZomAnimState가 1일때 공격하는 모션 실행
    }
    
    void ZombiMove()
    {
        if(Manager.Direction == 1)
        {
           this.transform.position += new Vector3(moveSpeed * Time.deltaTime * -1,0,0); // 오른쪽 생성시 오른쪽으로 이동
        }
        else if(Manager.Direction == 2)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime,0,0); // 왼쪽 생성시 왼쪽으로 이동
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Manager.coll = 1; // 플레이어와 만났을 때
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Health > 0 && Manager.coll == 1) // 몬스터 체력이 0이 아니고 플레이어와 만났을 때 공격 애니메이션 실행
        {
            ZombiAttack();
        }
        else if(Manager.Health > 0) // 몬스터 체력이 0이 아니고 플레이어와 안만났을 때 이동 함수 및 걷는 애니메이션 실행
        {
            ZombiMove();
        }
        else if(Manager.Health <= 0) // 몬스터 체력이 0이 되었을때 죽는 애니메이션 실행 후 2초후 해당 오브젝트 삭제
        {
            ZombiDead();
            Destroy(this.gameObject,2f);
            player.GetComponent<PlayerCS>().Monster = null; // 플레이어 스크립트의 Monster변수를 null로 변경
            Manager.isSpawn = true; // MonsterManager 스크립트의 isSpawn변수를 true로 변경
        }
    }
}
