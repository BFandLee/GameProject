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

    // �������� ����
    bool isGround = false;

    // �������� üũ
    bool doubleJumpCheck = false;

    

    // �����̴� �ӵ� ����
    public float moveSpeed = 1f;
   
    void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(CheckSwordManDeath());

                
    }

    void Update()
    {
        // ó�� �ʱⰪ : (0,0,0) Vector3 ��� ���� -> object transform �����ͽ� �� position�� Vector3���̱� �����̴�.
        Vector3 movePosition = Vector3.zero;
        
        // Unity���� InputManager�� ���� �⺻������ Ű���� ������ �� �� �ְԲ� ���ִ� �ý���
        // �����̵� : a , <- 
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            movePosition = Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isMove", true);
        }
        // �������̵� : d, ->
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            movePosition = Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isMove", true);
        }
        
        // �������� ����
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
           
            // ü���� 0������ ��
            if (GameDirector.hp == 0)
            {
                isSwordManDead = true;
                animator.SetTrigger("DieTrigger");
                yield return new WaitForSeconds(2); // 2�� ��ٸ���
                SceneManager.LoadScene("Stage1");
            }
            yield return new WaitForEndOfFrame(); // �� �������� ������ ���� ����
        }
    }


    }