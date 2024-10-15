using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 velocity;

    public float leftBoundary = -8f;
    public float rightBoundary = 8f;

    public float topBoundary = 6f;
    public float bottomBoundary = -6f;
   
    void Start()
    {
        velocity = Random.insideUnitCircle.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        Vector3 coinPos = transform.position;
        if (coinPos.x > rightBoundary|| coinPos.x < leftBoundary)
        {
            velocity.x = -velocity.x;
        }

        if (coinPos.y > topBoundary || coinPos.y < bottomBoundary)
        {
            velocity.y = -velocity.y;
        }
    }
    public void GetBumped()
    {
        RespawnCoin();
    }

    void RespawnCoin()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(leftBoundary, rightBoundary),
            Random.Range(topBoundary, bottomBoundary),
            0);
        transform.position = randomPosition;
    }
}
