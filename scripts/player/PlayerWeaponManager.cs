using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
	private int CurrentWeapon = 0;
	private PlayerShooting PlayerShooting;

	void Awake () 
	{
		PlayerShooting = GetComponent<PlayerShooting> ();
	}
	public void SwitchWeapon(int index)
	{
		for (int i = 0; i < transform.childCount; i++) 
		{
			if (i == index) 
			{
				transform.GetChild (i).gameObject.SetActive (true);
				PlayerShooting.WeaponStats = transform.GetChild (i).GetComponent<WeaponStats> ();
			} else 
			{
				transform.GetChild (i).gameObject.SetActive (false);
			}
		}
		PlayerShooting.NewWeapon ();
	}
	void Start () 
	{
		CurrentWeapon = 0;
		SwitchWeapon (CurrentWeapon);
	}
	void Update () 
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0f )
		{
			CurrentWeapon++;
			if(CurrentWeapon > transform.childCount - 1)
			{
				CurrentWeapon = 0;
			}
			SwitchWeapon (CurrentWeapon);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0f )
		{
			CurrentWeapon--;
			if(CurrentWeapon < 0)
			{
				CurrentWeapon = transform.childCount - 1;
			}
			SwitchWeapon (CurrentWeapon);
		}
		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			CurrentWeapon = 0;
			SwitchWeapon (CurrentWeapon);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			CurrentWeapon = 1;
			SwitchWeapon (CurrentWeapon);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			CurrentWeapon = 2;
			SwitchWeapon (CurrentWeapon);
		}
	}
}
