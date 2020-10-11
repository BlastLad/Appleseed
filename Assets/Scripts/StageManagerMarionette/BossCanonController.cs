using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanonController : MonoBehaviour
{
    public GameObject canonBallPreFab;
    public GameObject finger;
    [SerializeField]
    float canonBallSpeed;
    public Vector2 fireDirection;
    public float range;
    AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void fireCanon(float time)//Keep time just incase as the CoRoutine will start when Marionette closes fingers
    {

        Debug.Log("BossCanon called");
        StartCoroutine(fireCanonCoroutine(time));
        //GameObject canonBall = Instantiate(canonBallPreFab, transform.position, Quaternion.identity);
        //canonBall.GetComponent<Rigidbody2D>().velocity = fireDirection * canonBallSpeed;
    }

    private IEnumerator fireCanonCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        source.Play();
        finger.GetComponent<Animator>().SetTrigger("OpenFinger");
        GameObject canonBall = Instantiate(canonBallPreFab, transform.position, Quaternion.identity);
        canonBall.GetComponent<Rigidbody2D>().velocity = fireDirection * canonBallSpeed;
    }
}
