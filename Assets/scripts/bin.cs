using UnityEngine;

public class bin : MonoBehaviour
{

    public bool isFallen;

    public int countDown;
    
    public GameObject fish;
    private GameObject fishSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //fish = GameObject.FindWithTag("fish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) // enemy taking damage
    {
        
        if (other.CompareTag("playerAttack"))
        {
            if (!isFallen)
            {
                CountDown();
            }
            
        }
        
    }

    void CountDown()
    {
        countDown--;
        if (countDown == 0)
        {
            isFallen = true;
            
            transform.rotation = Quaternion.Euler(0, 0, -90);
            
            GetComponent<Collider2D>().isTrigger = true;
            
            fishSpawn = Instantiate(fish);
            
            fishSpawn.transform.position = new Vector2(transform.position.x+Random.Range(-1,1), transform.position.y+Random.Range(-1,1));
        }
        
        
    }
    
}
