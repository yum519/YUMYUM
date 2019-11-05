using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    float x1;
    float x2;
    float y1;
    float y2;

    public bool isPlayerHit = false;

    void Start()
    {
        GetComponent<LineRenderer>().positionCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // 상자 그리기
        if (transform.parent.name.Equals("Enemy"))
        {
            x1 = transform.parent.GetComponent<Enemy>().hitbox_w1;
            x2 = transform.parent.GetComponent<Enemy>().hitbox_w2;
            y1 = transform.parent.GetComponent<Enemy>().hitbox_h1;
            y2 = transform.parent.GetComponent<Enemy>().hitbox_h2;
        }
        else if (transform.parent.name.Equals("Player"))
        {
            if (gameObject.name.Equals("HitBox"))
            {
                x1 = transform.parent.GetComponent<Player>().hitBox_w1;
                x2 = transform.parent.GetComponent<Player>().hitBox_w2;
                y1 = transform.parent.GetComponent<Player>().hitBox_h1;
                y2 = transform.parent.GetComponent<Player>().hitBox_h2;
            }
            else
            {
                x1 = transform.parent.GetComponent<Player>().atkBox_w1;
                x2 = transform.parent.GetComponent<Player>().atkBox_w2;
                y1 = transform.parent.GetComponent<Player>().atkBox_h1;
                y2 = transform.parent.GetComponent<Player>().atkBox_h2;
            }
        }

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

    }
}

