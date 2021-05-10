using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Profile", menuName = "Scriptable Object/Weapon Profile")]

public class WeaponsProfiles : ScriptableObject
{
    public List<WProfileObject> Profiles = new List<WProfileObject>();

}
