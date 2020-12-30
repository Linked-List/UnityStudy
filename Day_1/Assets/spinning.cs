using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinning : MonoBehaviour
{
    public Material m;
    private float scroll = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        m.SetTextureOffset("_MainTex", new Vector2(0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        scroll = scroll > 1.0f ? 0.0f : scroll + 0.01f;
        // Material의 Offset값을 Direct로 수정
        m.SetTextureOffset("_MainTex", new Vector2(scroll, 0.0f));
    }
}
