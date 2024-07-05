using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimasion : MonoBehaviour
{
    private Animation anim;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PlayerIsClose", true);
        }
    } 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PlayerIsClose", false);
        }
    }
    
        
    

}
