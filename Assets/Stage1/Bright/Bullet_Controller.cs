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
        // ȭ�� �������� �ӵ�
        transform.Translate(0, -0.005f, 0);

        // ȭ�� ������ ������ ������Ʈ ����
        if (transform.position.y < -6.31f)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector2 p1 = transform.position;    // �Ѿ��� �߽� ��ǥ
        Vector2 p2 = boy_0.transform.position;  // �÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;

        float d = dir.magnitude;
        float r1 = 0.5f; // �Ѿ��� �ݰ�
        float r2 = 1.0f; // �÷��̾��� �ݰ�

        if(d < r1+ r2)
        {
            GameDirector.hp -= 1;
            Destroy(gameObject);
        }



 
    }
}
