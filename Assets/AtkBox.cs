using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBox : MonoBehaviour
{
    // Start is called before the first frame update
    float x1;
    float x2;
    float y1;
    float y2;

    Vector3 pos;

    float timer= 0;
    private void Awake()
    {
        // 생성한 캐릭터와 위치 맞추기

        /*if (transform.parent.name.Equals("Player"))
        {
            Debug*.Log("플레이어!!");
        }*/

        Player player = GameObject.Find("Player").GetComponent<Player>();
        transform.position = player.transform.position;

        pos = transform.position;

        if (player.GetComponent<SpriteRenderer>().flipX)
        {
            x1 = pos.x + player.transform.GetComponent<Player>().atkArea_x;
            x2 = x1 + player.transform.GetComponent<Player>().hitArea_x;

        }
        else
        {
            x1 = pos.x - player.transform.GetComponent<Player>().atkArea_x;
            x2 = x1 - player.transform.GetComponent<Player>().hitArea_x;
        }
       
        y1 = pos.y - player.transform.GetComponent<Player>().hitArea_y;
        y2 = pos.y + player.transform.GetComponent<Player>().hitArea_y;

    }
    void Start()
    {
        GetComponent<LineRenderer>().positionCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
        // 상자 그리기
        GetComponent<LineRenderer>().SetPosition(0, new Vector3(x1, y1, 0));
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(x1, y2, 0));
        GetComponent<LineRenderer>().SetPosition(2, new Vector3(x2, y2, 0));
        GetComponent<LineRenderer>().SetPosition(3, new Vector3(x2, y1, 0));
        GetComponent<LineRenderer>().SetPosition(4, new Vector3(x1, y1, 0));


        // 충돌 체크

        /*Player player = GameObject.Find("Player").GetComponent<Player>();

        if (transform.parent.name.Equals("Enemy"))
        {
            if ((player.hitBox_w2 >= x1)
                && (player.hitBox_w1 <= x2)
                && (player.hitBox_h2 <= y1)
                && (player.hitBox_h1 >= y2))
            {
                Debug.Log("x1"+x1+ "x2"+x2 + "y1" + y1 + "y2" + y2);
                isPlayerHit = true;
            }
        }*/

     

        if(timer > 0.5f)
        {
            Destroy(gameObject);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
