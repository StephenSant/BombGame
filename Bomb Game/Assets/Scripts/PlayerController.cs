using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float senY, senX;

    public CharacterController player;
    public GameObject cam;
    public GameObject bomb;

    private Vector3 spawnpoint;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera");
        spawnpoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Player movement
        Vector3 moveDir = (Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward).normalized * moveSpeed;
        player.Move(new Vector3 (moveDir.x, player.velocity.y, moveDir.z)* Time.deltaTime);
    
        //Camera movement
        cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));

        //Gravity
        if (!player.isGrounded)
        {
            player.SimpleMove( Vector3.down * 0.918f);
        }

        //Out of bounds
        if (transform.position.y <= 5)
        {
            transform.position = spawnpoint;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bomb,transform.position,cam.transform.rotation,null);
        }
    }
}
