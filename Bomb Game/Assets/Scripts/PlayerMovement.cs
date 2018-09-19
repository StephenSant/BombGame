using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject camera;
    public GameObject bomb;
    public Rigidbody rigidbody;
    public float senY;
    public float senX;
    public float maximumY = 90;
    public float minimumY = -90;
    private bool grounded;
    float rotationY = 0.0f;
    Vector3 moveDir;

    // Use this for initialization
    void Start ()
    {
        camera = GameObject.Find("Main Camera");
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update ()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal")*5, rigidbody.velocity.y, Input.GetAxis("Vertical") * 5);
        moveDir = transform.TransformDirection(moveDir);//makes the player go in the direction its facing.
        rigidbody.velocity = moveDir;

        if (Time.deltaTime == 0)//if the game is paused: lock vertical axis
        {
            rotationY = rotationY;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * senY;//gets input for y axis
        }
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//make the player not break his neck if he looks too far up or down
        camera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//sets the cameras vertical direction
        transform.Rotate(0, Input.GetAxis("Mouse X") * (senX * 100) * Time.deltaTime, 0);//sets the horizontal direction

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bomb, camera.transform.position, camera.transform.rotation);
        }
    }
}
