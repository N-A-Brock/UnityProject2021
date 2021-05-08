using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public int health;
    public int startingHealth = 1;
    public GameObject collided;
    public bool isDamaged = false;

    public float nextShotTime;
    public int reload;
    public int aggression;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileStart;

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;

        nextShotTime = Time.time + Random.Range(3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            health -= collided.transform.GetComponent<projectilescript>().damage;
            Destroy(collided);
            isDamaged = false;
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }


        if(Time.time > nextShotTime)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(enemyProjectile, enemyProjectileStart.transform.position, new Quaternion(0, 0, 0, 0));

        nextShotTime = Time.time + Random.Range(reload, aggression);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            collided = col.gameObject;
            isDamaged = true;
        }
    }
}
