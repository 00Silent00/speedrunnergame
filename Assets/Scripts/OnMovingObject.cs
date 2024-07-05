using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMovingObject : MonoBehaviour
{
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
    if (other.gameObject.CompareTag("Player"))
    {
        other.transform.SetParent(transform);
    }
}
void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        other.transform.SetParent(null);
    }
}
}

