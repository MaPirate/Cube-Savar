using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // یا  بسته به نیاز شما

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;

    [Header("Game Flow Panels")]
    public GameObject mainMenuPanel;
    public GameObject inGameHUDPanel;

    [Header("Player Components")]
    public PlayerMovement playerMovement;

    private bool isGameStarted = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(true);
        inGameHUDPanel.SetActive(false);
    }

    private void Update()
    {
        // با استفاده از سیستم ورودی جدید، اولین کلیک را تشخیص می‌دهیم
        if (!isGameStarted && Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (isGameStarted) return;
        isGameStarted = true;

        mainMenuPanel.SetActive(false);
        inGameHUDPanel.SetActive(true);

        if (playerMovement != null)
        {
            // اطمینان از اینکه تابع صحیح صدا زده می‌شود
            playerMovement.StartMoving();
        }
    }

    public void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = newScore.ToString();
        }
    }
}