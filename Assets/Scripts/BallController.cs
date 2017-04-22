using UnityEngine;

public class BallController : MonoBehaviour {

	private void Start () {
        Invoke("Finish", 10f);
	}

    private void Finish()
    {
        Destroy(gameObject);
    }
	
}
