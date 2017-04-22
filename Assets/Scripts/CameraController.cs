using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform head;
	
	void Update () {
        transform.position = head.position;
	}
}
