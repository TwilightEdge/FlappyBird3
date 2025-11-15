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

    public GameObject[] allHumans;
    
    public GameObject[] allbg;
    
    Color nightColor;
    
    Color dayColor;
    
    Color eveColor;
    
    public GameObject shop;
    

    void Awake()
    {
        shop = GameObject.FindWithTag("shop");
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        allHumans = GameObject.FindGameObjectsWithTag("human");
        
        allbg = GameObject.FindGameObjectsWithTag("bg");
        
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
        MakeBGDay();
        
        timepassed = 0;
        isNight = false;
        isDay = true;
        
        MakeHumansActive();
        
        spriteRenderer.sprite = day;
        
        // all remaining enemies sleep
        
        // humans spawn
        
    }
    
    public void StartEve()
    {
        MakeBGEve();

        MakeShopActive();
        
        timepassed = 0;
        isDay = false;
        isEve = true;
        
        MakeHumansDeActive();
        
        spriteRenderer.sprite = eve;
        
        // humans disapear
        
    }
    
    public void StartNight()
    {
        MakeBGNight();

        MakeShopDeActive();
        
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
    
    
    public void MakeHumansActive()
    {
        
        foreach (GameObject target in allHumans)
        {
            // The single line of code to set the active/inactive state of the object:
            target.SetActive(true); // Or target.SetActive(false);
        }
        
    }
    
    public void MakeHumansDeActive()
    {
        
        foreach (GameObject target in allHumans)
        {
            // The single line of code to set the active/inactive state of the object:
            target.SetActive(false); // Or target.SetActive(false);
        }
        
    }
    
    public void MakeShopActive()
    {
        shop.SetActive(true);
    }
    public void MakeShopDeActive()
    {
        shop.SetActive(false);
    }
    
    
    
    
    public void MakeBGNight()
    {
        
        ColorUtility.TryParseHtmlString("#7674BF", out nightColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = nightColor;
            
        }
        
    }
    
    
    public void MakeBGDay()
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out dayColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = dayColor;
            
        }
        
    }
    
        
    public void MakeBGEve()
    {
        
        ColorUtility.TryParseHtmlString("#D28D66", out eveColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = eveColor;
            
        }
        
    }
    

}
