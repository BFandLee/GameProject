using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 5.0f;

    private Vector3 initialPosition;

    void Start()
    {
        Application.targetFrameRate = 60;
        initialPosition = transform.position;
    }

    void Update()
    {
        // �������� �̵�
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // ������Ʈ�� �ʱ� ��ġ���� ���� �Ÿ��� ����� �ݴ� �������� �̵�
        if (Mathf.Abs(transform.position.x - initialPosition.x) > moveDistance)
        {
            moveSpeed *= -1; // �̵� ������ �ݴ�� ����
        }
    }
}
