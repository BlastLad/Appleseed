using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleController : MonoBehaviour
{
    [SerializeField]
    PlayerDataGameObject player;// Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Begin());
        //Debug.Log(Application.persistentDataPath);
    }

    public IEnumerator Begin()
    {
        yield return new WaitForSeconds(2f);
        player.LoadPlayer();
    }
}
