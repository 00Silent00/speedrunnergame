using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float spinSpeed = 10;
    private Rigidbody ObsticalRB;
    Vector3 EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        ObsticalRB = GetComponent<Rigidbody>();

        EulerAngleVelocity = new Vector3(0, spinSpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      ObsticalRB.AddTorque(Vector3.forward * spinSpeed * Time.deltaTime, ForceMode.Force);
           
    }
}
