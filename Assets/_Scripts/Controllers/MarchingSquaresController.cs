using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC.Controllers
{
    public class MarchingSquaresController
    {
        private Tile _groundTile;
        private Tilemap _groundTileMap;
        private SquareGrid _squareGrid;
        
        public class Node
        {
            public Vector3 _position;

            public Node(Vector3 position)
            {
                _position = position;
            }
        }
        
        
        
        public class ControllNode: Node
        {
            public bool _active;

            public ControllNode(Vector3 position, bool active) : base(position)
            {
                _active = active;
            }
        }
        
        public class Square
        {
            public ControllNode TopLeft, TopRight, BottomLeft, BottomRight;

            public Square(ControllNode topLeft,ControllNode topRight,ControllNode bottomLeft,ControllNode bottomRight)
            {
                TopLeft = topLeft;
                TopRight = topRight;
                BottomLeft = bottomLeft;
                BottomRight = bottomRight;
            }
            
        }
        
        public class SquareGrid
        {
            public Square[,] Squares;

            public SquareGrid(int[,] map, float squareSize)
            {
                int nodeCountX = map.GetLength(0);
                int nodeCountY = map.GetLength(1);
                float mapWidth = nodeCountX * squareSize;
                float mapHeight = nodeCountY * squareSize;

                ControllNode[,] controllNodes = new ControllNode[nodeCountX, nodeCountY];

                for (int x = 0; x < nodeCountX; x++)
                {
                    for (int y = 0; y < nodeCountY; y++)
                    {
                        Vector3 position = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2, 
                            -mapHeight/2 + y *squareSize + squareSize/2);
                        controllNodes[x, y] = new ControllNode(position, map[x, y] == 1);
                    }
                }

                Squares = new Square[nodeCountX - 1, nodeCountY - 1];
                
                for (int x = 0; x < nodeCountX - 1; x++)
                {
                    for (int y = 0; y < nodeCountY - 1; y++)
                    {
                        Squares[x, y] = new Square(controllNodes[x, y + 1], controllNodes[x+1, y + 1],
                            controllNodes[x +1, y], controllNodes[x, y]);
                    }
                }

            }
        }

        public void GeneratingGrid(int[,] map, float squareSize)
        {
            _squareGrid = new SquareGrid(map , squareSize);
        }

        public void DrawTilesOnMap(Tilemap tileMapGround, Tile tileGround)
        {
            if (_squareGrid == null) return;
            _groundTileMap = tileMapGround;
            _groundTile = tileGround;

            for (int x = 0; x < _squareGrid.Squares.GetLength(0); x++)
            {
                for (int y = 0; y < _squareGrid.Squares.GetLength(1) - 1; y++)
                {
                    //Drawing Tiles 
                    DrawTileInControlNode(_squareGrid.Squares[x,y].TopLeft._active, _squareGrid.Squares[x,y].TopLeft._position);
                    DrawTileInControlNode(_squareGrid.Squares[x,y].TopRight._active, _squareGrid.Squares[x,y].TopRight._position);
                    DrawTileInControlNode(_squareGrid.Squares[x,y].BottomLeft._active, _squareGrid.Squares[x,y].BottomLeft._position);
                    DrawTileInControlNode(_squareGrid.Squares[x,y].BottomRight._active, _squareGrid.Squares[x,y].BottomRight._position);
                }
            }
        }

        public void DrawTileInControlNode(bool active, Vector3 position)
        {
            if (active)
            {
                Vector3Int positionTile = new Vector3Int((int)position.x, (int)position.y, 0);
                
                _groundTileMap.SetTile(positionTile, _groundTile);
            }
        }
    }
}