using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    [SerializeField] float maxTime;
    float timer;

    public float maxY;
    public float minY;
    float randomY;

    private void Start()
    {
        //InstantiateObstacle();
    }

    private void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }

        
    }
    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);

        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
