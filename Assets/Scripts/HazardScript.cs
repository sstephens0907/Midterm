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
    }
}
