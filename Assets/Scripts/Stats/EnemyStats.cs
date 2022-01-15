using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Stats for enemy NPCs, child of CharacterStats

    //public ParticleSystem takeDamageAnimation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void TakeDamage (int damage)
    {
        base.TakeDamage(damage);
        //GetComponentInChildren<ColourLerper>().ColourChangeActivate();
        this.gameObject.GetComponent<EnemyController>().DamageTaken();
        //takeDamageAnimation.Play();
    }

}
