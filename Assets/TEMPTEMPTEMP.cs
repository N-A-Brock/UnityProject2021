using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPTEMPTEMP : MonoBehaviour
{
    public GameObject enemyHolder;

    public GameObject aZ_0;
    public GameObject aZ_1;
    public GameObject aZ_2;
    public GameObject aZ_3;
    public GameObject aZ_4;

    public GameObject[] arenaZones;

    public GameObject iP_0;
    public GameObject iP_1;
    public GameObject iP_2;

    public GameObject[] instantiationPoints;

    public int spawnedEnemyCount;
    public int maxEnemiesOnScreen;
    public int enemiesInWave;
    public int currentWaveNumber;
    public int[] currentWave;
    public int[][] wavesInLevel;

    public enemyScriptableObject enemyList;
    public wavesScriptableObject levelList;

    // Start is called before the first frame update
    void Start()
    {
        arenaZones = new GameObject[5] { aZ_0, aZ_1, aZ_2, aZ_3, aZ_4 };
        instantiationPoints = new GameObject[3] { iP_0, iP_1, iP_2 };

        spawnedEnemyCount = 0;
        currentWaveNumber = -1;

        SpawnNextWave(levelList.waves[currentWaveNumber + 1]);
    }

    // Update is called once per frame
    void Update()
    {

        if(spawnedEnemyCount == enemiesInWave && enemyHolder.transform.childCount == 0)
        {
            if(true)
            {
                //
            }
        }

    }

    //{0, 1, 2, 3, 4, 5}

    public int[] LevelAmountToWaves(int[] waveAmount)
    {
        for (int j = 0; j < waveAmount.Length; j++)
        {
            enemiesInWave += waveAmount[j];
        }


        int[] temp = new int[enemiesInWave];


        for(int i = 0; i < enemiesInWave; i++)
        {
            int selection = Random.Range(0, (waveAmount.Length));

            if(waveAmount[selection] > 0 && selection != 5)
            {
                temp[i] = selection;
                waveAmount[selection] -= 1;
            }
            else
            {
                i--;
            }

        }

        return(temp);
    }

    public void SpawnEnemy()
    {

    }

    public void SpawnNextWave(int[] nextWave)
    {
        currentWaveNumber++;
        currentWave = LevelAmountToWaves(nextWave);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyList.enemies[currentWave[i]], instantiationPoints[Random.Range(0, instantiationPoints.Length - 1)].transform.position, new Quaternion(0, 0, 0, 0), enemyHolder.transform);
            spawnedEnemyCount++;
        }
        Debug.Log("Spawning wave: " + currentWaveNumber);
    }
    
    public void Win()
    {
        //Heheheh
    }

}
