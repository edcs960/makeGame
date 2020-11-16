using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCS : MonoBehaviour
{
    public Animator anim;
    public GameObject Monster;
    public int dmg;

    public float StartTime;
    public float minX, maxX;
    [Range(1,2)]
    public float moveSpeed;
    private float PlayerScale_x = -0.8211252f;    
    private int sign = -1;
    private int coll = 0;
    MonsterManager Manager;
    ZombiCS Zombi;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Manager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
    }

    // Update is called once per frame
    void Update() // 여기서 몬스터가 없으면 걷는 애니메이션이 나오고 몬스터가 있어도 겉는 모션이 나오다가 만나면 공격하는 모션이 나와야되거든?
    {
        if(Manager.Health == 0)
        {
            coll = 0;
        }
        if(coll == 0)
        {
            PlayerWalkAnim();
            PlayerMove();
        }
        else if(coll == 1)
        {
            PlayerAttackAnim();
        }
    }

    public void SetDamage()
    {
        Monster.GetComponent<ZombiCS>().GetDamage(dmg); // 플레이어가 몬스터에게 공격하여 데미지를 입히는 코드
    }

    void PlayerWalkAnim()
    {
        anim.SetInteger("AnimState",0); // 이동 애니메이션
    }

    void PlayerAttackAnim()
    {
        anim.SetInteger("AnimState",1); // 공격 애니메이션
    }

    void PlayerMove()
    {
        if(Time.time >= StartTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign,0,0); // 플레이어 이동 코드

            if(transform.position.x < minX || transform.position.x > maxX)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime * sign - 0.1f * sign,0,0); // minX와 maxX 이상 넘어갈 때
                sign *= -1; // 방향 전환
                PlayerScale_x *= -1; 
                transform.localScale = new Vector3(PlayerScale_x,0.7797894f,1); // 플레이어가 보는 방향 전환
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // 여기는 몬스터랑 만나면 자동으로 들어가져
    {
        if(other.gameObject.tag == "Monster")
        {
            coll = 1; // 몬스터와 만났을때
        }
    }
}
