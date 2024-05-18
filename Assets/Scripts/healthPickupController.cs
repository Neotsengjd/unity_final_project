using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickupController : MonoBehaviour
{
    public float healthAmount;
    public AudioClip healthPickupSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other != null && other.tag == "Player"){
            playerHealth playerHealthComponent = other.GetComponent<playerHealth>();
            
            if (playerHealthComponent != null)
            {
                playerHealthComponent.addHealth(healthAmount);
            }
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthPickupSound, transform.position, 1f);
            
        }
    }
}
