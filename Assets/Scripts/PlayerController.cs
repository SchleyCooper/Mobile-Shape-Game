using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 600f;

    [SerializeField] private float touchThresholdFromCenter = 200f;

    [HideInInspector] public bool isDemoMode = false;

    private ShapeSpawner spawner;

    private float       movement = 0f;

    // simulation fields
    private Shape       nextShape;
    private Quaternion  targetRotation = new Quaternion();
    private float       angle;

    [SerializeField] private float rotMatchSpeed = 5.0f;


    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<ShapeSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isDemoMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDemoMode)
        {
            nextShape = spawner.GetNextShape();
            if (nextShape)
            {
                targetRotation = nextShape.transform.rotation;
                angle = Quaternion.Angle(transform.rotation, targetRotation);
                angle = angle * (targetRotation.eulerAngles.z < transform.rotation.eulerAngles.z ? -1 : 1);
            }

            transform.RotateAround(Vector3.zero, Vector3.forward, angle * rotMatchSpeed * Time.deltaTime);
        }
        else
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
            transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * moveSpeed * -movement);

        }

    }

    //private void FixedUpdate()
    //{
    //    transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * moveSpeed * -movement);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
