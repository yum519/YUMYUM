using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    bool isJump = false;
    float velocity = 0f;

    bool isLDash= false;
    bool isRDash = false;
    bool isDamage = false;
    bool isDead = false;

    int jumpCnt = 1;

    public float atkArea_x;
    public float atkArea_y;
    public float hitArea_x;
    public float hitArea_y;

    public float atkBox_w1 = 0;
    public float atkBox_w2 = 0;
    public float atkBox_h1 = 0;
    public float atkBox_h2 = 0;

    public float hitBox_w1 = 0;
    public float hitBox_w2 = 0;
    public float hitBox_h1 = 0;
    public float hitBox_h2 = 0;

    float hp = 100;

    float dmgCoolTime = 1;
    float dmgTime = 0;

    Vector3 posX;

    public GameObject prefabAtkBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position;

        // 점프
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(jumpCnt >= 0)
            {
                velocity = 22f;
                isJump = true;
            }    
        }
            
        if (isJump)
        {
            if (Input.GetKeyDown(KeyCode.C))
                jumpCnt--;

            posX.y += velocity * Time.deltaTime;
            velocity -= 2f;
        }

        if (posX.y < 0)
        {
            posX.y = 0;
            velocity = 0f;
            jumpCnt = 1;
        }

        transform.position = posX;

        // 좌우 이동
        //float LDashInputTime = 0;
        //int dashKeyDown = -1;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            posX.x -= 5f * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // 두번 누르면 이속 빨라지게
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            posX.x += 5f * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.position = posX;

        hitBox_w1 = posX.x - hitArea_x;
        hitBox_w2 = posX.x + hitArea_x;
        hitBox_h1 = posX.y - hitArea_y;
        hitBox_h2 = posX.y + hitArea_y;

        GameObject enemy = GameObject.Find("Enemy");

        // 공격
        if (Input.GetKeyDown(KeyCode.X))
        {
            // 데미지 박스 만들기
            GameObject atkBox = Instantiate(prefabAtkBox);
            atkBox.transform.SetParent(gameObject.transform);

            // 이펙트
            foreach (Transform child in transform)
            {
                if (child.GetComponent<ParticleSystem>() != null)
                  child.GetComponent<ParticleSystem>().Play();
            }
  
           /* //적에게 데미지 주기
            if (enemy != null && !enemy.GetComponent<Enemy>().isDead)
            {
                if(enemy.gameObject.transform.GetChild(1).GetComponent<HitCircle>().isHit)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(10f);
                }
            }*/
        }

       //타이밍 못 맞추면 데미지 받기
        if (enemy != null && !enemy.GetComponent<Enemy>().isDead)
        {
            if ((hitBox_w2 >= enemy.GetComponent<Enemy>().hitbox_w1)
               && (hitBox_w1 <= enemy.GetComponent<Enemy>().hitbox_w2)
               && (hitBox_h2 >= enemy.GetComponent<Enemy>().hitbox_h1)
               && (hitBox_h1 <= enemy.GetComponent<Enemy>().hitbox_h2))          
            {

                if(Time.deltaTime - dmgTime > dmgCoolTime)
                {
                    isDamage = false;
                    dmgTime = 0;
                    GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
                }

                if (!isDamage)
                {
                    TakeDamage(10f);
                    dmgTime = Time.deltaTime;
                    isDamage = true;
                }
                    
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);

        hp = hp - dmg;

        foreach (Transform child in transform)
        {
            if (child.GetComponent<ParticleSystem>() != null)
                child.GetComponent<ParticleSystem>().Play();
        }

        Debug.Log("아스카 아야");

        if (hp <= 0)
            isDead = true;

        if (isDead)
        {
            // 스프라이트 끄기
            Debug.Log("아스카 죽는당");
            this.gameObject.SetActive(false);
        }
    }
}





