using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorController : MonoBehaviour
{
    // Start is called before the first frame update

    public float resetTime;


    Animator elevAnim;
    AudioSource elevAS;

    float downTime;

    bool elevIsUp = false;


    void Start()
    {
        elevAnim = GetComponent<Animator>();
        elevAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (downTime <= Time.time && elevIsUp) {

            elevAnim.SetTrigger("activeTrigger");
            elevIsUp = false;
            elevAS.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            Debug.Log("INffff e");

            elevAnim.SetTrigger("activeTrigger");
            downTime = Time.time + resetTime;
            elevIsUp = true;
            elevAS.Play();
        }
    }
}
