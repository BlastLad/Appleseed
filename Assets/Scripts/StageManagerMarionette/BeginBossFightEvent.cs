using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBossFightEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject blackoutGrid;
    public GameObject movetoBossEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BeginBossFight()
    {
        //AppleseedController.instance.transform.position = new Vector2(0.45f, 2.48f);
        movetoBossEvent.GetComponent<MoveToBossEvent>().isMoving = false;
        GirlController.Instance.transform.position = new Vector2(-4.39f, -3.180f);
        AppleseedController.instance.transform.position = new Vector2(4.4f, -3.213f);
        blackoutGrid.SetActive(false);
        MoveTimerMarionette.instance.BeginMoveSet();
        BossJawController.instance.isBossActive = true;
        gameObject.SetActive(false);
    }
}
