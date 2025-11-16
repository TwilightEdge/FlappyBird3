using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public TextMeshProUGUI food;
    public TextMeshProUGUI cuteness;

    
    
    public GameObject cat;
    
    public cat classcat;

    void Awake()
    {
        cat = GameObject.FindWithTag("Player");
        
        classcat = cat.GetComponent<cat>();
        
    }

    void FixedUpdate()
    {
        HP.text = classcat.HP.ToString();
        
        food.text = classcat.food.ToString();
        
        cuteness.text = classcat.cuteness.ToString();
        
        


    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
