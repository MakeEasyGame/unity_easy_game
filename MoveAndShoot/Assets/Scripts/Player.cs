using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float walkSpeed;
    public float jumpPower;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // W키를 누르고 플레이어 아래에 ray를 쏴서 레이어가 Ground인 오브젝트가 있으면 점프되게 만들기
        if (Input.GetKeyDown(KeyCode.W) && Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"))) {
            rb.AddForce (Vector2.up * jumpPower, ForceMode2D. Impulse);
        }

        // a,d키의 인풋을 저장하기
        float x = Input.GetAxisRaw("Horizontal");
        // 점프 스피드와 x변수로 이동하기
        rb.velocity = new Vector2(x * walkSpeed, rb.velocity.y);

        // 마우스를 누르면 총알을 소환하고 총알의 위치를 플레이어의 위치로 한다음에 방향 설정하기
        if(Input.GetMouseButtonDown(0)) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;

            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   	        float angle = Mathf.Atan2(mouse.y - bullet.transform.position.y, mouse.x - bullet.transform.position.x) * Mathf.Rad2Deg;
   	        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
