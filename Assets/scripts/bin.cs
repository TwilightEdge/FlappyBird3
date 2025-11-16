using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class bin : MonoBehaviour
{

    public bool isFallen;

    public int countDown;
    
    public GameObject fish;
    private GameObject fishSpawn;
    
    private SpriteRenderer spriteRenderer;
    
    public Sprite fallen;

    private int numberOfFish;
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
            
            spriteRenderer.sprite = fallen;
            
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            
            GetComponent<Collider2D>().isTrigger = true;

            numberOfFish = Random.Range(1, 3);

            for (int i = 0; i < numberOfFish; i++)
            {
                fishSpawn = Instantiate(fish);
                fishSpawn.transform.position = new Vector2(transform.position.x + Random.Range(2f, 3.5f), transform.position.y + Random.Range(-1.5f, 1f));
            }

        }
        
        
    }
    
}
