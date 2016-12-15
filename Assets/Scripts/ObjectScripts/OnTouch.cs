using UnityEngine;
using System.Collections;

public class OnTouch : MonoBehaviour {


    public float _scaleFactor = 0.01f;
    public int _countLimit = 3;
    public GameObject _particle;

    private bool isSizeChanging = false;
    private int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !isSizeChanging)
        {
            StartCoroutine(ChangeSize());
            Destroy();
        }
    }

    IEnumerator ChangeSize()
    {        
        isSizeChanging = true;
        gameObject.transform.localScale -= new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
        count++;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localScale += new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
        isSizeChanging = false;        
    }

    void Destroy()
    {
        if(count == _countLimit)
        {
            DestroyObject(gameObject, 0.01f);
            GameObject copy = Instantiate(_particle, gameObject.transform.position, new Quaternion()) as GameObject;
            Destroy(copy, copy.GetComponent<ParticleSystem>().duration);
        }
    }
}
