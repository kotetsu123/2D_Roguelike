using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
   // [SerializeField] private Camera mainCam;
    public Transform target;
    public float smoothSpeed=5f;

    private void LateUpdate()
    {
        if (target == null) return;
        //transform.position =new Vector3(target.position.x,target.position.y,transform.position.z)*smoothSpeed*Time.deltaTime;
        Vector3 desirePos = new Vector3(target.position.x, target.position.y, transform.position.z);

        Vector3 smoothPos = Vector3.Lerp(transform.position, desirePos, smoothSpeed * Time.deltaTime);

        transform.position = desirePos;
    }
}
