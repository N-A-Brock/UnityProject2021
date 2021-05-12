using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new enemyList", menuName = "Scriptable Object/ Enemy List")]

public class enemyScriptableObject : ScriptableObject
{
    public GameObject blank0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public GameObject[] enemies;

    private void OnEnable()
    {
        enemies[0] = blank0;
        enemies[1] = enemy1;
        enemies[2] = enemy2;
        enemies[3] = enemy3;
        enemies[4] = enemy4;
        enemies[5] = enemy5;
    }
}
