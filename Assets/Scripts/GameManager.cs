using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; internal set; }

    public int experienceThreshold = 100;

    private int score;

    public int Score { get { return score; } }

    private void Awake()
    {
        // Set singleton for GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(bool isDemo = false)
    {

    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }
}
