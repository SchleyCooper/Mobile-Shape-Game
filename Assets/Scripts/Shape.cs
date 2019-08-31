using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private int    value = 2;

    public int Value { get { return value; } }

    [SerializeField] private float  shrinkSpeed = 3f;

    private Rigidbody2D rb;

    private TextMeshProUGUI scoreText;

    private int score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.magnitude < 0.5f)
        {

            Destroy(gameObject);
        }
    }
}
