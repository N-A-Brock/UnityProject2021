using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public int playerHealth;
    private int playerStartingHealth = 3;
    public int playerMaxHealth;
    public bool isDamaged = false;
    public GameObject collisionObject;

    public GameObject player;
    public float speed;

    public GameObject projectile;
    public GameObject projectileStartLeft;
    public GameObject projectileStartRight;
    public side nextShot;

    public enum side
    {
        left,
        right
    }

    public float reloadTime;
    public float nextShotTime;


    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-10, 0, 0);
        player.transform.position = startPosition;


        playerHealth = playerStartingHealth;
        playerMaxHealth = playerStartingHealth;

        nextShotTime = Time.time + reloadTime;
    }

    // Update is called once per frame
    void Update()
    {   
        player.transform.rotation = new Quaternion(0, 0, 0, 0);

        Move();

        if(Time.time > nextShotTime)
        {
            Shoot();
        }

        if (isDamaged)
        {
            playerHealth -= collisionObject.transform.GetComponent<projectilescript>().damage;
            Destroy(collisionObject);
            isDamaged = false;
        }
    }

    public void Shoot()
    {

        if (Input.GetKey("space"))
        {

            scoreScript.score += 5;
            if(nextShot == side.left)
            {
                Instantiate(projectile, projectileStartLeft.transform.position, new Quaternion(0, 0, 0, 0));
                nextShot = side.right;
            }
            else if (nextShot == side.right)
            {
                Instantiate(projectile, projectileStartRight.transform.position, new Quaternion(0, 0, 0, 0));
                nextShot = side.left;
            }
            nextShotTime = Time.time + reloadTime;
        }

        
    }

    public void Move()
    {
        if (Input.GetKey("up"))
        {
            player.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey("down"))
        {
            player.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        
        /*
        if (Input.GetKey("left"))
        {
            player.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("right"))
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyprojectile")
        {
            collisionObject = collision.gameObject;
            isDamaged = true;
        }
    }
}
