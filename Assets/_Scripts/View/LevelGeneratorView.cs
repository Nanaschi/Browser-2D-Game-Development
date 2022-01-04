using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace PlatformerMVC.View
{
public class LevelGeneratorView : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _tile;
    [SerializeField] private int _mapWidth;
    [SerializeField] private int _mapHeight;
    [SerializeField] private bool _borders;
    [SerializeField] [Range(0, 100)] private int _factorSmooth;
    [SerializeField] [Range(0, 100)] private int _fillPercentage;

    public Tilemap Tilemap
    {
        get => _tilemap;
        set => _tilemap = value;
    }
     
    public Tile Tile
    {
        get => _tile;
        set => _tile = value;
    }

    public int MapWidth
    {
        get => _mapWidth;
        set => _mapWidth = value;
    }

    public int MapHeight
    {
        get => _mapHeight;
        set => _mapHeight = value;
    }

    public bool Borders
    {
        get => _borders;
        set => _borders = value;
    }

    public int FactorSmooth
    {
        get => _factorSmooth;
        set => _factorSmooth = value;
    }

    public int FillPercentage
    {
        get => _fillPercentage;
        set => _fillPercentage = value;
    }
}
    
}

