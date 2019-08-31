using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] prefabs;

    [SerializeField]
    private float nextTimeToSpawn = 0f;

    private Queue<Shape> spawnedShapes;
    private Shape incomingShape;

    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        spawnedShapes = new Queue<Shape>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            spawnedShapes.Enqueue(Instantiate(prefabs[Random.Range(0, prefabs.Length)], Vector3.zero, Quaternion.identity).GetComponent<Shape>());
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }

        if (spawnedShapes.Count > 0 && (incomingShape = spawnedShapes.Peek()) == null)
        {
            GameManager.Instance.AddPoints(incomingShape.Value);
            spawnedShapes.Dequeue();
        }
    }
}
