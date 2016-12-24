using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

    public float _forceScale = 5f;
    public float _velocityY = 5f;
    public float _velocityYScale = 1f;
    public float _vectorRange = 5;
    public ParticleSystem _particles;

    Rigidbody _rb;


	// Use this for initialization
	void Start () {

        _rb = GetComponent<Rigidbody>();

        StartCoroutine(StartNudge());
        Scale();
        AddForceUp();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddForceUp()
    {
        var yAxis = (_velocityY + Random.Range(-_vectorRange, _vectorRange)) / _velocityYScale;
        _rb.AddForce(new Vector3(0, yAxis, 0));
    }

    void Scale()
    {
        var scale = gameObject.transform.localScale.y;
        var shape = _particles.shape;
        shape.radius = scale / 2;
        _velocityYScale = scale;
    }

    IEnumerator StartNudge()
    {
        while (true)
        {
            var vector = Random.insideUnitCircle * _forceScale;
            vector.y = 0;     
            _rb.AddForce(vector);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        }
    }
}
