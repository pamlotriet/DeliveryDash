using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    float destroyDelay = 0.5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Debug.Log("Picked up package");
            Debug.Log("Has package: " + hasPackage);
            Destroy(collision.gameObject, destroyDelay);
        }
        
        if(collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, destroyDelay);
            Debug.Log("Delivered package");
            Debug.Log("Has package: " + hasPackage);
        }

  
    }
}
