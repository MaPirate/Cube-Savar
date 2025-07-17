using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // یک متغیر برای فعال یا غیرفعال کردن کنترل
    private bool canControl = true;

    void Update()
    {
        // فقط زمانی ورودی را پردازش کن که کنترل فعال باشد
        if (canControl)
        {
            // << کد کنترل بازیکن با کشیدن انگشت شما در اینجا قرار می‌گیرد >>
            // مثال:
            // if (Input.GetMouseButton(0))
            // {
            //     transform.position += ...
            // }
        }
    }

    // یک تابع عمومی برای غیرفعال کردن کنترل از اسکریپت‌های دیگر
    public void DisableMovement()
    {
        canControl = false;
    }
}