using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class crystalCollect : MonoBehaviour
{
    public int score = 0;
    public int factor;
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "1x")
        {
            factor = 1;
        }
        if (other.gameObject.tag == "2x")
        {
            factor = 2;
        }
        if (other.gameObject.tag == "3x")
        {
            factor = 3;
        }
        if (other.gameObject.tag == "4x")
        {
            factor = 4;
        }
        if (other.gameObject.tag == "5x")
        {
            factor = 5;
        }
        if (other.gameObject.tag == "6x")
        {
            factor = 6;
        }
        if (other.gameObject.tag == "7x")
        {
            factor = 7;
        }
        if (other.gameObject.tag == "8x")
        {
            factor = 8;
        }
        if (other.gameObject.tag == "9x")
        {
            factor = 9;
        }
        if (other.gameObject.tag == "10x")
        {
            factor = 10;
        }
        if (other.gameObject.tag == "11x")
        {
            factor = 11;
        }
        if (other.gameObject.tag == "12x")
        {
            factor = 12;
        }
        if (other.gameObject.tag == "20x")
        {
            factor = 20;
        }
        
        
        

  }
  
}
