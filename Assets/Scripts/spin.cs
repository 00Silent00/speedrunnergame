using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float spinSpeed = 10;
    private Rigidbody ObsticalRB;
    // Start is called before the first frame update
    void Start()
    {
        ObsticalRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ObsticalRB.AddTorque(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
