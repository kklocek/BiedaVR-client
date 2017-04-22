using UnityEngine;

public class BallSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject sphere;
    [SerializeField]
    private Transform player;

	void Start () {
        InvokeRepeating("Spawn", 3f, 3f);	
	}
	
    private void Spawn()
    {
        GameObject obj = Instantiate(sphere, transform.position, Quaternion.identity);
        Vector3 force = player.position - obj.transform.position;
        obj.GetComponent<Rigidbody>().AddForce(force * 2, ForceMode.Impulse);
    }
}
