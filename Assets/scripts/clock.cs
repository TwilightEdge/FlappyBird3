using UnityEngine;

public class clock : MonoBehaviour
{
    public bool isDay;
    public bool isEve;
    public bool isNight;

    public float timepassed;
    
    public float dayDuration;
    
    public float nightDuration;
    
    private SpriteRenderer spriteRenderer;

    public Sprite day;
    public Sprite eve;
    public Sprite night;
    
    public GameObject spawner;
    
    public spawner classspawner;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        StartDay();
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.FindWithTag("spawner");
        
        classspawner = spawner.GetComponent<spawner>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        checkForChangeTime();
        
    }

    void FixedUpdate()
    {
        timePass();
        
        
    }

    public void StartDay()
    {
        timepassed = 0;
        isNight = false;
        isDay = true;
        
        spriteRenderer.sprite = day;
        
        // all remaining enemies sleep
        
        // humans spawn
        
    }
    
    public void StartEve()
    {
        timepassed = 0;
        isDay = false;
        isEve = true;
        
        spriteRenderer.sprite = eve;
        
        // humans disapear
        
    }
    
    public void StartNight()
    {
        timepassed = 0;
        isEve = false;
        isNight = true;
        
        spriteRenderer.sprite = night;

        classspawner.ResetTimer();

        // we dont need to spawn new enemies when night begins but we can:

        //classspawner.spawn();

        //classspawner.Invoke("spawn", 5f);


    }


    void timePass()
    {
        timepassed += Time.deltaTime;
    }

    void checkForChangeTime()
    {
        if (isEve)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartNight();
            }
            
            
        }
        else
        if(isDay)
        {
            if (timepassed >= dayDuration)
            {
                StartEve();
            }
            
            
        }
        else
        if(isNight)
        {
            if (timepassed >= nightDuration)
            {
                StartDay();
            }
            
            
        }
        
    }

}
