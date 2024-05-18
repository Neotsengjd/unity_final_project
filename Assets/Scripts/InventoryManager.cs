using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapons;
    bool[] weaponAvailable;
    public Image weaponImage;

    int currentWeapon;

    Animator weaponImageAnim;

    void Start()
    {
        weaponAvailable = new bool[weapons.Length];
        for (int i = 0; i < weapons.Length; i++)
            weaponAvailable[i] = false;
        currentWeapon = 0;
        weaponAvailable[currentWeapon] = true;
        //for (int i = 0; i < weapons.Length; i++)
        //    weaponAvailable[i] = true;

        weaponImageAnim = weaponImage.GetComponent<Animator>();

        deactivateWeapon();

        setWeaponActive(currentWeapon);

    }

    // Update is called once per frame
    void Update()
    {
        //toggle weapon
        if (Input.GetButtonDown("Submit"))
        {
            int i;
            for (i = currentWeapon + 1; i < weapons.Length; i++)
            {
                if (weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }

            for (i = 0; i < currentWeapon; i++)
            {
                if (weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
        }
    }

    public void setWeaponActive(int whichWeapon)
    {
        if (!weaponAvailable[whichWeapon] == true)
            return;
        deactivateWeapon();
        weapons[whichWeapon].SetActive(true);
        weapons[whichWeapon].GetComponentInChildren<fireBullet>().initializeWeapon();

        weaponImageAnim.SetTrigger("weaponSwitch");
    }

    void deactivateWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].SetActive(false);
    }

    public void activateWeapon(int whichWeapon)
    {
        weaponAvailable[whichWeapon] = true;
    }
}
