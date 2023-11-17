using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator animator;

    // 움직이는 속도 조절
    public float moveSpeed = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 처음 초기값 : (0,0,0) Vector3 사용 이유 -> object transform 컴포넌스 속 position이 Vector3값이기 때문이다.
        Vector3 movePosition = Vector3.zero;
        
        // Unity에서 InputManager를 통해 기본적으로 키보드 세팅을 할 수 있게끔 해주는 시스템
        // 왼쪽이동 : a , <- 
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            movePosition = Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isMove", true);
        }
        // 오른쪽이동 : d, ->
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            movePosition = Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isMove", true);
        }
        // 움직이지 않음
        else
        {
            animator.SetBool("isMove", false);
        }

        transform.position += movePosition * moveSpeed * Time.deltaTime;
    }


}