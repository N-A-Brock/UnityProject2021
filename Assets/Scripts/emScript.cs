using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class emScript : MonoBehaviour
{

    
    public int spawningZones;
    public int waveSize;

    public int count;
    public int selection;
    
    //store enemies and slots in a scriptable object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[,] GenerateEnemyPattern(int[] enemies)
    {
        int enemyCount()
        {
            for (int i = 1; i < enemies.Length; i++)
            {
                count += enemies[i];
            }
            return (count);
        }
        waveSize = enemyCount() / spawningZones;
        if((enemyCount() % spawningZones) > 0)
        {
            waveSize++;
            enemies[0] = (enemyCount() % spawningZones);
        }
        int[,] pattern = new int[spawningZones, waveSize];

        for (int i = spawningZones; i >= 0; i--) // goes through each spawnzone in reverse order
        {
            for (int j = 0; j < waveSize; j++) //goes through each enemy slot in the spawnzone
            {
                selection = Random.Range(0, enemies.Length);

                pattern[i, 0] = enemies[selection];
                enemies[selection] -= 1;
            }
        }
        return(pattern); //unfuck this line of code >:((((((
    }

    public void SpawnEnemyPattern()
    {

    }
    // Spawn waves of enemies
    
    //Flexible System
    //Account for enemy types
    //Quantity of those types
    //Spawn in different places
    //Offset the spawn time

    //generate a pattern to spawn the enemies given # of enemies (5 parameters)
    //????????
    //multidimensional array (dimension one is spawning zone) (dimension two is order of enemies that spawn in that zone). DONE


    //spawn enemies given pattern (3 parameters) (array, time, numberofenemies)
    
}
