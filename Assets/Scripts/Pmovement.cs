using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Pmovement : MonoBehaviour
{
    public Rigidbody RB;
    public float speed;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public bool IsOnGround = true;
    bool Jumpable = true;
    public float GravityMod;
    float walkingSpeed = 60;
    float runningSpeed = 90;
    public float sensitivity = 10;
    public float jumpForce;
    public GameObject JumpObject;
    public float jumprad;
    float mousex;
    float mousey;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= GravityMod;
        
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
        HorizontalSpeed = Input.GetAxis("Horizontal");
        VerticalSpeed = Input.GetAxis("Vertical");
        if (IsOnGround == false)
        {
            speed = 0;
        }else if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }else
        {
            speed = walkingSpeed;
        }
        RB.AddForce(transform.right * HorizontalSpeed * Time.deltaTime * speed, ForceMode.VelocityChange);
        RB.AddForce(transform.forward * VerticalSpeed * Time.deltaTime * speed,  ForceMode.VelocityChange);

        mousex = Input.GetAxis("Mouse X");
        mousey = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mousex * Time.deltaTime * sensitivity, 0);
        Debug.Log(RB.drag);

 


        
    }
    void FixedUpdate()
    {}

    void Jumping(){
        IsOnGround = false;
        foreach(Collider i in Physics.OverlapSphere(JumpObject.transform.position, jumprad)){
            if(i.transform.tag != "Player"){
                IsOnGround = true;
                break;
            }
        }
        if(IsOnGround){
            if(Input.GetKeyDown(KeyCode.Space) && Jumpable == true){
                StartCoroutine(JumpDelay());
                RB.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
            }
        }

        RB.drag = IsOnGround ? 15 : 0.1f;

    }
    IEnumerator JumpDelay(){
        Jumpable = false;
        yield return new WaitForSeconds(0.1f);
        Jumpable = true;
    }
}
