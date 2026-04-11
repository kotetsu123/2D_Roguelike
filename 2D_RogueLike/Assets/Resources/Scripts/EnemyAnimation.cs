using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float scaleAmount = 0.05f;
    public float scaleSpeed = 5f;

    Vector3 defaultSize;
    void Start()
    {
        defaultSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleProgress = Mathf.PingPong(Time.time*scaleSpeed, 1f);

        float scaleChange=(scaleProgress*2-1)*scaleAmount;

        Vector3 newSalce = defaultSize * (1+scaleChange);

        transform.localScale = newSalce;
    }
}
