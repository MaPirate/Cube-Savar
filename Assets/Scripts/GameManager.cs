using UnityEngine;
using TMPro; // برای دسترسی به کامپوننت‌های TextMeshPro
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    // ساخت یک نمونه استاتیک از این کلاس (الگوی Singleton)
    // این کار باعث میشه از هر جای بازی به این اسکریپت دسترسی داشته باشیم
    public static GameManager instance;
    // متغیر خصوصی برای نگهداری تعداد کریستال‌ها
    private int crystalCount;
    // متغیرهای جدید برای کنترل منوها و وضعیت بازی
    [Header("Game State")]
    public GameObject startMenu;
    public GameObject inGameMenu;
    public GameObject winPanel;

    public static bool isGameStarted; // برای اینکه از اسکریپت بازیکن بهش دسترسی داشته باشیم
    [Header("Crystal Show")]
    public TextMeshProUGUI winPanelCrystalText; // متن در پنل برنده شدن
    public TextMeshProUGUI startMenuCrystalText;  // متن در منوی اصلی
    public TextMeshProUGUI inGameMenuCrystalText;

    // این متد قبل از Start فراخوانی میشه
    void Awake()
    {
        // --- پیاده‌سازی الگوی Singleton ---
        // اگر نمونه‌ای از این کلاس وجود نداشت
        if (instance == null)
        {
            // این آبجکت رو به عنوان نمونه اصلی قرار بده
            instance = this;
            // این آبجکت با تغییر صحنه (مرحله) از بین نمیره
            DontDestroyOnLoad(gameObject);
        }
        // اگر نمونه‌ای از قبل وجود داشت
        else
        {
            // این آبجکت جدید رو از بین ببر تا فقط یک مدیر در بازی باشه
            Destroy(gameObject);
        }
    }

    // این متد در ابتدای بازی فراخوانی میشه
    void Start()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        // بارگذاری تعداد کریستال‌های ذخیره شده
        // PlayerPrefs یک حافظه دائمی ساده در یونیتی است
        // "CrystalCount" کلیدی است که با اون اطلاعات رو ذخیره می‌کنیم
        // 0 مقداریه که اگه کلیدی پیدا نشد، به عنوان پیش‌فرض برگردونده میشه
        crystalCount = PlayerPrefs.GetInt("CrystalCount", 0);

        // به‌روزرسانی متن UI با مقدار بارگذاری شده
        UpdateCrystalUI();

        isGameStarted = false;
        startMenu.SetActive(true);
        inGameMenu.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        // --- کد جدید ---
        // اگر بازی هنوز شروع نشده و کاربر صفحه را لمس/کلیک کرد
        if (!isGameStarted && Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            StartGame();
        }
    }

    // متد جدید برای شروع کردن بازی
    public void StartGame()
    {
        isGameStarted = true;

        // منوی شروع را غیرفعال و منوی داخل بازی را فعال کن
        startMenu.SetActive(false);
        inGameMenu.SetActive(true);

        Debug.Log("Game Started!");
    }


    // متدی برای اضافه کردن کریستال
    public void AddCrystal(int amount)
    {
        crystalCount += amount;
        Debug.Log(amount + " crystal(s) added. Total: " + crystalCount);

        // ذخیره مقدار جدید در حافظه دائمی
        PlayerPrefs.SetInt("CrystalCount", crystalCount);

        // به‌روزرسانی متن UI
        UpdateCrystalUI();
    }

    // متدی برای به‌روزرسانی نمایشگر کریستال
    // فایل: GameManager.cs

    private void UpdateCrystalUI()
    {
        // تعداد کریستال را یک بار به رشته تبدیل می‌کنیم تا بهینه باشد
        string crystalAmount = crystalCount.ToString();

        // حالا هر متنی که در Inspector وصل شده باشد را آپدیت می‌کنیم

        if (winPanelCrystalText != null)
            winPanelCrystalText.text = crystalAmount;

        if (startMenuCrystalText != null)
            startMenuCrystalText.text = crystalAmount;

        if (inGameMenuCrystalText != null)
            inGameMenuCrystalText.text = crystalAmount;
    }

    // تابع جدید برای ریستارت کردن بازی
    public void RestartGame()
    {
        // صحنه فعلی را از اول بارگذاری می‌کند
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerWon()
    {
        isGameStarted = false; // حرکت بازیکن را متوقف می‌کند
        winPanel.SetActive(true); // پنل برنده شدن را نمایش می‌دهد
        inGameMenu.SetActive(false); // منوی داخل بازی را مخفی می‌کند
    }

    // تابعی که برای رفتن به مرحله بعد استفاده می‌شود
    public void LoadNextLevel()
    {
        // شماره صحنه (مرحله) فعلی را می‌گیرد
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // به شماره صحنه یکی اضافه می‌کند تا به مرحله بعد برویم
        int nextSceneIndex = currentSceneIndex + 1;

        // چک می‌کند که آیا مرحله بعدی اصلاً وجود دارد یا نه
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // اگر وجود داشت، آن را بارگذاری می‌کند
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // اگر مرحله آخر بود، به مرحله اول برمی‌گردد
            Debug.Log("You completed all levels! Restarting from level 1.");
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
        // این دستور در نسخه ساخته شده (build) بازی، آن را می‌بندد.
        Application.Quit();

        // این بخش برای تست در ادیتور یونیتی است، چون Application.Quit در ادیتور کار نمی‌کند
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}