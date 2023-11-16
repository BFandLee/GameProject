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

        Vector2 p1 = transform.position;
        Vector2 p2 = boy_0.transform.position;

        float r1X = 2.34f / 2.0f;
        float r1Y = 5.66f / 2.0f;

        float r2X = 0.19f / 2.0f;
        float r2Y = 0.61f / 2.0f;

        if (Mathf.Abs(p1.x - p2.x) < r1X + r2X && Mathf.Abs(p1.y - p2.y) < r1Y + r2Y)
        {
            Destroy(gameObject);
        }
    }
}
