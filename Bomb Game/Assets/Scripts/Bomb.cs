using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float shootForce;
    public Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * shootForce, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
