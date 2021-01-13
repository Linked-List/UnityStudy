using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {
    float effectTime = 0.0f;
	void Update ()
    {
        effectTime += Time.deltaTime;
        if(effectTime > 1.0f)
        {
            Destroy(gameObject);
        }
	}
}
