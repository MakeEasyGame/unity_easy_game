using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update() {
        // 총알의 x가 9.2f보다 작고 -9.2f보다 크면 플레이어가 설정한 방향대로 이동하기
        if(transform.position.x < 9.2f && transform.position.x > -9.2f) {
            transform.Translate(Vector3.right * 10 * Time.deltaTime);
        } else { // 총알의 x가 9.2f보다 크고 -9.2f보다 작으면 총알을 삭제하기
            Destroy(gameObject);
        }
    }
}
