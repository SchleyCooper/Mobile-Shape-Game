using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; internal set; }

    [SerializeField] private float hueShift = 0.05f;

    private Image           colorOverlay;
    private TextMeshProUGUI scoreText;
    private Slider          experienceSlider;

    private Color newColor = Color.white;
    private Vector3 hsv = Vector3.one;

    private bool isGameRunning = false;

    private int currentScore;

    private void Awake()
    {
        // Set singleton for HUDManager
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        colorOverlay = GameObject.Find("ColorOverlay").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        experienceSlider = GameObject.Find("ExperienceSlider").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeColorOverlay();

        experienceSlider.maxValue = GameManager.Instance.experienceThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColorOverlay();

        currentScore = GameManager.Instance.Score;
        experienceSlider.value = currentScore % experienceSlider.maxValue;
        scoreText.text = currentScore.ToString();
    }

    public void StartGame(bool isDemo = false)
    {

    }

    private void InitializeColorOverlay()
    {
        // Get random hue to begin
        Color.RGBToHSV(colorOverlay.color, out hsv.x, out hsv.y, out hsv.z);
        hsv = new Vector3(Random.Range(0f, 1f), 1f, 1f);
        newColor = Color.HSVToRGB(hsv.x, hsv.y, hsv.z);
        newColor.a = colorOverlay.color.a;
        colorOverlay.color = newColor;
    }

    private void UpdateColorOverlay()
    {
        Color.RGBToHSV(colorOverlay.color, out hsv.x, out hsv.y, out hsv.z);

        hsv.x += hueShift * Time.deltaTime;
        if (hsv.x >= 360f)
            hsv.x = 0;

        newColor = Color.HSVToRGB(hsv.x, hsv.y, hsv.z);
        newColor.a = colorOverlay.color.a;
        colorOverlay.color = newColor;
    }
}
