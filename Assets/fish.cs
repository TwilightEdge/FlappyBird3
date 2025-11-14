using UnityEngine;

public class fish : MonoBehaviour
{
    
    public GameObject cat;
    
    public cat classcat;
    
    private Rigidbody2D fishRigidbody;

    public int foodValue;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        classcat = cat.GetComponent<cat>();
        fishRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // enemy taking damage
    {   

        if (other.CompareTag("Player"))
        {
            
            classcat.food += foodValue;
            
            Destroy(gameObject);
            
        }
        
    }

}
