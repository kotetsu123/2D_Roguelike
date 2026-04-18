using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivotRotator : MonoBehaviour
{
    public float spinSpeed= -100f;

    private void Update()
    {
        transform.Rotate(0, 0,- spinSpeed * Time.deltaTime);
    }
}
