using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 StartPos;
    public Vector3 ToPos;
    public float speed = 1.0f;
    public float waitTime = 2.0f; // Time to wait at each point
    private bool BackForward = false;
    private float t = 0.0f;
    private bool isWaiting = false;

    void Start()
    {
        StartPos = transform.position; // Ensure the starting position is set correctly
    }

    void Update()
    {
        if (isWaiting) return;

        if (!BackForward)
        {
            // Move from StartPos to ToPos
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(StartPos, ToPos, t);

            if (t >= 1.0f)
            {
                t = 0.0f;
                BackForward = true;
                StartCoroutine(WaitAtPoint());
            }
        }
        else
        {
            // Move from ToPos to StartPos
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(ToPos, StartPos, t);

            if (t >= 1.0f)
            {
                t = 0.0f;
                BackForward = false;
                StartCoroutine(WaitAtPoint());
            }
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}
