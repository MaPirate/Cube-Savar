using System;
using System.Drawing;
using System.Xml.Serialization;
using JetBrains.Annotations;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class scorefmanager : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public int gainedcrystal = 0;
  public TextMeshProUGUI ingamefscore;

    void Start()
    {
        gainedcrystal = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void addone()
    {
    gainedcrystal += 1;
    Debug.Log(gainedcrystal);
    //ingamefscore.GetComponent<RTLTextMeshPro>().text = gainedcrystal.ToString();
    // livescore.GetComponent<RTLTMPro.RTLTextMeshPro>().text = inlevelscore.ToString();
  }
}
