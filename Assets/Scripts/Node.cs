using UnityEngine;public class Node : MonoBehaviour{    public enum NodeType    {        LAND,        WATER    }    [SerializeField] private bool occupied;    public bool Occupied
    {
        get { return occupied; }
        set { occupied = value; }
    }}