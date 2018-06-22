using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap, Mesh };
    public DrawMode drawMode;

    public GameObject Building_Base;

    public Transform Buildings;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public float seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;


    Vector3 Building_Spawn;
    void Start()
    {
        GenerateSeed();
        GenerateMap();
    }

    void GenerateSeed()
    {
        seed = Random.Range(-10000, 10000);
    }

    public void GenerateMap()
    {


        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, (int)seed, noiseScale, octaves, persistance, lacunarity, offset);
        float GridSpace = mapHeight * mapWidth;

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        //if (PointInSphere(new Vector3(transform.position.x + x * GridSpace, transform.position.y, transform.position.z + y * GridSpace),
                        //    new Vector3(transform.position.x + GridSpace, transform.position.y, transform.position.z + GridSpace), GridSpace))
                        
                            colourMap[y * mapWidth + x] = regions[i].colour;


                            Building_Spawn.x = x;
                            Building_Spawn.z = y;

                            Instantiate(Building_Base, Building_Spawn, Quaternion.Euler(-90, 0, 0), Buildings);

                            break;
                        
                    }

                   
                }
            }

            MapDisplay display = FindObjectOfType<MapDisplay>();
            if (drawMode == DrawMode.NoiseMap)
            {
                display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
            }
            else if (drawMode == DrawMode.ColourMap)
            {
                display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
            }
            else if (drawMode == DrawMode.Mesh)
            {
                display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap), TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
                Debug.Log(display.name);
            }
        }

    }
    void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }

    bool PointInSphere(Vector3 point, Vector3 centre, float radius)
    {
        return Vector3.Distance(point, centre) < radius;
    }
  
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}