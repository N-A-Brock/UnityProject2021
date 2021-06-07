using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new wave list", menuName = "Scriptable Object/ Wave List")]
public class wavesScriptableObject : ScriptableObject
{
    public int numberOfWaves = 10;

    public int[][] waves = new int[][] { 
        new int[]{ 1, 1, 1, 1, 1 },
        new int[]{ 2, 1, 1, 2, 1 },
        new int[]{ 4, 3, 4, 4, 2 },
        new int[]{ 7, 7, 7, 2, 5 },
        new int[]{ 7, 6, 6, 7, 7 },
        new int[]{ 7, 8, 6, 9, 8 },
        new int[]{ 10, 9, 6, 9, 10 },
        new int[]{ 11, 13, 12, 10, 13 },
        new int[]{ 13, 14, 15, 11, 12 },
        new int[]{ 15, 15, 15, 15, 15 },

    };


}
