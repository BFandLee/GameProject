using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boy_Controller : MonoBehaviour
{
    float walkForce = 4000.0f;
    float maxWalkSpeed = 120.0f;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        int key = 0;

        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

        // 오른쪽으로 이동
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;

        // 힘을 가해 속도 조절
        float newVelocity = key * walkForce * Time.deltaTime;
        rb.velocity = new Vector2(newVelocity, rb.velocity.y);

        // 속도 제한
        float clampedVelocity = Mathf.Clamp(rb.velocity.x, -maxWalkSpeed, maxWalkSpeed);
        rb.velocity = new Vector2(clampedVelocity, rb.velocity.y);

        bool isWalking = Mathf.Abs(rb.velocity.x) > 0.1f;
        animator.SetBool("IsWalking", isWalking);
    }


}