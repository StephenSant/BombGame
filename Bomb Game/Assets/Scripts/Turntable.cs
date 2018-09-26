using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{

    public float turnAmount = 0.0f;
    private Rigidbody myRB;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 yRot = new Vector3(0, 1, 0);
        myRB.AddTorque(yRot * turnAmount);
	}
}
