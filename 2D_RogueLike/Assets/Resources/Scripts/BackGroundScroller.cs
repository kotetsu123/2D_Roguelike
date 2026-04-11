using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    public Transform target;

    private Renderer rd;
    private Material mat;

    public float scrollSpeed = 0.1f;
    void Start()
    {
        rd=GetComponent<Renderer>();
        mat=rd.material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;

        float offsetX=transform.position.x+5f;
        float offsetY=transform.position.y+5f;
        mat.mainTextureOffset = new Vector2(offsetX, offsetY)*scrollSpeed;
    }
}
