using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemy;
    Vector3 spawn;
    Pmovement player;
    bool gameOn;
    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<Pmovement>();
        gameOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.InCombat && gameOn)
        {
        for (int i = 1; i <= 3; i++)
            {
            Vector3 pos = new Vector3 (Random.Range(-10, 10), transform.position.y, transform.position.z);
            Instantiate(enemy, pos, transform.rotation);
            if (i == 3)
            {
                gameOn = false;
            }
            }
        
        }
    IEnumerator waitasecund() {
        yield return new WaitForSeconds(4);
    }
    }

}
