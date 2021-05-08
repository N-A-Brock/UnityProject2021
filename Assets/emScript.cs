using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emScript : MonoBehaviour
{

    
    public int spawningZones;
    public int waveSize;

    public int count;
    public int selection;

    public ScriptableObject enemyList;
    public ScriptableObject levelList;

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

            return(count);
        }
        waveSize = enemyCount()/spawningZones;
        if( ( enemyCount() % spawningZones) > 0)
        {
            waveSize++;
            enemies[0] = enemyCount() % spawningZones;
        }
        int[,] pattern = new int[spawningZones, waveSize];

        for (int i = spawningZones; i > 0; i--)
        {
            for (int j = 0; j < waveSize; j++) //comparison operator
            {
                selection = Random.Range(0, enemies.Length);

                pattern[i, j] = enemies[selection];
                enemies[selection] -= 1;
            }
        }
        return(pattern);
    }

    public void SpawnEnemyPattern()
    {

    }

}
