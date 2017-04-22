using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform head;
	
	// Update is called once per frame
	void Update () {
        transform.position = head.position;
	}
}
