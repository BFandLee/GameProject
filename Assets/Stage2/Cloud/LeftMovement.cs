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
        // 왼쪽으로 이동
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 오브젝트가 초기 위치에서 일정 거리를 벗어나면 반대 방향으로 이동
        if (Mathf.Abs(transform.position.x - initialPosition.x) > moveDistance)
        {
            moveSpeed *= -1; // 이동 방향을 반대로 변경
        }
    }
}
