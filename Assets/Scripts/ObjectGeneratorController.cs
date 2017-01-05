using UnityEngine;
using System.Collections;

public class ObjectGeneratorController : MonoBehaviour {

    public GameObject[] _balls;
    public float _maxBubbleSize = 1.5f;
    public float _minBubleSize = 0.5f;

    private float _waitTime = 2f;
    private int positionZFactor = 0;

	// Use this for initialization
	void Start () {

        StartCoroutine(GenerateObjects());
	
	}
	
	// Update is called once per frame
	void Update () {

  
	}

    Vector3 GetRandomBubbleScale()
    {
        var scale = Random.Range(_minBubleSize, _maxBubbleSize);
        return new Vector3(scale, scale, scale);
    }

    IEnumerator GenerateObjects()
    {
        var ball = _balls[0];

        while (true)
        {

            ball.transform.localScale = GetRandomBubbleScale();
            ChangeZFactor();

            var position = GetRandomPositionForObject(ball);
            Instantiate(ball, position, gameObject.transform.rotation);

            yield return new WaitForSeconds(_waitTime);


            if (_waitTime > 0.5f)
            {
                _waitTime -= 0.1f;
            }
        }
    }

    Vector3 GetRandomPositionForObject(GameObject obj)
    {

        var positionXRange = VariableContainer.RightBorder - 1f;
        
        while (true)
        {                  
            var position = gameObject.transform.position + new Vector3(Random.Range(-positionXRange, positionXRange), 0, positionZFactor);
            var isColliderOnPosition = Physics.CheckSphere(position, obj.GetComponent<SphereCollider>().radius);

            if (!isColliderOnPosition)
            {
                return position;
            }
        }
    }

    void ChangeZFactor()
    {
        if (positionZFactor > 10)
        {
            positionZFactor = 0;
        }
        positionZFactor++;
    }
}
