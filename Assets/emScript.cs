using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emScript : MonoBehaviour
{

    public int spawningZones;
    public int waveSize;

    public int wave;

    public int maxEnemiesOnScreen;
    public bool lastEnemySpawned;

    public int count;
    public int selection;

    public GameObject sZ_0;
    public GameObject sZ_1;
    public GameObject sZ_2;
    public GameObject sZ_3;
    public GameObject sZ_4;

    public GameObject iP_0;
    public GameObject iP_1;
    public GameObject iP_2;

    public GameObject enemyHolder;

    public enemyScriptableObject enemyList;
    public wavesScriptableObject levelList;

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        SpawnEnemyPattern(GenerateEnemyPattern(levelList.waves[0])); //HERE DIPSHIT
    }

    // Update is called once per frame
    void Update()
    {
        if(lastEnemySpawned)
        {
            if (wave <= (levelList.numberOfWaves - 1))
            {
                wave++;
                SpawnEnemyPattern(GenerateEnemyPattern(levelList.waves[wave]));//HERE DIPSHIT
            }
            else
            {
                Debug.Log("You WIN!!!");
            }
        }
    }

    public int[,] GenerateEnemyPattern(int[] enemies)
    {
        //Defines size of return array
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


        //Create the return array
        int[,] pattern = new int[spawningZones, waveSize];
        Debug.Log("sZ: " + spawningZones + "\twS: " + waveSize);



        for (int i = (spawningZones - 1); i >= 0; i--)//HERE DIPSHIT
        {
            for (int j = 0; j < waveSize; j++)
            {
                selection = Random.Range(0, enemies.Length);

                Debug.Log("i: " + i + "\tj: " + j);
                //Note
                pattern[i, j] = selection;
                enemies[selection] -= 1;
            }
        }
        return(pattern);
    }

    public void SpawnEnemyPattern(int[,] _pattern)
    {
        GameObject[] iP = new GameObject[] {iP_0, iP_1, iP_2 };
        GameObject[] sZ = new GameObject[] { sZ_0, sZ_1, sZ_2, sZ_3, sZ_4 };
        lastEnemySpawned = false;
        
        for (int x = 0; x < sZ.Length; x++)
        {
            for (int y = 0; y < (_pattern.Length/sZ.Length); y++)
            {

                if(enemyHolder.transform.childCount < maxEnemiesOnScreen)
                {
                    Instantiate(enemyList.enemies[_pattern[x, y]], iP[Random.Range(0, iP.Length - 1)].transform.position, new Quaternion(0, 0, 0, 0), enemyHolder.transform);
                    Debug.Log("Spawned enemy of type: " + _pattern[x, y] + "in spawn zone: " + x);
                }
                else
                {
                    y--;
                    x--;
                }
            }
        }

        lastEnemySpawned = true;
    }

}
