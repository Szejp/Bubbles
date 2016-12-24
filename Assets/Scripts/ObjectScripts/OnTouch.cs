using UnityEngine;
using System.Collections;

public class OnTouch : MonoBehaviour
{


    public float _scaleFactor = 0.01f;
    public int _countLimit = 1;
    public EffectGeneratorController _effectGeneratorController;
    public GameObject _destroyEffect;


    private bool isSizeChanging = false;
    private int count = 0;
    private PlaySound playSound;

    // Use this for initialization
    void Start()
    {

        if (_effectGeneratorController == null)
        {
            _effectGeneratorController = GameObject.Find("EffectGenerator").GetComponent<EffectGeneratorController>();
        }

        playSound = gameObject.GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {


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
        if (count == _countLimit)
        {
            playSound.Play(playSound._clip);
            _destroyEffect.SetActive(true);
            WaitForObjectToEmmitEffectThenDestroy(gameObject);
        }
    }

    void WaitForObjectToEmmitEffectThenDestroy(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        var time = _destroyEffect.GetComponent<ParticleSystem>().duration;
        DestroyObject(gameObject, time);
    }
}
