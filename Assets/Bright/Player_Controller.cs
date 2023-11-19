using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    public float jumpForce = 680.0f;
    bool isSwordManDead = false;

    // 연속점프 관리
    bool isGround = false;

    // 더블점프 체크
    bool doubleJumpCheck = false;

    

    // 움직이는 속도 조절
    public float moveSpeed = 1f;
   
    void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(CheckSwordManDeath());

                
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

        // Jump
        if(this.rigidbody2D.velocity.y == 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        if (isGround)
            doubleJumpCheck = true;
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("JumpTrigger");
        }
        else if(doubleJumpCheck && Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("DubleJumpTrigger");
            doubleJumpCheck = false;
        }

        transform.position += movePosition * moveSpeed * Time.deltaTime;
    }

    IEnumerator CheckSwordManDeath()
    {
        while (true)
        {
           
            // 체력이 0이하일 때
            if (GameDirector.hp == 0)
            {
                isSwordManDead = true;
                animator.SetTrigger("DieTrigger");
                yield return new WaitForSeconds(2); // 2초 기다리기
                SceneManager.LoadScene("Stage1");
            }
            yield return new WaitForEndOfFrame(); // 매 프레임의 마지막 마다 실행
        }
    }


    }