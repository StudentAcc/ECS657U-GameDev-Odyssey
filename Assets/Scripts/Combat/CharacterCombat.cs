using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
	//initialise attack speed and rate
	public float attackSpeed = 1f;
	private float attackCooldown = 0f;
	//public float attackDelay = .6f;
	//public event System.Action OnAttack;
	
	//initialises stats of character
	CharacterStats myStats;

	//when script is loaded, gets the stats of the character
    void Start ()
    {
		myStats = GetComponent<CharacterStats>();
    }

	//cooldown goes down per frame
	void Update()
	{
		attackCooldown -= Time.deltaTime;
	}

	//method that lower's the enemy health based on cooldown and attack speed
	public void Attack(CharacterStats targetStats)
	{
		if (attackCooldown <= 0f)
		{
			//StartCoroutine(DoDamage(targetStats, attackDelay));
			targetStats.TakeDamage(myStats.damage.GetValue());

			//if (OnAttack != null)
			//	OnAttack();

			attackCooldown = 1f / attackSpeed;
		}

	}

	//IEnumerator DoDamage(CharacterStats stats, float delay)
	//{
	//	yield return new WaitForSeconds(delay);
	//	stats.TakeDamage(myStats.damage.GetValue());
	//}

}
