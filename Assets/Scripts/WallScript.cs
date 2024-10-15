using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour

{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public float leftBoundary =-9f;
    public float rightBoundary = 9f;

    private float direction = -1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
     
       if (transform.position.x >= rightBoundary && direction > 0)
       {
           direction = -1f;
       }
       else if (transform.position.x <= leftBoundary && direction < 0)
       {
           direction = 1f;
       }
    }
}

