using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    private float noteSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1) * noteSpeed * Time.deltaTime;
        if (transform.position.y < -10.0f)
        {
            //miss
            Destroy(gameObject);
        }
    }
}
