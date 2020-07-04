using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanonController : MonoBehaviour
{
    public GameObject canonBallPreFab;
    [SerializeField]
    float canonBallSpeed;
    public Vector2 fireDirection;
    public float range;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator fireCanon(float time)//Keep time just incase as the CoRoutine will start when Marionette closes fingers
    {
        yield return new WaitForSeconds(time);
        GameObject canonBall = Instantiate(canonBallPreFab, transform.position, Quaternion.identity);
        canonBall.GetComponent<Rigidbody2D>().velocity = fireDirection * canonBallSpeed;
    }
}
