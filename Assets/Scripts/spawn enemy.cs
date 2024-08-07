using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemy;
    Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
         Vector3 pos = new Vector3 (Random.Range(-10, 10), transform.position.y, transform.position.z);
        Instantiate(enemy, pos, transform.rotation);
        }
        
        
        }

}
