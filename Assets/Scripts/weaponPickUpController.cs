using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUpController : MonoBehaviour
{
    // Start is called before the first frame update

    public int whichWeapon;
    public AudioClip pickUpClip;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<InventoryManager>().activateWeapon(whichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickUpClip, transform.position);

        }
    }

}
