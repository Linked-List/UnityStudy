using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D = null;
    private Animator anim = null;
    private int dir = 1; // right
    private AudioSource aud;
    [SerializeField]
    private float speed = 3.0f;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, y, 0);

        // 좌우 방향이 뒤집어 질때 localScale값의 x값을 -1을 곱해주어서 좌우반전효과
        if (x != 0 && (int)x != dir)
        {
            dir *= -1;
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.transform.localScale.y, transform.localScale.z);
        }

        if(movement != Vector3.zero)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("isAttack");

        rigid2D.velocity = movement*speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isPush", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isPush", false);
    }

    public void playSound()
    {
        aud.Play();
    }
}
