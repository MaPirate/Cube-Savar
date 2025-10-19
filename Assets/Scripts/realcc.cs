using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class realcc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public scorefmanager scorefmanager;
    
       void Start()
    {
        // totalScoref = PlayerPrefs.GetInt("TotalScoref", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // scoreupdate();
    }



    void Crystaltrigger()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        // اینجا چک می‌کنیم که آیا آبجکتی که با ما برخورد کرده، تگ "cube" را دارد یا نه
        // نکته: معمولاً برای بازیکن از تگ "Player" استفاده می‌شود، اما اگر برای شما "cube" کار می‌کند، همان را بگذارید.
        if (other.CompareTag("cube"))
        {
            // ۱. به جای ارجاع مستقیم، از طریق Singleton به گیم منیجر دسترسی پیدا می‌کنیم
            // این خط به صورت خودکار GameManager فعال در صحنه را پیدا کرده و تابعش را صدا می‌زند
            GameManager.instance.AddOneCrystal();

            // ۲. بعد از اضافه شدن امتیاز، این آبجکت (کریستال) از بین می‌رود
            Destroy(gameObject);
        }
    }
}
    // void scoreupdate()
    // { 
    //    livescore.GetComponent<RTLTMPro.RTLTextMeshPro>().text = inlevelscore.ToString(); 
    // }
    
//         private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.tag == "obstacle")
//         {
//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 1)
//             {
//                 factor = 1;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 2)
//             {
//                 factor = 2;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 3)
//             {
//                 factor = 3;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 4)
//             {
//                 factor = 4;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 5)
//             {
//                 factor = 5;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 6)
//             {
//                 factor = 6;



//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 7)
//             {
//                 factor = 7;

//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 8)
//             {
//                 factor = 8;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 9)
//             {
//                 factor = 9;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 10)
//             {
//                 factor = 10;


//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 11)
//             {
//                 factor = 11;



//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 12)
//             {
//                 factor = 12;



//             }

//             if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 20)
//             {
//                 factor = 20;




//             }
//         }

//     }
//     public void AddLevelScore()
//     {
//         totalScoref += inlevelscore + factor;
//         PlayerPrefs.SetInt("TotalScore", totalScoref); 
//         PlayerPrefs.Save(); 
//         Debug.Log("Total Score: " + totalScoref);
//     }


