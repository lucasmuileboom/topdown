using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField]private int health;

	public void TakeDamage(int damage)//kockback??
	{
		health -= damage;
		if(health <= 0)
		{
			print ("GameOver");
			Destroy (this.gameObject);
		}
	}
}
