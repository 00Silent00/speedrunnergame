using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInBox : MonoBehaviour
{
    public bool PlayerInDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInDoor = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInDoor = false;
        }
    }
}
