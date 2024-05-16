using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    
    public bool PlayerIsInBox;
    public float Speed;
    public float open;
    public float close;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIsInBox = GameObject.Find("GameObject").GetComponent<PlayerInBox>().PlayerInDoor;
        if (PlayerIsInBox && transform.position.x < open)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        } else if (!PlayerIsInBox && transform.position.x > close)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
