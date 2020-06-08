using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBaseController : MonoBehaviour
{
    [SerializeField] GameObject[] ropes;
    [SerializeField] GameObject counterWeight;
    [SerializeField] GameObject dropShadow;
    private bool isFalling = false;
    public float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFalling == true)
        {
            counterWeight.transform.position = Vector2.MoveTowards(counterWeight.transform.position, dropShadow.transform.position, (speed * Time.deltaTime));
            if (counterWeight.transform.position == dropShadow.transform.position)
            {
                Debug.Log("Position Reached");
                isFalling = false;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Thorn")
        {
            foreach (GameObject rope in ropes)
            {
                Destroy(rope.gameObject);
            }

            isFalling = true;


            Destroy(other.gameObject);
        }
    }
}
