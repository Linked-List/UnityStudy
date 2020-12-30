using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed=3.0f;
    private Rigidbody2D rigid=null;

    [SerializeField]
    private GameObject bullet = null;

    private Vector3 lastMoveDirection = Vector3.right;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // 좌 = x(-1), 우 = x(1), 상 = y(1), 하 = y(-1)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        // 충돌에서 강제로 이동된 뒤에 밀려나는 현상때문에 rigid.velocity를 수정하여 해결
        rigid.velocity = new Vector3(x, y, 0) * moveSpeed;

        if(x != 0 || y != 0)
        {
            // 총알을 쏘기위한 마지막 바라보던 방향 설정
            lastMoveDirection = new Vector3(x, y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 총알 생성 및 총알 방향 설정
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<BulletMove>().setDirection(lastMoveDirection);
        }
    }
}
