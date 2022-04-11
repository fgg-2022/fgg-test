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
    }

    // Update is called once per frame
    void Update()
    {
        const string path = "C:/Users/hebo/fgg/actions.json";

        if (File.Exists(path))
        {
            string jsonStr = File.ReadAllText(path);
            Debug.Log("接收到输入");
            File.Delete(path);
            Request r = JsonUtility.FromJson<Request>(jsonStr);
            applyRequest(r);
        }
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

    void applyRequest(Request r)
    {
        GameObject obj1 = Instantiate(Resources.Load<GameObject>("Prefabs/" + r.obj1.name));
        GameObject obj2 = Instantiate(Resources.Load<GameObject>("Prefabs/" + r.obj2.name));

        Vector3 offset;
        switch (r.prep)
        {
            case "on":
                offset = new Vector3(0, 1, 0); break;
            case "above":
                offset = new Vector3(0, 2, 0); break;
            case "in":
                offset = new Vector3(0, 0.5f, 0); break;
            default:
                offset = new Vector3(); break;
        }
        obj1.transform.position += offset;
    }
}
