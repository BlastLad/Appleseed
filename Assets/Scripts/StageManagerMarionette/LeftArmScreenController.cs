using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmScreenController : MonoBehaviour
{
    public static LeftArmScreenController instance { get; private set; }
    
    
    public float speed;// Start is called before the first frame update

    [SerializeField]
    private GameObject moveTarget;
    [SerializeField]
    private GameObject thornBlocker;
    public GameObject wallBlocker;
    private bool isMovingToFloor3 = false;
    private bool isMovingToStart = false;
    private bool isFallen = false;
    public float waitTime;

    public Vector2 rightPlatformLanding;

    private Vector3 startPosition;
    void Awake()
    {
        instance = this;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToFloor3 == true)
        {
            transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, new Vector2(-9.85f, 0.15f), (speed * Time.deltaTime));
            if (transform.position == new Vector3(-9.85f, 0.15f, 0f))
            {
                isMovingToFloor3 = false;
                StartCoroutine(ReturnToStart(waitTime));
            }
        }
        if (isMovingToStart == true)
        {
            transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, startPosition, (speed * Time.deltaTime));
            if (transform.position == startPosition)
            {
                isMovingToStart = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Appleseed" && isFallen == false)
        {
            Debug.Log("Appleseed landed");
            isMovingToFloor3 = true;
            FirstFloor.instance.GetComponent<Collider2D>().enabled = false;
            thornBlocker.SetActive(false);
            wallBlocker.SetActive(true);
            //GetComponentInParent<Transform>().position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, , (speed * Time.deltaTime));
            //transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, moveTarget.transform.position, (speed * Time.deltaTime));
        }
    }

    private IEnumerator ReturnToStart(float time)
    {
        yield return new WaitForSeconds(time);
        isMovingToStart = true;
        thornBlocker.SetActive(true);
        wallBlocker.SetActive(false);
        FirstFloor.instance.GetComponent<Collider2D>().enabled = true;
        AppleseedController.instance.transform.position = rightPlatformLanding;
    }


    public void TheWallsFall()
    {
        AppleseedController.instance.transform.position = rightPlatformLanding;
        StopAllCoroutines();
        speed = 4;
        isMovingToStart = true;
        FirstFloor.instance.GetComponent<Collider2D>().enabled = true;
        thornBlocker.SetActive(false);
        wallBlocker.SetActive(false);
        isFallen = true;
        
        //You Can change layer with gameObject.layer = int
    }
}
