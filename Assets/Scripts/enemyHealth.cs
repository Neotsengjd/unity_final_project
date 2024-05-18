using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    //public bool drops;

    public bool isZombie;
    public bool isBarrel;
    //public GameObject drop;
    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    public GameObject burnEffects;
    public GameObject[] dropItems;
    private int randomSeed;
    bool onFire;
    float nextBurn;
    float burnInterval = 1f;
    float endBurn;

    float currentHealth;
    public Slider enemyHealthIndicator;
    AudioSource enemyAS;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        randomSeed = Random.Range(0, 3);
        if(onFire && Time.time > nextBurn) {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire && Time.time > endBurn) {
            onFire = false;
            burnEffects.SetActive(false);
        }
    }

    public void addDamage(float damage) {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if(damage <= 0f) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        enemyAS.Play();
        if(currentHealth <= 0) makeDead();
    }
    public void damageFX(Vector3 point, Vector3 rotation) {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }
    public void addFire() {
        if(!canBurn) return;
        onFire = true;
        burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;
    }
    void makeDead() {
        zombieController aZombie = GetComponentInChildren<zombieController>();
        if(aZombie != null)
        {
            aZombie.ragdollDeath();
        }
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 10f);
        Destroy(gameObject.transform.root.gameObject);
        if(isZombie) 
        {
            if(randomSeed == 0)
                Instantiate(dropItems[0], transform.position, Quaternion.identity);
            else if(randomSeed == 1)
                Instantiate(dropItems[1], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(dropItems[0], transform.position, Quaternion.identity);
        }
    }
}
