using PlatformerMVC.View;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC.Controllers
{
    public class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;
        private int _mapHeight;
        private bool _borders;
        [Range(0, 100)] private int _factorSmooth;
        [Range(0, 100)] private int _fillPercentage;

        private MarchingSquaresController _marchingSquaresController; // Lesson 7



        private int[,] _map;
        private const int _countWall = 4;

        public GeneratorController(LevelGeneratorView levelGeneratorView)
        {
            _tilemap = levelGeneratorView.Tilemap;
            _groundTile = levelGeneratorView.Tile;
            _mapWidth = levelGeneratorView.MapWidth;
            _mapHeight = levelGeneratorView.MapHeight;
            _borders = levelGeneratorView.Borders;
            _factorSmooth = levelGeneratorView.FactorSmooth;
            _fillPercentage = levelGeneratorView.FillPercentage;

            _map = new int[_mapWidth, _mapHeight];

            _marchingSquaresController = new MarchingSquaresController(); // Lesson 7
        }

        public void Initialize()
        {
            //Filling the map with random numbers (zeroes and ones) 
            RandomFillMap();
            // Smoothing the map making it more suitable
            for (int i = 0; i < _factorSmooth; i++)
            {
                    SmoothMap();
            }
            
            _marchingSquaresController.GeneratingGrid(_map, 1); // Lesson 7 Marching squares method
            _marchingSquaresController.DrawTilesOnMap(_tilemap,_groundTile); // Lesson 7
            //Draw tiles
            // DrawTiles();  // Lesson 7
        }

        private void RandomFillMap()
        {
            System.Random rand = new System.Random(Time.deltaTime.ToString().GetHashCode());

            for (int x = 0; x < _mapWidth; x++)
            {

                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || _mapWidth - 1 == 0 || y == 0 || _mapHeight - 1 == 0)
                    {
                        if (_borders) _map[x, y] = 1;
                    }
                    else
                    {
                        _map[x, y] = (rand.Next(0, 100) < _fillPercentage) ? 1 : 0;
                    }
                }
            }
Debug.Log(nameof(RandomFillMap));

        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {

                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbourWall = GetAdjacentTiles(x, y);
                    if (neighbourWall > _countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbourWall <_countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
            Debug.Log(nameof(SmoothMap));
            
        }


        private int GetAdjacentTiles(int x, int y)
        {
            int wallCount = 0;
            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {

                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY <_mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            wallCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }


        private void DrawTiles()
        {
            if (_map == null) return;
            

            for (int x = 0; x < _mapWidth; x++)
            {

                for (int y = 0; y < _mapHeight; y++)
                {

                    Vector3Int positionTile = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);
                    if (_map[x,y] == 1)
                    {
                        _tilemap.SetTile(positionTile, _groundTile);
                    }
                }
            }

        }
    }
}