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
        public bool bossRoom;
    }

    public Vector2 roomDimensions;
    public Vector2Int gridDimensions;
    public List<Room> roomTypes;
    public Room bossRoom;

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
        for (int i = 0; i < gridDimensions.x; i++)
        {
            for (int j = 0; j < gridDimensions.y; j++)
            {
                rooms[i, j].top = false;
                rooms[i, j].right = false;
                rooms[i, j].bottom = false;
                rooms[i, j].left = false;
                rooms[i, j].numEntrances = 0;
                rooms[i, j].visited = false;
                rooms[i, j].bossRoom = false;
            }
        }

        clearPath(0, 0);

        for (int i = 0; i < gridDimensions.x; i++)
        {
            for (int j = 0; j < gridDimensions.y; j++)
            {
                GenRoomInMaze(i, j);
            }
        }
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

        if (column < 0 || column >= gridDimensions.x || row < 0 || row >= gridDimensions.y ||
                rooms[column, row].numEntrances > 1 || rooms[column, row].visited)
            return;

        rooms[column, row].visited = true;

        if (column > 0)
        {
            rooms[column - 1, row].numEntrances++;
            rooms[column - 1, row].right = true;
        }
        if (row > 0)
        {
            rooms[column, row - 1].numEntrances++;
            rooms[column, row - 1].bottom = true;
        }
        if (column < gridDimensions.x - 1)
        {
            rooms[column + 1, row].numEntrances++;
            rooms[column + 1, row].left = true;
        }
        if (row < gridDimensions.y - 1)
        {
            rooms[column, row + 1].numEntrances++;
            rooms[column, row + 1].top = true;
        }

        //BOSS ROOM GO BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        if (column == gridDimensions.x - 1)
        {
            //Debug.Log("Making boss room");
            rooms[column, row].bossRoom = true;
            return;
        }

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
        //Could have a wall "room" here to fill it in
        if (!rooms[x, y].visited)
            return;

        //Debug.Log("x=" + x + " y=" + y);
        //if(rooms[x, y].top)
        //    Debug.Log("top");
        //if (rooms[x, y].right)
        //    Debug.Log("right");
        //if (rooms[x, y].bottom)
        //    Debug.Log("bottom");
        //if (rooms[x, y].left)
        //    Debug.Log("left");

        if (rooms[x, y].bossRoom)
        {
            Room boss = Instantiate(bossRoom);
            boss.transform.position = new Vector2(x * roomDimensions.x, y * -roomDimensions.y);
            return;
        }

        List<Room> possibleLayouts = new List<Room>();

        foreach (Room roomType in roomTypes)
        {
            //If the door layout is the same add it to matching layouts
            if (rooms[x, y].top == roomType.top && rooms[x, y].right == roomType.right
                && rooms[x, y].bottom == roomType.bottom && rooms[x, y].left == roomType.left)
                possibleLayouts.Add(roomType);
        }

        if (possibleLayouts.Count == 0)
        {
            Debug.Log("NO ROOM MATCHING ROOM LAYOUT WAS FOUND");
            return;
        }

        int rand = Random.Range(0, possibleLayouts.Count);

        Room spawnedRoom = Instantiate(possibleLayouts[rand]);
        spawnedRoom.transform.position = new Vector2(x * roomDimensions.x, y * -roomDimensions.y);
        //Debug.Log("pog made a room");
    }
}
