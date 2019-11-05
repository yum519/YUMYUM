using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircle : MonoBehaviour
{
    float radius = 0.5f;
    float radiusPlus = 1.5f;

    public bool isHit = false;

    Vector3 posC;
    Vector3 posP;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
        posC = transform.position;

        if (radius >= 1.5f)
            radius = 0;
        else
           radius += radiusPlus * Time.deltaTime;

        Player player = GameObject.Find("Player").GetComponent<Player>();

        // 원 그리기
        int pointNum = 60;
        float angle = 0;

        GetComponent<LineRenderer>().positionCount = pointNum + 1;

        for (int i = 0; i <= pointNum; i++)
        {
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            GetComponent<LineRenderer>().SetPosition(i, new Vector3(x,y,0));

            angle += 360 / pointNum;
        }

        // 원과 충돌 체크 -> ok
        // 죽었으면 체크 안하게if(!player.GetComponent<Player>().isDead)

        if ((player.atkBox_w1 - radius <= posC.x && posC.x <= player.atkBox_w2 + radius)
            && (player.atkBox_h1 <= posC.y && posC.y <= player.atkBox_h2))
        {
            isHit = true;
            Debug.Log("충돌1-1 !");
        }
        else if ((player.atkBox_w1 <= posC.x && posC.x <= player.atkBox_w2)
            && (player.atkBox_h1 - radius <= posC.y && posC.y <= player.atkBox_h2 + radius))
        {
            isHit = true;
            Debug.Log("충돌1-2 !");
        }
        else if (Mathf.Sqrt(Mathf.Pow(player.atkBox_w1 - posC.x, 2) + Mathf.Pow(player.atkBox_h1 - posC.y, 2)) <= radius)
        {
            isHit = true;
            Debug.Log("충돌2-1 !");
        }
        else if (Mathf.Sqrt(Mathf.Pow(player.atkBox_w1 - posC.x, 2) + Mathf.Pow(player.atkBox_h2 - posC.y, 2)) <= radius)
        {
            isHit = true;
            Debug.Log("충돌2-2 !");
        }
        else if (Mathf.Sqrt(Mathf.Pow(player.atkBox_w2 - posC.x, 2) + Mathf.Pow(player.atkBox_h1 - posC.y, 2)) <= radius)
        {
            isHit = true;
            Debug.Log("충돌2-3 !");
        }
        else if (Mathf.Sqrt(Mathf.Pow(player.atkBox_w2 - posC.x, 2) + Mathf.Pow(player.atkBox_h2 - posC.y, 2)) <= radius)
        {
            isHit = true;
            Debug.Log("충돌2-4!");
        }
        else
            isHit = false;


    }
}
