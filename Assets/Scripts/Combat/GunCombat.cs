using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunStats))]
public class GunCombat : MonoBehaviour
{
    //initialises stats of the gun
    GunStats myStats;

    //when the script is loaded, gets the stats about the gun
    void Start()
    {
        myStats = GetComponent<GunStats>();
    }

    //method that deals attack to the enemy
    public void Attack(CharacterStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue());
    }

}
