using UnityEngine;



public class spawner : MonoBehaviour
{
    
    public GameObject enemy1;

    private GameObject enemySpawn1;

    public float area1MinX;
    public float area1MaxX;
    public float area1MinY;
    public float area1MaxY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        
        enemySpawn1 = Instantiate(enemy1);

        enemySpawn1.transform.position = new Vector2(Random.Range(area1MinX, area1MaxX), Random.Range(area1MinY, area1MaxY));

    }
    
    
}
