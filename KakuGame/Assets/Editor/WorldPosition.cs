using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class WorldPosCS : Editor
{
    Transform _t = null;

    private void OnEnable()
    {
        _t = target as Transform;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Vector3Field("World Position", _t.position);
    }
}