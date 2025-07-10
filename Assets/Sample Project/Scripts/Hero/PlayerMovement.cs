using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 8f;
    [SerializeField] private float horizontalSpeed = 500f;
    [SerializeField] private float horizontalLimitValue = 2.5f;

    private Rigidbody rb;
    private float horizontalValue;
    private bool isMovementActive = false;

    // در Awake، کامپوننت ریجیدبادی را پیدا می‌کنیم
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on Player!", this.gameObject);
        }
    }

    // این تابع توسط GameManager صدا زده می‌شود تا حرکت را فعال کند
    // این تابع توسط UIManager فراخوانی می‌شود
    public void StartMoving()
    {
        isMovementActive = true;
    }

    // ورودی کاربر را در Update می‌خوانیم تا پاسخگویی سریع باشد
    void Update()
    {
        if (!isMovementActive) return;

        HandleHorizontalInput();
    }

    // تمام محاسبات و اعمال فیزیک در FixedUpdate انجام می‌شود
    void FixedUpdate()
    {
        if (!isMovementActive)
        {
            // اگر حرکت فعال نیست، سرعت را صفر می‌کنیم تا بایستد
            rb.linearVelocity = Vector3.zero;
            return;
        }

        // --- منطق نهایی حرکت مبتنی بر سرعت ---
        // ۱. سرعت افقی را بر اساس ورودی ماوس محاسبه می‌کنیم
        float xVelocity = horizontalValue * horizontalSpeed * Time.fixedDeltaTime;

        // ۲. سرعت نهایی را تنظیم می‌کنیم
        // سرعت افقی (X) و رو به جلو (Z) را خودمان کنترل می‌کنیم،
        // اما سرعت عمودی (Y) را به موتور فیزیک می‌سپاریم تا جاذبه کار کند.
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, forwardSpeed);

        // ۳. موقعیت بازیکن را در محدوده افقی نگه می‌داریم
        ClampPosition();
    }

    private void HandleHorizontalInput()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            horizontalValue = Mouse.current.delta.x.ReadValue();
        }
        else
        {
            horizontalValue = 0;
        }
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -horizontalLimitValue, horizontalLimitValue);
        transform.position = clampedPosition;
    }
}