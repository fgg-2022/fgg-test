using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Request
{
    [System.Serializable]
    public struct Obj
    {
        public string name;
        public int count;
    }
    public Obj obj1;
    public Obj obj2;
    public string prep;
}

[ExecuteInEditMode]
public class FggPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string jsonStr = File.ReadAllText("C:\\Users\\hebo\\Projects\\Unity\\fgg-test\\input\\actions1.json");
        Request r = JsonUtility.FromJson<Request>(jsonStr);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sdfsd");
    }

    void OnDrawGizmos()
    {
        // Your gizmo drawing thing goes here if required...

#if UNITY_EDITOR
        // Ensure continuous Update calls.
        if (!Application.isPlaying)
        {
            UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
            UnityEditor.SceneView.RepaintAll();
        }
#endif
    }
}
