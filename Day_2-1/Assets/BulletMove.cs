using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed=6.0f;
    private Vector3 moveDirection=Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * bulletSpeed * Time.deltaTime;

        // 특정 구역 외부로 나가는 총알 오브젝트 삭제(메모리 누수 방지)
        if (transform.position.x > 8.0f || transform.position.x < -8.0f || transform.position.y > 4.2f || transform.position.y < -4.2f)
        {
            Destroy(gameObject);
        }

    }
    // PlayerController에서 접근할 수 있게 public 설정
    public void setDirection(Vector3 dir)
    {
        moveDirection = dir;
    }
}
