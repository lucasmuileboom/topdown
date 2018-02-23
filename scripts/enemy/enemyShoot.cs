using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    private float timer = 0;
    private WeaponStats weaponStats;
    private bool reloading = false;
    private Vector3 recoil;

    void Start ()
    {
        weaponStats = transform.GetChild(0).GetComponent<WeaponStats>();
    }
	void Update ()
    {
        timer -= Time.deltaTime;
        if (weaponStats.Ammo <= 0 && !reloading)
        {
            setReloadTime();
        }
        else if (reloading && timer <= 0)
        {
            reload();
        }
    }
    private void setReloadTime()
    {
        timer = weaponStats.Reloadtime;
        reloading = true;
    }
    private void reload()
    {
       weaponStats.Ammo = weaponStats.Magazinessize;
       reloading = false;
    }
    public void ShootCheck()
    {
        if (timer <= 0 && weaponStats.Ammo > 0 && !reloading)
        {
            shoot();
            timer = weaponStats.Firerate;
        }
    }
    private void shoot()
    {
        weaponStats.Ammo--;
        for (int i = 0; i < weaponStats.amountOfShots; i++)
        {
            recoil = new Vector3(0, Random.Range(-weaponStats.Recoil, weaponStats.Recoil), 0);
            GameObject _projectile = Instantiate(bullet, transform.position,Quaternion.Euler(transform.eulerAngles + recoil)) as GameObject;
            _projectile.GetComponent<projectile>().Speed = weaponStats.Bulletspeed;
            _projectile.GetComponent<projectile>().Damage = weaponStats.Damage;
            _projectile.GetComponent<projectile>().Range = weaponStats.Range;
        }
    }
}
