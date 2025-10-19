using System;
using System.Drawing;
using System.Xml.Serialization;
using JetBrains.Annotations;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class scorefmanager : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public int gainedcrystal = 0;
  public TextMeshProUGUI ingamefscore;
    void Start()
    {
        gainedcrystal = 0;
        UpdateCrystalText();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void addone()
    {
    gainedcrystal += 1;
    Debug.Log(gainedcrystal);
    UpdateCrystalText();


        //ingamefscore.GetComponent<TextMeshPro>().text = gainedcrystal.ToString();
        //ingamefscore.GetComponent<Text>().text = gainedcrystal.ToString();
        // livescore.GetComponent<RTLTMPro.RTLTextMeshPro>().text = inlevelscore.ToString();
    }
    void UpdateCrystalText()
    {
        // مقدار عددی کریستال را به رشته (string) تبدیل کرده و در متن نمایش می‌دهیم
        if (ingamefscore != null)
        {
            ingamefscore.text = gainedcrystal.ToString();
        }
    }
}
