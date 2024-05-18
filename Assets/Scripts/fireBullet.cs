using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireBullet : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;
    //bullet info
    public Slider playerAmmoSlider;
    public int maxRounds;
    public int startingRounds;
    int remainingRounds;

    float nextBullet;

    //audio info
    AudioSource gunMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    //graphic info
    public Sprite weaponSprite;
    public Image weaponImage;


    // Start is called before the first frame update
    void Awake()
    {
        nextBullet = 0f;
        remainingRounds = startingRounds;
        playerAmmoSlider.maxValue = maxRounds;
        playerAmmoSlider.value = remainingRounds;

        gunMuzzleAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerController myPlayer = transform.root.GetComponent<playerController>();

        if(Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time && remainingRounds > 0)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else
            {
                rot = new Vector3(0, 90, 0);
            }

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            playSound(shootSound);

            remainingRounds -= 1;
            playerAmmoSlider.value = remainingRounds;
        }
    }

    public void reload()
    {
        remainingRounds = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        playSound(reloadSound);
    }

    void playSound(AudioClip playTheSound)
    {

        gunMuzzleAS.clip = playTheSound;
        gunMuzzleAS.Play();
    }

    public void initializeWeapon()
    {
        Debug.Log("in");
        gunMuzzleAS.clip = reloadSound;
        gunMuzzleAS.Play();
        nextBullet = 0;
        playerAmmoSlider.maxValue = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        weaponImage.sprite = weaponSprite;
    }
}
