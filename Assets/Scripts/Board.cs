using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENameLayer
{
    Asia,
    Europe,
    America
}

public class Board : MonoBehaviour
{
    static public Board S;

    [Header("Set in Inspector")]
    public float xTile = 1;
    public float zTile = 1;
    public Tile[] asiaTiles;
    public Tile[] europeTiles;
    public Tile[] americaTiles;

    [Header("Set Dynamically")]
    public Dictionary<(ENameLayer, int), (Tile, Vector3 )> tilePos = new Dictionary<(ENameLayer, int), (Tile, Vector3)>();

    private void Awake()
    {
        S = this;
    }

    public void CreateBoard()
    {
        int mx = Mathf.Max(asiaTiles.Length, europeTiles.Length, americaTiles.Length)/4;
        GameObject go = new GameObject("CameraAnchor");
        go.transform.position = new Vector3(mx * xTile / 2, 0, mx * zTile / 2);
        MainCamera.target = go;


        CreateLayer(ENameLayer.America, americaTiles, 0f,0f,0f);
        CreateLayer(ENameLayer.Europe, europeTiles, 1f,0.25f,1f);
        CreateLayer(ENameLayer.Asia, asiaTiles, 2f,0.5f,2f);

        Logs.PrintToLogs("Board created");
    }

    private void CreateLayer(ENameLayer nameLayer, Tile[] layerTiles, float startX, float height, float startZ)
    {
        int n = layerTiles.Length, side = n/4;
        float nxtX = startX, nxtZ = startZ;
        for (int i=0; i<side; i++)
        {
            Tile go = Instantiate<Tile>(layerTiles[i]);
            go.transform.SetParent(this.gameObject.transform);
            Vector3 pos = new Vector3(nxtX, height, nxtZ);
            go.transform.position = pos;
            tilePos.Add((nameLayer, i), (layerTiles[i],pos));
            nxtZ += zTile;
        }
        for (int i=side; i<side*2; i++)
        {
            Tile go = Instantiate<Tile>(layerTiles[i]);
            go.transform.SetParent(this.gameObject.transform);
            Vector3 pos = new Vector3(nxtX, height, nxtZ);
            go.transform.position = pos;
            tilePos.Add((nameLayer, i), (layerTiles[i], pos));
            nxtX += xTile;
        }
        for (int i = side * 2; i < side * 3; i++)
        {
            Tile go = Instantiate<Tile>(layerTiles[i]);
            go.transform.SetParent(this.gameObject.transform);
            Vector3 pos = new Vector3(nxtX, height, nxtZ);
            go.transform.position = pos;
            tilePos.Add((nameLayer, i), (layerTiles[i], pos));
            nxtZ -= zTile;
        }
        for (int i = side*3; i < side * 4; i++)
        {
            Tile go = Instantiate<Tile>(layerTiles[i]);
            go.transform.SetParent(this.gameObject.transform);
            Vector3 pos = new Vector3(nxtX, height, nxtZ);
            go.transform.position = pos;
            tilePos.Add((nameLayer, i), (layerTiles[i], pos));
            nxtX -= xTile;
        }
    }
}
