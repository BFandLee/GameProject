using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveDistance = 5.0f; // 이동 거리
    public float moveSpeed = 2.0f;

    private void Update()
    {
        // Mathf.PingPong 함수를 사용하여 오브젝트를 좌우로 반복 이동
        float pingPongValue = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        // 현재 위치를 변경하여 오브젝트를 움직임
        transform.position = new Vector3(pingPongValue, transform.position.y, transform.position.z);
    }
}

