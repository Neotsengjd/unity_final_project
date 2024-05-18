using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        transform.position = new Vector3(target.position.x, target.position.y+2f, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 targetCamPos = target.position + offset;
        transform.position = new Vector3(target.position.x, target.position.y+2f, transform.position.z);

        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
