using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    private AudioSource aud;
    [SerializeField]
    private GameObject effect = null;
    private void Awake()
    {
        aud = GetComponent<AudioSource>();    
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enamy")
        {
            //Destroy(collision.gameObject);
            transform.parent.gameObject.GetComponent<PlayerController>().playSound();
            GameObject clone = Instantiate(effect,transform.position,Quaternion.identity);
        }
    }
}
