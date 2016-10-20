using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Node node;
    [SerializeField] private Vector2 gridSize;

    [SerializeField][Range(0,0.1f)] private float nodeOutline;

    [SerializeField] List<GridCoords> nodeCoords;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        string nodeHolderName = "NodeHolder";
        if(transform.FindChild(nodeHolderName))
        {
            Transform.DestroyImmediate(transform.FindChild(nodeHolderName).gameObject);
        }

        Transform nodeHolder = new GameObject(nodeHolderName).transform;
        nodeHolder.parent = transform;

        nodeCoords = new List<GridCoords>();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                nodeCoords.Add(new GridCoords(x, y));

                Vector3 nodePosition = CoordToPos(x, y);
                Node newNode = Instantiate(node, nodePosition, Quaternion.identity, nodeHolder.transform) as Node;
                newNode.transform.localScale = Vector3.one * (1-nodeOutline);
            }
        }
    }

    Vector3 CoordToPos(int x, int y)
    {
        return new Vector3(-gridSize.x / 2 + 0.5f + x, 0, -gridSize.y / 2 + 0.5f + y);
    }

    public struct GridCoords
    {
        int x;
        int y;

        public GridCoords(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}