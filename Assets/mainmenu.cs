using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenu : MonoBehaviour
{
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
        SceneManager.LoadScene("background");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
