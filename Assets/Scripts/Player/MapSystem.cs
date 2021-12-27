using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    [SerializeField] private int rowsLength;
    [SerializeField] private int colsLength;
    [SerializeField] private int[] playerStartPoint = new int[2];
    
    private int[,] gridArray;
    
    // Start is called before the first frame update
    void Start()
    {
        gridArray = new int[rowsLength, colsLength];
        InitializeGridArray();
    }

    void InitializeGridArray()
    {
        for (int i = 0; i < rowsLength; i++)
        {
            for (int j = 0; j < colsLength; j++)
            {
                if (i == playerStartPoint[0] && j == playerStartPoint[1])
                    gridArray[i, j] = 1;
                else
                    gridArray[i, j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
