using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody _Rigidbody;    
    private Vector3 move;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }
	private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        _Rigidbody.MovePosition((move.normalized * Speed * Time.deltaTime) + _Rigidbody.position);
    }
}
