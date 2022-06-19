using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private Vector2[] postions;
    int numberOfPositions;
    int startPostion = 0;
    [SerializeField] private int speed = 1;
    void Start()
    {
        numberOfPositions = postions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y) == postions[startPostion])
        {
            if (startPostion == numberOfPositions - 1)
                startPostion = 0;
            else
                startPostion++;
        }

        transform.position = Vector2.MoveTowards(transform.position, postions[startPostion],speed*Time.deltaTime);
    }

    
}
