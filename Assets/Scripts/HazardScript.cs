using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 velocity;
    public float leftBoundary = -8f;
    public float rightBoundary = 8f;
    public float topBoundary = 6f;
    public float bottomBoundary = -6f;
    
    public GameObject Hazard;
    
    public Vector2 Range;
    
    public int scoreThreshold = 10;
    public float spawnDelay = 1f;
    private float timeSinceLastSpawn = 0f;
    private bool thresholdReached = false;
    

    public int maxHazards = 5;
    private int currentHazardCount = 0;
    public PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.insideUnitCircle.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        Vector3 hazardPos = transform.position;
        if (hazardPos.x > rightBoundary|| hazardPos.x < leftBoundary)
        {
            velocity.x = -velocity.x;
        }

        if (hazardPos.y > topBoundary || hazardPos.y < bottomBoundary)
        {
            velocity.y = -velocity.y;
        }

        checkScore();
    }
    void checkScore()
    {
            if (playerScript.GetScore() >= scoreThreshold)
            {
                thresholdReached = true;
            }

            if (thresholdReached && currentHazardCount < maxHazards)
            {
                timeSinceLastSpawn += Time.deltaTime;
                if (timeSinceLastSpawn >= spawnDelay)
                {
                    Vector3 where = transform.position + new Vector3(Random.Range(-Range.x, Range.x), 
                        Random.Range(-Range.y, Range.y), 0);
                    Instantiate(Hazard, where, Quaternion.identity);

                    currentHazardCount++;
                    timeSinceLastSpawn = 0f;

                }
            }
        
    }
}
