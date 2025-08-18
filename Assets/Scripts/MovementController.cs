using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public GameManager uiManager;

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;

    private float horizontalValue;
    private float newPositionX;
    private bool isInEndZone = false;

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
        if (other.tag == "Obstacle")
        {
            uiManager.ShowFailMenu(); 
        }
        else if (other.CompareTag("EndZone"))
        {
            isInEndZone = true;
        }
    }
    void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  

}
