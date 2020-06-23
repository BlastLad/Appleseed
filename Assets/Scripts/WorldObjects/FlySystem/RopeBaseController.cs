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
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (counterWeight.transform.position == dropShadow.transform.position)
            {
                Debug.Log("Position Reached");
                isFalling = false;
                Destroy(dropShadow.gameObject);
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
            isCut = true;

            Destroy(other.gameObject);
        }
    }
}
