using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damage;
    public float speed;

    private int maxX = 100;
    private int minX = -100;

    public enum Direction
    {
        left,
        right
    }
    public Direction direction = Direction.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Direction.left)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if(direction == Direction.right)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(this.transform.position.x >= maxX || this.transform.position.x <= minX)
        {
            Destroy(this.gameObject);
        }
    }
}
