using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 600f;

    private float movement = 0f;

    [SerializeField] private float touchThresholdFromCenter = 200f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {   // check for mouse/touch input in relation to middle of screen
            movement = (Input.mousePosition.x < Screen.width / 2 - touchThresholdFromCenter) ? -1 
                : (Input.mousePosition.x > Screen.width / 2 + touchThresholdFromCenter ? 1 : 0);
        }
        else
        {   // check for normal button input
            movement = Input.GetAxisRaw("Horizontal");

        }

    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * moveSpeed * -movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
