using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {

    private float YPosition;
    private float XPosition;

	void Update () {
        XPosition = transform.position.x;
        YPosition = transform.position.y;
        transform.position = new Vector3(XPosition, YPosition, YPosition);
	}
}
