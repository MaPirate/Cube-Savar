using UnityEngine;

public class rotating : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Quaternion targetRotation;
    void Start()
    {
        targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
   private void OnTriggerStay(Collider other)
    {
    
    if (other.gameObject.tag == "rotate")
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 0.3f );
        }
  }
  
}
