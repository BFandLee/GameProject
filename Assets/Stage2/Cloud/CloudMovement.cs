using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Vector3 pos;
    public float moveDistance = 5.0f; // �̵� �Ÿ�
    public float moveSpeed = 2.0f;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        Vector3 v = pos;
        // �¿� �̵��� �ִ�ġ �� ����ó��
        v.x += moveDistance * Mathf.Sin(Time.time * moveSpeed);


        // ���� ��ġ�� �����Ͽ� ������Ʈ�� ������
        transform.position = v;
    }
}

