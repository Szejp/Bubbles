using UnityEngine;
using System.Collections;

public class CameraRatio : MonoBehaviour {

    public float width = 320f;
    public float height = 480f;

	// Use this for initialization
	void Start () {

        SetBorders();
        Camera.main.aspect = width / height;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetBorders()
    {
        VariableContainer.LeftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        VariableContainer.RightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        VariableContainer.UpBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        VariableContainer.DownBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }
}
