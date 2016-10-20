using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridGenerator gridGenerator = target as GridGenerator;
        gridGenerator.GenerateGrid();
    }
}
