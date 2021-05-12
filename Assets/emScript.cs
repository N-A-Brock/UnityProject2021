using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emScript : MonoBehaviour
{

    public int spawningZones;
    public int waveSize;

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

    public enemyScriptableObject enemyList;
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




        for (int i = spawningZones; i > 0; i--)
        {
            for (int j = 0; j < waveSize; j++) //comparison operator
            {
                selection = Random.Range(0, enemies.Length);

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


        Instantiate(enemyList.enemies[_pattern[0, 0]] , iP[Random.Range(0, iP.Length - 1)].transform.position , new Quaternion(0, 0, 0, 0));


    }

}
