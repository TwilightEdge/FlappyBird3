using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class baziMenu : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public TextMeshProUGUI food;
    public TextMeshProUGUI cuteness;

    public GameObject restartMenu;

    
    
    public GameObject cat;
    
    public cat classcat;

    void Awake()
    {
        cat = GameObject.FindWithTag("Player");
        
        classcat = cat.GetComponent<cat>();
        
        //restartMenu= GameObject.FindWithTag("restartmenu");
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
    
    public void LoadGameScene()
    {
        //restartMenu.SetActive(false);
        SceneManager.LoadScene("background");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartMenu()
    {
        restartMenu.SetActive(true);
    }
    
    
}
