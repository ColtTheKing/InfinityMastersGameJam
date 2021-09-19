using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    struct MazeRoom
    {
        public Vector2 location;
        public bool top, right, bottom, left;
        public int numEntrances;
        public bool visited;
    }

    public Vector2 roomDimensions;
    public Vector2Int gridDimensions;
    public List<Room> roomTypes;

    private MazeRoom[,] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = new MazeRoom[gridDimensions.x, gridDimensions.y];
        generateRandomMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Generates a random maze by filling the entire grid with walls and then
     * calling clearPath from the entry point.
     */
    private void generateRandomMaze()
    {
        for (int i = 0; i < roomDimensions.x; i++)
        {
            for (int j = 0; j < roomDimensions.y; j++)
            {
                rooms[i, j].top = false;
                rooms[i, j].right = false;
                rooms[i, j].bottom = false;
                rooms[i, j].left = false;
                rooms[i, j].numEntrances = 0;
                rooms[i, j].visited = false;
            }
        }

        clearPath(0, 1);

        //I don't know why this was necessary
        //for (int i = 0; i < roomDimensions.x; i++)
        //{
        //    for (int j = 0; j < roomDimensions.y; j++)
        //    {
        //        rooms[i, j].numEntrances = 0;
        //    }
        //}
    }

    /**
     * Clears and visits a piece of path then picks a random adjacent section
     * and recursively calls the function on that section of path.
     * 
     * Yes I know rows and columns are mixed up but it's fine
     */
    private void clearPath(int column, int row)
    {
        int randDir, temp;
        int max = 5;

        if (column < 0 || column >= roomDimensions.x || row < 0 || row >= roomDimensions.y ||
                rooms[column, row].numEntrances > 1 || rooms[column, row].visited)
            return;

        rooms[column, row].visited = true;

        if (column > 1)
        {
            rooms[column - 1, row].numEntrances++;
            rooms[column - 1, row].left = true;
        }
        if (row > 1)
        {
            rooms[column, row - 1].numEntrances++;
            rooms[column, row - 1].top = true;
        }
        if (column < roomDimensions.x - 1)
        {
            rooms[column + 1, row].numEntrances++;
            rooms[column + 1, row].right = true;
        }
        if (row < roomDimensions.y - 1)
        {
            rooms[column, row + 1].numEntrances++;
            rooms[column, row + 1].bottom = true;
        }
        if (row == roomDimensions.y - 1)
            return; //BOSS ROOM GO BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR

        int[] choices = new int[4];
        for (int i = 0; i < 4; i++)
            choices[i] = i;

        for (int j = 0; j < 4; j++)
        {
            randDir = Random.Range(0, --max);
            switch (choices[randDir])
            {
                case 0:
                    clearPath(column - 1, row);
                    break;
                case 1:
                    clearPath(column, row - 1);
                    break;
                case 2:
                    clearPath(column + 1, row);
                    break;
                case 3:
                    clearPath(column, row + 1);
                    break;
            }
            temp = choices[randDir];
            choices[randDir] = choices[max - 1];
            choices[max - 1] = temp;
        }
    }

    //Generate room in maze with a layout that matches the struct
    private void GenRoomInMaze(int x, int y)
    {
        List<Room> possibleLayouts = new List<Room>();

        foreach (Room roomType in roomTypes)
        {
            //If the door layout is the same add it to matching layouts
            if (rooms[x, y].top == roomType.top && rooms[x, y].right == roomType.right
                && rooms[x, y].bottom == roomType.bottom && rooms[x, y].left == roomType.left)
                possibleLayouts.Add(roomType);
        }

        if (possibleLayouts.Count == 0)
            Debug.Log("NO ROOM MATCHING ROOM LAYOUT WAS FOUND");

        int rand = Random.Range(0, possibleLayouts.Count);
        rooms[x, y].top = possibleLayouts[rand].top;
        rooms[x, y].right = possibleLayouts[rand].right;
        rooms[x, y].bottom = possibleLayouts[rand].bottom;
        rooms[x, y].left = possibleLayouts[rand].left;
    }
}
