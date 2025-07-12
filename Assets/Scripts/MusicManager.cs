using UnityEngine;
using UnityEngine.UI; // این خط برای کار با کامپوننت‌های UI مثل Image و Button ضروریه
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    // آبجکت AudioSource که موسیقی رو پخش می‌کنه
    private AudioSource musicSource;

    // دکمه‌ای که برای کنترل موسیقی استفاده می‌شه
    public Image musicButtonImage; // به جای کل دکمه، فقط کامپوننت عکسش رو می‌گیریم که بهینه تره

    // آیکون‌های حالت روشن و خاموش
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;

    // یک متغیر برای اینکه بدونیم موسیقی روشنه یا خاموش
    private bool isMusicOn = true;

    public Slider volumeSlider;

    void Start()
    {
        // در شروع بازی، کامپوننت AudioSource رو از همین آبجکت می‌گیریم
        musicSource = GetComponent<AudioSource>();
        // مقدار ولوم ذخیره شده رو از PlayerPrefs می‌خونیم. اگه چیزی نبود، پیش‌فرض ۱ هست.
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // مقدار پیش‌فرض رو به نصف تغییر دادیم
        musicSource.volume = savedVolume; // ولوم AudioSource رو تنظیم می‌کنیم
        volumeSlider.value = savedVolume; // وضعیت ظاهری اسلایدر رو هم تنظیم می‌کنیم
        // اینجا وضعیت ذخیره شده رو می‌خونیم (توضیح در ادامه)
        // اگه برای اولین بار بازی اجرا می‌شه، مقدار پیش‌فرض ۱ (روشن) خواهد بود
        if (PlayerPrefs.GetInt("MusicState", 1) == 1)
        {
            isMusicOn = true;
            musicSource.Play();
            musicButtonImage.sprite = musicOnIcon;
        }
        else
        {
            isMusicOn = false;
            musicSource.Stop();
            musicButtonImage.sprite = musicOffIcon;
        }
    }

    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }

        // ذخیره کردن مقدار ولوم برای دفعه بعد
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    // این تابع قراره به دکمه ما وصل بشه
    public void ToggleMusic()
    {
        // وضعیت رو برعکس می‌کنیم
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            // اگه قراره روشن بشه، پخشش کن و آیکون رو عوض کن
            musicSource.Play();
            musicButtonImage.sprite = musicOnIcon;
            PlayerPrefs.SetInt("MusicState", 1); // وضعیت رو ذخیره کن (۱ یعنی روشن)
        }
        else
        {
            // اگه قراره خاموش بشه، متوقفش کن و آیکون رو عوض کن
            musicSource.Stop();
            musicButtonImage.sprite = musicOffIcon;
            PlayerPrefs.SetInt("MusicState", 0); // وضعیت رو ذخیره کن (۰ یعنی خاموش)
        }

        // این دستور تغییرات رو روی حافظه دستگاه ذخیره می‌کنه
        PlayerPrefs.Save();
    }
}