using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    public float jumpForce = 680.0f;
    

    // 연속점프 관리
    bool isGround = false;

    // 더블점프 체크
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
       
        
        //캐릭터 이동제한
        MoveControl();


        // 처음 초기값 : (0,0,0) Vector3 사용 이유 -> object transform 컴포넌스 속 position이 Vector3값이기 때문이다.
        Vector3 movePosition = Vector3.zero;

        // Unity에서 InputManager를 통해 기본적으로 키보드 세팅을 할 수 있게끔 해주는 시스템
        // 왼쪽이동 : a , <- 
        if (Input.GetAxisRaw("Horizontal") < 0)
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
                // 더블점프를 한다음엔 점프가 다시 되지 않도록 하기 위해 doubleJumpCheck = false로 설정,
                doubleJumpCheck = false;
            }

    transform.position += movePosition * moveSpeed * Time.deltaTime;






    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            Portal p = collision.gameObject.GetComponent<Portal>();

            switch(p.type)
            {
                // 출구포탈 오브젝트의 위치를 가져와서 캐릭터를 그 위치로 옮김
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

    // 캐릭터가 화면밖으로 이동하지 못하도록 하는 함수
    void MoveControl()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Mathf.Clamp01(값) - 입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조정
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    private void OnCollisionEnter(Collision c)
    {
      // 부딪힌 물체의 태그가 "Ground"라면
      if(c.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

}
