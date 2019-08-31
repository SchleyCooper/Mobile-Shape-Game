using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 30f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveRadius = 1f;
    [SerializeField] private Vector2 moveTimerRange = new Vector2(5f, 10f);

    private float moveTimer;
    private Vector3 currentDest;
    private Vector3 velocity = Vector3.zero;
    private float randTime;

    // Start is called before the first frame update
    void Start()
    {
        randTime = Random.Range(moveTimerRange.x, moveTimerRange.y);
        moveTimer = Time.time + randTime;
        currentDest = new Vector3(Random.Range(0, moveRadius), Random.Range(0, moveRadius), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        transform.position = Vector3.SmoothDamp(transform.position, currentDest, ref velocity, randTime);
    }

    private void LateUpdate()
    {
        if (Time.time >= moveTimer)
        {
            moveTimer = Time.time + Random.Range(moveTimerRange.x, moveTimerRange.y);
            currentDest = new Vector3(Random.Range(-moveRadius, moveRadius), Random.Range(-moveRadius, moveRadius), transform.position.z);
        }
        transform.LookAt(Vector3.zero, transform.up);
    }
}
