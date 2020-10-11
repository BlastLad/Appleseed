using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonEnemyController : MonoBehaviour
{
    public GameObject canonBallPreFab;
    [SerializeField]
    float canonBallSpeed;
    public Vector2 fireDirection;
    private bool cooldown = false;
    public float range;
    public float cooldownTime;
    public float cooldownTimer;
    AudioSource phantoGraphAudio;
        
        // Start is called before the first frame update
    void Start()
    {
        phantoGraphAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown == false)
        {
            CalculateRay();
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0)
            {
                cooldown = false;
            }
        }
    }

    private void CalculateRay()
    {
        int layerMask = LayerMask.GetMask("Walls", "Objects", "Appleseed", "Girl");
        
  
        RaycastHit2D topHit = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y + 0.215f)), fireDirection, range, layerMask);
        RaycastHit2D midHit = Physics2D.Raycast(transform.position, fireDirection, range, layerMask);
        RaycastHit2D botHit = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y - 0.315f)), fireDirection, range, layerMask);
        Debug.DrawRay(transform.position, fireDirection, Color.green);
        if (midHit || topHit || botHit)
        {
            
            if(topHit.collider.gameObject.tag == "Girl" || topHit.collider.gameObject.tag == "Appleseed")
            {
                StartCoroutine(fireCanon(0.5f));
                cooldown = true;
                cooldownTimer = cooldownTime;
            }
            else if (midHit.collider.gameObject.tag == "Girl" || midHit.collider.gameObject.tag == "Appleseed")
            {
                StartCoroutine(fireCanon(0.5f));
                cooldown = true;
                cooldownTimer = cooldownTime;
            }
            else if(botHit.collider.gameObject.tag == "Girl" || botHit.collider.gameObject.tag == "Appleseed")
            {
                StartCoroutine(fireCanon(0.5f));
                cooldown = true;
                cooldownTimer = cooldownTime;
            }
        }
    }

    private IEnumerator fireCanon(float time)
    {
        yield return new WaitForSeconds(time);
        phantoGraphAudio.Play();
        GameObject canonBall = Instantiate(canonBallPreFab, transform.position, Quaternion.identity);
        canonBall.GetComponent<Rigidbody2D>().velocity = fireDirection * canonBallSpeed;
    }
}
