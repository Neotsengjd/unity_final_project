using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformsMovement : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.09f) {
            ++i;
            if (i == points.Length) i = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}