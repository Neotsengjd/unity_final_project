using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBumb : MonoBehaviour
{
    public GameObject[] dropItems;
    public AudioSource AS;
    public float rate = 10f;

    private bool playerEnter = false;
    // Start is called before the first frame update
    void Start()
    {  
        AS = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if(playerEnter)
        {
            rate -= Time.deltaTime;
            if(rate <= 0)
            { 
                Vector3 position = new Vector3(Random.Range(200f, 250f), 60f, 0f);
                Instantiate(dropItems[0], position, Quaternion.identity);
                rate = 10f;
            }                
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("in");
            AS.Play();
            playerEnter = true;
        }
    }
}
