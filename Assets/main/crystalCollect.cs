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
  void OnCollisionEnter(Collision collision)
  {
        if (collision.gameObject.tag == "crystal")
        {
            Destroy(collision.gameObject);
            score = score + 1;
            Debug.Log(score);
        }
  }
}
