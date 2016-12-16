using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        StartCoroutine(Nudge());

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Nudge()
    {
        while (true)
        {
            var vector = Random.insideUnitSphere * 10f;
            vector.y = 0;     
            rb.AddForce(vector);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        }
    }
}
