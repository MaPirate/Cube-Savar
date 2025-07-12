using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // این خط برای تست اضافه شده
        Debug.Log("Trigger detected with object: " + other.name);

        // اگر بازیکنی که تگ "Player" دارد وارد محدوده شد
        if (other.CompareTag("cube"))
        {
            Debug.Log("Player reached the finish line!");
            // تابع برنده شدن را از GameManager فراخوانی کن
            GameManager.instance.PlayerWon();
        }
    }
}