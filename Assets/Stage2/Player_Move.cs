using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    public float jumpForce = 680.0f;
    

    // �������� ����
    bool isGround = false;

    // �������� üũ
    bool doubleJumpCheck = false;



    public float moveSpeed = 1f;

    void Start()
    {
        
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        //ĳ���� �̵�����
        MoveControl();


        // ó�� �ʱⰪ : (0,0,0) Vector3 ��� ���� -> object transform �����ͽ� �� position�� Vector3���̱� �����̴�.
        Vector3 movePosition = Vector3.zero;

        // Unity���� InputManager�� ���� �⺻������ Ű���� ������ �� �� �ְԲ� ���ִ� �ý���
        // �����̵� : a , <- 
        if (Input.GetAxisRaw("Horizontal") < 0)
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
        if (this.rigidbody2D.velocity.y == 0)
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
            else if (doubleJumpCheck && Input.GetKeyDown(KeyCode.Space))
            {
                this.rigidbody2D.AddForce(transform.up * this.jumpForce);
                animator.SetTrigger("DubleJumpTrigger");
                // ���������� �Ѵ����� ������ �ٽ� ���� �ʵ��� �ϱ� ���� doubleJumpCheck = false�� ����,
                doubleJumpCheck = false;
            }

    transform.position += movePosition * moveSpeed * Time.deltaTime;






    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            Portal p = collision.gameObject.GetComponent<Portal>();

            switch(p.type)
            {
                // �ⱸ��Ż ������Ʈ�� ��ġ�� �����ͼ� ĳ���͸� �� ��ġ�� �ű�
                case "Portal Enter":
                    Vector3 anotherPortalPos = p.portal.transform.position;
                    Vector3 warpPos = new Vector3(anotherPortalPos.x, anotherPortalPos.y, anotherPortalPos.z);
                    transform.position = warpPos;
                    break;
            
            case "lag":
                SceneManager.LoadScene("Game_Clear");
                break;
        }
        
       
        
    }

    // ĳ���Ͱ� ȭ������� �̵����� ���ϵ��� �ϴ� �Լ�
    void MoveControl()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Mathf.Clamp01(��) - �Էµ� ���� 0~1 ���̸� ����� ���ϰ� ������ ����
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    private void OnCollisionEnter(Collision c)
    {
      // �ε��� ��ü�� �±װ� "Ground"���
      if(c.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

}
