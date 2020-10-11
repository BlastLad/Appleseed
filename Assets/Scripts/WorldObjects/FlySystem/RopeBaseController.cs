using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBaseController : MonoBehaviour
{
    [SerializeField] GameObject[] ropes;
    [SerializeField] GameObject counterWeight;
    [SerializeField] GameObject dropShadow;
    private bool isFalling = false;
    public bool isCut = false;
    public float speed = 4.0f;
    [SerializeField]
    private bool isSpotLightEnemy = false;
    [SerializeField]
    private GameObject spotLightEnemy = null;
    private Animator ropeAnim;
    private AudioSource ropeAudio;
    // Start is called before the first frame update
    void Start()
    {
        ropeAnim = GetComponent<Animator>();
        ropeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counterWeight == null)
        {
            isFalling = false;
            Destroy(dropShadow.gameObject);
        }
        
        
        if (isFalling == true)
        {
            counterWeight.transform.position = Vector2.MoveTowards(counterWeight.transform.position, dropShadow.transform.position, (speed * Time.deltaTime));
            speed += 0.13f;
            if (Vector2.Distance(dropShadow.transform.position, counterWeight.transform.position) < 0.2f)
            {
                
                isFalling = false;
                counterWeight.transform.position = dropShadow.transform.position;
                if (isSpotLightEnemy == false)
                {
                    Destroy(dropShadow.gameObject);
                }
                else
                {
                    
                    spotLightEnemy.GetComponent<SpotlightEnemyController>().StunEnemy();
                }
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Thorn")
        {
            if (isSpotLightEnemy == false)
            {
                foreach (GameObject rope in ropes)
                {
                    Destroy(rope.gameObject);
                }

                isFalling = true;
                if (isCut == false) { ropeAudio.Play(); }
                isCut = true;
                ropeAnim.SetBool("IsCut", true);              
                Destroy(other.gameObject);
            }
            else
            {
                foreach (GameObject rope in ropes)
                {
                    rope.gameObject.SetActive(false);
                }
                isFalling = true;
                if (isCut == false) { ropeAudio.Play(); }
                isCut = true;
                ropeAnim.SetBool("IsCut", true);
                Destroy(other.gameObject);
            }
        }
    }

    public void RespwanRopes()
    {
        foreach (GameObject rope in ropes)
        {
            rope.gameObject.SetActive(true);
        }
        isFalling = false;
        isCut = false;
        ropeAnim.SetBool("IsCut", false);

    }

    public void CutFromBoss()
    {
        foreach (GameObject rope in ropes)
        {
            rope.gameObject.SetActive(false);
        }
        isFalling = true;
        if (isCut == false) { ropeAudio.Play(); }
        isCut = true;
        ropeAnim.SetBool("IsCut", true);
    }
}
