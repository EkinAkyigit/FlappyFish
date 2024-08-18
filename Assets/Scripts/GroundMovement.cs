using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]  public float speed;
    BoxCollider2D box;

    float groundWidth;
    float obstacleWidth;

    private void Start()
    {
        if (gameObject.CompareTag("ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("obstacle"))
            obstacleWidth = GameObject.FindGameObjectWithTag("column").GetComponent<BoxCollider2D>().size.x;
    }

    private void Update()
    {
        if(GameManager.gameOver == false)
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (gameObject.CompareTag("ground"))
        {
            if(transform.position.x <= -groundWidth)
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
        }
        else if (gameObject.CompareTag("obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - obstacleWidth)
                Destroy(gameObject);
        }
    }
}
