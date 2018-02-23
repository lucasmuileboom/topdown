using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private string target;
    private Rigidbody _rigidbody;
    public int Damage;
	public float Range;
    public float Speed;
    private float timer;
    

	private void Start () 
	{
		timer = Range;
        _rigidbody = GetComponent<Rigidbody>();
    }

	private void Update () 
	{
		timer -= Time.deltaTime;
        _rigidbody.AddForce(transform.forward * Speed);
        if (timer <=0)
		{
			Destroy (this.gameObject);
		}
	}
	private void OnTriggerEnter(Collider collision)
	{
		if(collision.tag == target)
		{
			collision.GetComponent<EnemyHealth> ().TakeDamage(Damage);
			Destroy (this.gameObject);
		}
        if (collision.name == target)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
