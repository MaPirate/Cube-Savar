using UnityEngine;

public class em : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
  void OnTriggerEnter(Collider other)
  {
        if (other.gameObject.tag =="endsag")
        {

            gameManager.PlayerWon();
      

    }
  }
}
