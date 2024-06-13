using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    Vector3 SendBackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 SendBackPlayer = FindObjectOfType<Pmovement>().spawnpoint;
            collision.gameObject.transform.position = SendBackPlayer;
        }
    }
}
