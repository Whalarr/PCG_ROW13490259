using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {


    public Transform hexPrefab;

    public int gridWidth;
    public int gridHeight;

    //float hexWidth = 1.732f;
    //float hexHeight = 2.0f;
    float hexWidth = 17.320f;
    float hexHeight = 20.0f;
    public float gap = 0.0f;

    public static GameObject[] Hex_Array;
    public bool is_occupied = false;

    int region_Width;
    int region_Height;

    Vector3 startPos;
    void Awake()
    {
        AddGap();
        CalcStartPos();
        CreateGrid();

    }


    void Start()
    {
       
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 30, z);
    }

    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);

                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;

                if(hex.name.Contains(x.ToString() + "|"))
                {
                    for (int i=0;i < x; i++)
                    {

                    }
                }
            }
        }
        Hex_Array = GameObject.FindGameObjectsWithTag("Hex");
        //  Debug.Log(Hex_Array.Length);
        region_Height = gridHeight / 5;
        region_Width = gridWidth / 5;

    }

}