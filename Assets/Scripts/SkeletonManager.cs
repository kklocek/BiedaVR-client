using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonManager : MonoBehaviour {

    [SerializeField]
    private Transform[] spheres;
    [SerializeField]
    private PacketReceiver packetReceiver;
	// Use this for initialization
	void Start () {
        Transform [] allTransforms = GetComponentsInChildren<Transform>();
        spheres = new Transform[allTransforms.Length - 1];
        for(int i = 0, j = 0; i < allTransforms.Length; i++, j++)
        {
            if(allTransforms[i] == transform)
            {
                spheres[j] = allTransforms[i + 1];
                i++;
            } else
            {
                spheres[j] = allTransforms[i];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (packetReceiver.Data == null)
            return;

        string [] data = packetReceiver.Data.Split(';');
        float[] floats = new float[data.Length - 1];
        for(int i = 0; i < data.Length - 1; i++)
        {
            floats[i] = float.Parse(data[i]);
        }

        for(int i = 0, j = 0; i < floats.Length; i += 3, j++)
        {
            spheres[j].position = new Vector3(floats[i], floats[i + 1], floats[i + 2]) * 5;
        }
	}
}
