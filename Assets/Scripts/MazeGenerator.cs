using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public Vector2 roomDimensions;
    public Vector2Int gridDimensions;
    private GameObject[,] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = new GameObject[gridDimensions.x, gridDimensions.y];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
