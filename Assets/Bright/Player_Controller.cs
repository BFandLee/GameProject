using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator animator;

    // �����̴� �ӵ� ����
    public float moveSpeed = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
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

        transform.position += movePosition * moveSpeed * Time.deltaTime;
    }


}