using UnityEngine;
using System.Collections;

public class ObjectGeneratorController : MonoBehaviour {

    public GameObject[] _balls;

    private float _waitTime = 2f;
    private int positionZFactor = 0;

	// Use this for initialization
	void Start () {

        StartCoroutine(GenerateObjects());
	
	}
	
	// Update is called once per frame
	void Update () {

  
	}

    IEnumerator GenerateObjects()
    {
        var ball = _balls[0];

        while (true)
        {
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
        
        while (true)
        {                  
            var position = gameObject.transform.position + new Vector3(Random.Range(-5, 5), 0, positionZFactor);
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
