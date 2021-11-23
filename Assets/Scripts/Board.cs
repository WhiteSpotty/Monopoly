using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENameLayer
{
    America,
    Europe,
    Asia
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
    public Dictionary<EFirmType, List<Tile>> tileByFirmType = new Dictionary<EFirmType, List<Tile>>();
    public Dictionary<ECardType, Deck> deckByCardType = new Dictionary<ECardType, Deck>();

    public List<(TransitionTile, (ENameLayer, int))> southTransitions = new List<(TransitionTile, (ENameLayer, int))>();
    public List<(TransitionTile, (ENameLayer, int))> eastTransitions = new List<(TransitionTile, (ENameLayer, int))>();
    public List<(TransitionTile, (ENameLayer, int))> westTransitions = new List<(TransitionTile, (ENameLayer, int))>();
    public List<(TransitionTile, (ENameLayer, int))> northTransitions = new List<(TransitionTile, (ENameLayer, int))>();

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


        //Creating Decks
        deckByCardType.Add(ECardType.chanceCard, new ChanceDeck());
        deckByCardType.Add(ECardType.millionariesLifeCard, new MillionariesLifeDeck());


        //Creating Tiles
        CreateLayer(ENameLayer.America, americaTiles, 0f,0f,0f);
        CreateLayer(ENameLayer.Europe, europeTiles, 1f,0.25f,1f);
        CreateLayer(ENameLayer.Asia, asiaTiles, 2f,0.5f,2f);

        Logs.PrintToLogs("Board created");
    }

    private void CreateLayer(ENameLayer nameLayer, Tile[] layerTiles, float startX, float height, float startZ)
    {
        int n = layerTiles.Length, side = n/4;
        float nxtX = startX, nxtZ = startZ;
        for (int i=0; i<n; i++)
        {
            Tile go = Instantiate<Tile>(layerTiles[i]);
            go.transform.SetParent(this.gameObject.transform);
            Vector3 pos = new Vector3(nxtX, height, nxtZ);
            go.transform.position = pos;
            go.transform.rotation = Quaternion.Euler(0, i/side*90-90, 0);
            tilePos.Add((nameLayer, i), (go,pos));

            if (go is TransitionTile)
            {
                if (go is SouthTransitionTile)
                {
                    southTransitions.Add(((SouthTransitionTile)go, (nameLayer, i)));
                }
                else if (go is EastTransitionTile)
                {
                    eastTransitions.Add(((EastTransitionTile)go, (nameLayer, i)));
                }
                else if (go is NorthTransitionTile)
                {
                    northTransitions.Add(((NorthTransitionTile)go, (nameLayer, i)));
                }
                else if (go is WestTransitionTile)
                {
                    westTransitions.Add(((WestTransitionTile)go, (nameLayer, i)));
                }
            }
            if (go is CommonTile)
            {
                EFirmType type = ((CommonTile)go).firmInfo.Type;
                if (tileByFirmType.ContainsKey(type))
                {
                    List<Tile> curr = tileByFirmType[type];
                    curr.Add(go);
                    tileByFirmType[type] = curr;
                }
                else
                {
                    tileByFirmType.Add(type, new List<Tile>() { go });
                }
            }

            if (i<side)
            {
                nxtZ += zTile;
            }
            else if (i<2*side)
            {
                nxtX += xTile;
            }
            else if (i<3*side)
            {
                nxtZ -= zTile;
            }
            else
            {
                nxtX -= xTile;
            }
        }
    }
}
