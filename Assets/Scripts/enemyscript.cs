using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Health
    public int health;
    public int startingHealth;

    //Movement
    public int speed;

    //Collision
    public GameObject collided;

    //Shooting
    public int accuracyRange;
    public float reloadMin;
    public float reloadMax;

    public int primaryProjectileStartAmount;
    public GameObject primaryProjectile;
    public GameObject[] primaryProjectileStart;

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;

        primaryProjectileStart = new GameObject[primaryProjectileStartAmount];
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public virtual bool IsAimed()
    {
        if(Mathf.Abs(this.transform.position.y - PlayerScript.globalPlayer.transform.position.y) > accuracyRange)
        {
            this.transform.position = Vector2.MoveTowards(
                new Vector2(this.transform.position.x, this.transform.position.y), 
                new Vector2(this.transform.position.x, PlayerScript.globalPlayer.transform.position.y), 
                Time.deltaTime * speed);

            return(false);
        }
        else
        {
            return(true);
        }

        
        
    }

    public virtual void Shoot()
    {
        if(IsAimed())
        {
            if(primaryProjectileStart.Length == 1)
            {
                Instantiate(primaryProjectile, primaryProjectileStart[0].transform.position, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                int count = 0;
                if (count > primaryProjectileStart.Length)
                {

                }
                Instantiate(primaryProjectile, primaryProjectileStart[count-1].transform.position, new Quaternion(0, 0, 0, 0));
                
            }
            
        }
        
    }

    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            collided = col.gameObject;
            TakeDamage(col.transform.GetComponent<ProjectileScript>().damage);
        }
    }
}
