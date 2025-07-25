using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;

    private float horizontalValue;
    private float newPositionX;
    // این متغیر برای کنترل حالت پایانی است
    private bool isInEndZone = false;

    // سرعت حرکت ثابت در بخش پایانی
    public float endZoneSpeed = 5f;
    void FixedUpdate()
    {
            // فقط اگر بازی شروع شده باشد، کدهای حرکت اجرا شوند
        if (GameManager.isGameStarted)
        {
            HandleHeroHorizontalInput();
            SetHeroForwardMovement();
            SetHeroHorizontalMovement();
        }
    }

    private void HandleHeroHorizontalInput()
    {
        // با استفاده از سیستم ورودی جدید، چک می‌کنیم که آیا دکمه چپ ماوس فشرده شده است یا نه
        if (Mouse.current.leftButton.isPressed)
        {
            // میزان جابجایی ماوس در محور افقی از فریم قبل تا الان را می‌خوانیم
            horizontalValue = Mouse.current.delta.x.ReadValue();
        }
        else
        {
            horizontalValue = 0;
        }
    }


    private void SetHeroForwardMovement()//hero forward movement
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }


    private void SetHeroHorizontalMovement()//hero Horizontal Movement
    {
        newPositionX = transform.position.x + horizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" ||
        other.tag == "1x" ||
        other.tag == "2x" ||
        other.tag == "3x"||
        other.tag == "4x"||
        other.tag == "5x"||
        other.tag == "6x" ||
        other.tag == "7x" ||
        other.tag == "8x" ||
        other.tag == "9x" ||
        other.tag == "10x" ||
        other.tag == "11x" ||
        other.tag == "12x" ||
        other.tag == "20x" ){
        
            // اگر با مانع برخورد کرد، بازی را ریست کن
            Invoke("reset", 1f);
        }
        // ۲. بررسی ورود به محدوده پایانی
        else if (other.CompareTag("EndZone"))
        {
            isInEndZone = true; // فعال کردن حالت حرکت خودکار پایانی
        }
    }
    void reset()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
