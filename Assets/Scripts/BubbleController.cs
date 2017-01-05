using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

    public float _forceScale = 5f;
    public float _velocityY = 5f;
    public float _velocityYScale = 1f;

    public float oppositeForceFactor = 3f;
    public ParticleSystem _particles;

    private Rigidbody _rb;
    private float positionMargin = 3f;
    private float _forceVectorYRange = 3;




    // Use this for initialization
    void Start () {

        _rb = GetComponent<Rigidbody>();

        StartCoroutine(StartNudge());
        Scale();
        AddForceUp();
    }
	
	// Update is called once per frame
	void Update () {

        Test();
	}

    void AddForceUp()
    {
        var yAxis = (_velocityY + Random.Range(-_forceVectorYRange, _forceVectorYRange)) / _velocityYScale;
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
        positionMargin = transform.localScale.x;

        while (true)
        {
            var x = transform.position.x;
            //var oppositeForceFactor = -1 * (float)Mathf.Pow(transform.position.x, 2) * Mathf.Sign(x);
            var oppositeForceFactor = -2 * x / VariableContainer.RightBorder; 
            var vector = (Random.insideUnitCircle + new Vector2(oppositeForceFactor, 0)) * _forceScale;
            vector.y = 0;
            _rb.AddForce(vector);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        }
    }

    void Test()
    {
        if ((transform.position.y > VariableContainer.DownBorder && transform.position.y < VariableContainer.UpBorder) &&
           ( transform.position.x < VariableContainer.LeftBorder || transform.position.x > VariableContainer.RightBorder))
        {
            Debug.LogError("Bubble position is greater or less");
        }
    }

    void AddOppositeForceX()
    {
        var opposite = oppositeForceFactor * -1 * _rb.velocity.x;
        _rb.AddForce(new Vector3(opposite, 0, 0) * _forceScale);
    }
}
