using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Pmovement : MonoBehaviour
{
    [Header("Animation")]
    public Animator spearanim;
    public Animator enteranim;
    [Header("resten")]
    public Rigidbody RB;
    public float speed;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public bool IsOnGround = true;
    bool Jumpable = true;
    public float GravityMod;
    public float walkingSpeed = 60;
    public float runningSpeed = 90;
    public float sensitivity = 10;
    public float jumpForce;
    public GameObject JumpObject;
    public float jumprad;
    float mousex;
    float mousey;
    public  Vector3 spawnpoint;
    private bool canAttack = true;
    public GameObject spear;
    // Start is called before the first frame update
    void Start()
    {
        spear.gameObject.SetActive(false);
        Physics.gravity *= GravityMod;
        spawnpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Jumping();
        HorizontalSpeed = Input.GetAxis("Horizontal");
        VerticalSpeed = Input.GetAxis("Vertical");
        
        if (IsOnGround == false)
        {
            speed = 3;
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
        transform.Rotate(0, mousex * Time.unscaledDeltaTime * sensitivity, 0);

        if (transform.position.y < -5)
        {
            transform.position = spawnpoint;
        }

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            spearanim.SetTrigger("LungSpear");
            canAttack = false;
            StartCoroutine(IsAbleToAttack());
        }
    
        
    }
    void FixedUpdate()
    {}

    IEnumerator IsAbleToAttack() 
    {
        yield return new WaitForSeconds (0.5f);
        canAttack = true;
    }

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

        RB.drag = IsOnGround ? 10 : 0.1f;

    }
    IEnumerator JumpDelay(){
        Jumpable = false;
        yield return new WaitForSeconds(0.1f);
        Jumpable = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("spawnpoint"))
        {
            spawnpoint = transform.position;
        }
        if (other.gameObject.CompareTag("SpearGiver"))
        {
            spear.gameObject.SetActive(true);
            enteranim.SetBool("PlayerEnter", true);
            Debug.Log("Hit Trigger in door");
        }
    }
    IEnumerator CancelAnim(){
        yield return new WaitForSeconds(3);
        enteranim.SetBool("PlayerEnter", false);
    }

}
