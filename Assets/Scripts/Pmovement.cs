using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Pmovement : MonoBehaviour
{
    public Rigidbody RB;
    public float speed = 2;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public bool IsOnGround = true;
    public float GravityMod;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= GravityMod;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            RB.AddForce(Vector3.up * 10, ForceMode.Impulse);
            IsOnGround = false;
        }
        HorizontalSpeed = Input.GetAxis("Horizontal");
        VerticalSpeed = Input.GetAxis("Vertical");
        RB.AddForce(Vector3.right * HorizontalSpeed * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
        RB.AddForce(Vector3.forward * VerticalSpeed * Time.fixedDeltaTime * speed,  ForceMode.VelocityChange);
        RB.drag = IsOnGround ? 15 : 0.01f;

        if (IsOnGround == false)
        {
            speed = 0;
        }else
        {
            speed = 10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = true;
    }
}
