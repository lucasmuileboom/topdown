using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private Text guntxt;//
    [SerializeField]private GameObject projectile;
	public WeaponStats WeaponStats;
	private Vector3 mouseposition;//
    private Vector3 recoil;
    private bool mouse0;//
	private float timer = 0;
	private float reloadtimer = 0;
	private bool reloading = false;

    private void Start ()
	{
		guntxt.text = "7/7";
	}
	private void Update()
    {
		if (Input.GetMouseButtonDown (0))
		{
			mouse0 = true;
		}
		else if (Input.GetMouseButtonUp (0))
		{
			mouse0 = false;
		}
		if (!reloading && Input.GetKeyDown (KeyCode.R))
		{
			SetReloadTime ();
		}
		if(mouse0 && timer <=0  && !reloading &&  WeaponStats.Ammo >0)
		{
			Shoot ();
			timer = WeaponStats.Firerate;
		}
		else if(reloadtimer <=0 && reloading)
		{
			Reload ();
		}
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(mouseposition.x, 0, mouseposition.z));
        timer -= Time.deltaTime;
		reloadtimer -= Time.deltaTime;
    }
	private void Shoot()
    {
		WeaponStats.Ammo--;
        for (int i = 0; i < WeaponStats.amountOfShots; i++)
        {
            guntxt.text = WeaponStats.Ammo.ToString() + "/" + WeaponStats.Magazinessize.ToString();
            recoil = new Vector3(0, Random.Range(-WeaponStats.Recoil, WeaponStats.Recoil), 0);
            GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.Euler(transform.eulerAngles + recoil)) as GameObject;
            _projectile.GetComponent<projectile>().Speed = WeaponStats.Bulletspeed;
            _projectile.GetComponent<projectile>().Damage = WeaponStats.Damage;
            _projectile.GetComponent<projectile>().Range = WeaponStats.Range;
        }
    }
	private void SetReloadTime()
	{
		reloading = true;
		guntxt.text = "R";
		reloadtimer = WeaponStats.Reloadtime;
	}
	private void Reload()
	{
		WeaponStats.Ammo = WeaponStats.Magazinessize;
		guntxt.text = WeaponStats.Ammo.ToString() +"/"+ WeaponStats.Magazinessize.ToString();
		reloading = false;
	}
	public void NewWeapon()
	{
		guntxt.text = WeaponStats.Ammo.ToString() +"/"+ WeaponStats.Magazinessize.ToString();
	}
}