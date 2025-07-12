using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class crystalCollect : MonoBehaviour
{
    public int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // اگر آبجکتی که بهش برخورد کردیم تگ "Crystal" رو داشت
        if (other.CompareTag("crystal"))
        {
            // فراخوانی متد AddCrystal از اسکریپت CrystalManager
            // به خاطر الگوی Singleton، به راحتی به instance دسترسی داریم
            GameManager.instance.AddCrystal(1);
            // از بین بردن آبجکت کریستال بعد از برخورد
            Destroy(other.gameObject);
        }
    }
}
