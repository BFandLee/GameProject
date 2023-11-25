using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Vector3 pos;
    public float moveDistance = 5.0f; // 이동 거리
    public float moveSpeed = 2.0f;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        Vector3 v = pos;
        // 좌우 이동의 최대치 및 반전처리
        v.x += moveDistance * Mathf.Sin(Time.time * moveSpeed);


        // 현재 위치를 변경하여 오브젝트를 움직임
        transform.position = v;
    }
}

