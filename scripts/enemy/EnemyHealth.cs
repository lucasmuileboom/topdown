using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	[SerializeField]private int health;
	
	public void TakeDamage(int damage)//kockback??
	{
		print (damage);
		health -= damage;
		if(health <= 0)
		{
			Destroy (this.gameObject);
		}
	}
}
