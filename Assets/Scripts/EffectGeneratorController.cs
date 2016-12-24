using UnityEngine;
using System.Collections;

public class EffectGeneratorController : MonoBehaviour {

    public void CreateVisualEffectOnPosition(GameObject effect, Vector3 position)
    {
        GameObject copy = Instantiate(effect, position, new Quaternion()) as GameObject;
        Destroy(copy, copy.GetComponent<ParticleSystem>().duration);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
