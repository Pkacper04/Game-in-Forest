using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField,ReorderableList] private List<Vector2> postions;
    [SerializeField] private int speed = 1;



    int numberOfPositions;
    int startPostion = 0;
    void Start()
    {
        numberOfPositions = postions.Count;
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
