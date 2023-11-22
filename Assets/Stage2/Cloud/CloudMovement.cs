using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveDistance = 5.0f; // �̵� �Ÿ�
    public float moveSpeed = 2.0f;

    private void Update()
    {
        // Mathf.PingPong �Լ��� ����Ͽ� ������Ʈ�� �¿�� �ݺ� �̵�
        float pingPongValue = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        // ���� ��ġ�� �����Ͽ� ������Ʈ�� ������
        transform.position = new Vector3(pingPongValue, transform.position.y, transform.position.z);
    }
}

