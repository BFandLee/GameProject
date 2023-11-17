using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    GameObject boy_0;
    // Start is called before the first frame update
    void Start()
    {
        this.boy_0 = GameObject.Find("boy_0");
    }

    // Update is called once per frame
    void Update()
    {   
        // 화살 떨어지는 속도
        transform.Translate(0, -0.005f, 0);

        // 화면 밖으로 나오면 오브젝트 삭제
        if (transform.position.y < -6.31f)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector2 p1 = transform.position;    // 총알의 중심 좌표
        Vector2 p2 = boy_0.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;

        float d = dir.magnitude;
        float r1 = 0.5f; // 총알의 반경
        float r2 = 1.0f; // 플레이어의 반경

        if(d < r1+ r2)
        {
            GameDirector.hp -= 1;
            Destroy(gameObject);
        }



 
    }
}
