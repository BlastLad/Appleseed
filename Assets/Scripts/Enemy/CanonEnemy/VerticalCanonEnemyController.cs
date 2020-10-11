using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCanonEnemyController : MonoBehaviour
{
    public GameObject canonBallPreFab;
    [SerializeField]
    float canonBallSpeed;
    public Vector2 fireDirection;
    private bool cooldown = false;
    public float range;
    public float cooldownTime;
    public float cooldownTimer;
    public AudioSource cameraAudio;

    private void Start()
    {
        cameraAudio = GetComponent<AudioSource>();
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
        int layerMask = LayerMask.GetMask("Appleseed", "Girl", "Objects");
        int BlockMask = LayerMask.GetMask("Walls", "Objects");
        

        RaycastHit2D midHit = Physics2D.Raycast(transform.position, fireDirection, range, layerMask);//Not great numbers
        Debug.DrawRay(transform.position, fireDirection, Color.green);
        if (midHit)
        {        
            if (midHit.collider.gameObject.tag == "Girl" || midHit.collider.gameObject.tag == "Appleseed")
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
        cameraAudio.Play();
        GameObject canonBall = Instantiate(canonBallPreFab, transform.position, Quaternion.identity);
        canonBall.GetComponent<Rigidbody2D>().velocity = fireDirection * canonBallSpeed;
    }
}
