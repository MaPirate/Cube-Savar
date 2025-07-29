using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class crystalCollect : MonoBehaviour
{
    public int score = 0;
    public GameObject scoredcrystal;
    
    
    public int mremtiaz = 0;
    public TextMeshProUGUI scoreText;
    public int factor;
    public MultiplierPlatform tempp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("crystal"))
        {
            Destroy(other.gameObject);

            mremtiaz += 1;



            Debug.Log(mremtiaz);


            GameManager.instance.AddCrystal(1);
            scoreText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = mremtiaz.ToString();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "plat")
        {
            Debug.Log("hi2");
            factor = 1;

        }
        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 2)
        // {
        //     factor = 2;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 3)
        // {
        //     factor = 3;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 4)
        // {
        //     factor = 4;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 5)
        // {
        //     factor = 5;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 6)
        // {
        //     factor = 6;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 7)
        // {
        //     factor = 7;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 8)
        // {
        //     factor = 8;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 9)
        // {
        //     factor = 9;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 10)
        // {
        //     factor = 10;

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 11)
        // {
        //     factor = 11;
        //     Debug.Log("11");

        // }

        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 12)
        // {
        //     factor = 12;
        //     Debug.Log("12");

        // }
        
        // if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 20)
        // {
        //     factor = 20;    

        // }
  }
    
    
    
    void Setscore()
    {
        scoredcrystal.GetComponent<ScoreManager>().totalscore = mremtiaz*factor;


     }
    
  
}
