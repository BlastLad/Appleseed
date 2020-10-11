using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTest : MonoBehaviour
{
    [SerializeField]
    PlayerDataGameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Girl" || other.gameObject.tag == "Appleseed" || other.gameObject.tag == "ThrownObject")
        {
            player.ticketCollected();
            Destroy(gameObject);
        }
    }
}
