using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JudgementController : MonoBehaviour
{
    private EdgeCollider2D judgeLine = null;
    
    // 누르고 안떼는것 처리
    private float holdTimer = 0.0f;
    
    // 판정을 위에 띄우기 위함
    [SerializeField]
    private TextMeshProUGUI tmp;
       
    [SerializeField]
    private KeyCode button;
    private SpriteRenderer sr = null;
    // 노트 범위 겹치는거 하나만 처리하게 제약.
    private int count = 0;
    private void Awake()
    {
        sr = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        judgeLine = GetComponent<EdgeCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count > 0)
        {
            tmp.text = collision.gameObject.name;
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject.transform.parent.gameObject);
            count--;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(button))
        {
            judgeLine.enabled = true;
            sr.color = Color.red;
            count = 1;
        }
        // 오래 누르고있는것 처리
        if (judgeLine.enabled)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer > 0.1f)
            {
                holdTimer = 0.0f;
                judgeLine.enabled = false;
                sr.color = Color.white;
                count = 0;
            }
        }
        if (Input.GetKeyUp(button))
        {
            holdTimer = 0.0f;
            judgeLine.enabled = false;
            sr.color = Color.white;
            count = 0;
        }

    }
}
