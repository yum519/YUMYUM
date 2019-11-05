﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float hp = 100f;

    bool isDamage= false;
    public bool isDead = false;
    bool isKnockBack = false;
    float speed = 0;
    Vector3 posX;

    float distance = 0;

    float dmgArea_x = 0.6f;
    float dmgArea_y = 0.8f;

    public float hitbox_w1 = 0;
    public float hitbox_w2 = 0;
    public float hitbox_h1 = 0;
    public float hitbox_h2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position;

        if (isDamage)
        {
            if (!isKnockBack)
            {
                distance = posX.x;
                isKnockBack = true;
            }
              

            speed += 5 * Time.deltaTime;

            posX.x += speed;

            if (posX.x - distance >= 3)
            {
                isDamage = false;
                speed = 0;
                distance = 0;
                isKnockBack = false;
            }

        }
        else
            posX.x -= 1 * Time.deltaTime;

        transform.position = posX;
        
        hitbox_w1 = posX.x - dmgArea_x;
        hitbox_w2 = posX.x + dmgArea_x;
        hitbox_h1 = posX.y - dmgArea_y;
        hitbox_h2 = posX.y + dmgArea_y;

    }

    public void TakeDamage(float dmg)
    {
        isDamage = true;

        hp = hp - dmg;

        foreach (Transform child in transform)
        {
            if(child.GetComponent<ParticleSystem>() != null)
                child.GetComponent<ParticleSystem>().Play();
        }

        Debug.Log("아야");

        if (hp <= 0)
            isDead = true;

        if (isDead)
        { 
            // 스프라이트 끄기
            Debug.Log("죽는당");
            this.gameObject.SetActive(false);
        }
    }
}
