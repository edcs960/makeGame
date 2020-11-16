using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    Vector3[] positions = new Vector3[2];
    public Transform Prefab;
    public bool isSpawn = false;
    public float spawnDalay = 1.6f;
    float spawnTimer = 0f;

    public int Direction;
    public int Health;
    public int coll;
    // Start is called before the first frame update
    void Start()
    {
        Createpositions();    
    }

    // Update is called once per frame
    

    void Createpositions() // 몬스터가 생성될 위치 설정
    {
        float RSponX = 10.7f;
        float RSponY = -1f;
        float RSponZ = -1f;

        float LSponX = -10.7f;
        float LSponY = -1f;
        float LSponZ = -1f;
        
        positions[0] = new Vector3(RSponX, RSponY, RSponZ); // 오른쪽에서 몬스터 생성
        positions[1] = new Vector3(LSponX, LSponY, LSponZ); // 왼쪽에서 몬스터 생성
    }

    void SpawnMonster()
    {
        if(isSpawn == true)
        {
            if(spawnTimer > spawnDalay)
            {
                int rand = Random.Range(0, positions.Length); // 랜덤값을 이용하여 생성위치 결정

                if(rand == 0)
                {
                    //Prefab.localScale.Set(-1f,1f,1f);
                    Direction = 1; // 왼쪽방향 이동
                    Prefab.localScale = new Vector3(-1f,1f,1f); // 몬스터가 보는 방향 설정
                }
                else
                {
                    //Prefab.localScale.Set(1f,1f,1f);
                    Direction = 2; // 오른쪽방향 이동
                    Prefab.localScale = new Vector3(1f,1f,1f); // 몬스터가 보는 방향 설정
                }

                Instantiate(Prefab,positions[rand],Quaternion.identity); // 몬스터 오브젝트 생성

                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }
    void Update()
    {
        SpawnMonster();
    }
}
