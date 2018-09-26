using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public bool win = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Ball"))
        {
            win = true;
        }
    }
    private void OnGUI()
    {
        float scrX = Screen.height / 9;
        float scrY = Screen.width / 16;
        if (win)
        {
            GUI.Box(new Rect(scrX * 6, scrY * 5, scrX * 5, scrY * 1), "You winner");
        }
    }
}
