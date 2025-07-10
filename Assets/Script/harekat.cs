using UnityEngine;
using UnityEngine.InputSystem;

public class harekat : MonoBehaviour

{
    [SerializeField] private float forwardSpeed = 8f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float horizontalLimitValue = 5f; // محدوده تست را بیشتر می‌کنیم

    private Rigidbody rb;
    private float horizontalValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleHorizontalInput();
    }

    void FixedUpdate()
    {
        // سرعت افقی را بر اساس ورودی محاسبه می‌کنیم
        float xVelocity = horizontalValue * horizontalSpeed;

        // سرعت نهایی را تنظیم می‌کنیم: سرعت X را کنترل می‌کنیم، Y را به جاذبه می‌سپاریم، Z را ثابت نگه می‌داریم
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, forwardSpeed);

        // موقعیت افقی را محدود می‌کنیم
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -horizontalLimitValue, horizontalLimitValue);
        transform.position = clampedPosition;
    }

    private void HandleHorizontalInput()
    {
        // این کد فقط برای تست در کامپیوتر است
        if (Mouse.current.leftButton.isPressed)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                horizontalValue = -1; // برو به چپ
            }
            else
            {
                horizontalValue = 1; // برو به راست
            }
        }
        else
        {
            horizontalValue = 0;
        }
    }
}

