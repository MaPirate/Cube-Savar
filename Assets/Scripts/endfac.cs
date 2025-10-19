using UnityEngine;

public class endfac : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int factoriel;
    public int sag;
    public scorefmanager scorefmanager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sag = factoriel;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("khaaaaaaaaaaaaaaaaaaaaaaaarrrrr");
        if (collision.gameObject.tag == "endsag")
        {
            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 1)
            {
                factoriel = 1;



            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 2)
            {
                factoriel = 2;

            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 3)
            {
                factoriel = 3;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 4)
            {
                factoriel = 4;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 5)
            {
                factoriel = 5;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 6)
            {
                factoriel = 6;



            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 7)
            {
                factoriel = 7;

            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 8)
            {
                factoriel = 8;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 9)
            {
                factoriel = 9;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 10)
            {
                factoriel = 10;


            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 11)
            {
                factoriel = 11;



            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 12)
            {
                factoriel = 12;



            }

            if (collision.gameObject.GetComponent<MultiplierPlatform>().multiplierValue == 20)
            {
                factoriel = 20;
                
                

            }
        }
    }
}