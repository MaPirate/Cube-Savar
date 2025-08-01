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
    private int score = 0;
    private GameObject scoredcrystal;
    
    
    private int mremtiaz = 0;
    public TextMeshProUGUI scoreText;
    private int factor;
    private MultiplierPlatform tempp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Setscore();
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("crystal"))
        {
            Destroy(other.gameObject);

            mremtiaz += 1;



            


            GameManager.instance.AddCrystal(1);
            scoreText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = mremtiaz.ToString();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 1)
        {
            factor = 1;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 2)
        {
            factor = 2;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 3)
        {
            factor = 3;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 4)
        {
            factor = 4;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 5)
        {
            factor = 5;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 6)
        {
            factor = 6;
            


        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 7)
        {
            factor = 7;
            
        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 8)
        {
            factor = 8;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 9)
        {
            factor = 9;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 10)
        {
            factor = 10;
            

        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 11)
        {
            factor = 11;
            


        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 12)
        {
            factor = 12;
            


        }

        if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 20)
        {
            factor = 20;
            
            


        }
        
  }
    
    
    
    void Setscore()
    {
        scoredcrystal.GetComponent<ScoreManager>().totalscore = mremtiaz*factor;


     }
    
  
}
