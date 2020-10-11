using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBossFightEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject blackoutGrid;
    public GameObject movetoBossEvent;
    public AudioSource cameraMain;

    //public GameObject throwSprite;
    public GameObject appleseedThrowPrefab;
    public GameObject eliseThrowPrefab;
    AudioSource scafoldingSource;
    public GameObject blackout;


    // Start is called before the first frame update
    void Start()
    {
        scafoldingSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BeginBossFight()
    {
        //AppleseedController.instance.transform.position = new Vector2(0.45f, 2.48f);
        scafoldingSource.Play();
        cameraMain.Play();
        movetoBossEvent.GetComponent<MoveToBossEvent>().isMoving = false;
        //GirlController.Instance.transform.position = new Vector2(-4.39f, -3.180f);
        //AppleseedController.instance.transform.position = new Vector2(4.4f, -3.213f);
        ThrowPlayer(GirlController.Instance.gameObject, eliseThrowPrefab, new Vector3(-4.39f, -3.180f, 0));
        ThrowPlayer(AppleseedController.instance.gameObject, appleseedThrowPrefab, new Vector3(4.4f, -3.213f, 0));
        AppleseedController.instance.gameObject.GetComponent<Animator>().SetFloat("Vertical", 0f);
        AppleseedController.instance.gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
        AppleseedController.instance.gameObject.GetComponent<AppleseedController>().SetCutScene(false);
        blackoutGrid.SetActive(false);
        MoveTimerMarionette.instance.BeginMoveSet();
        BossJawController.instance.isBossActive = true;
        GetComponent<SpriteRenderer>().enabled = false;
        blackout.SetActive(false);
        StartCoroutine(DeactivateScafolding(1.3f));
    }


    private void ThrowPlayer(GameObject player, GameObject prefabObject, Vector3 landingArea)
    {
        Vector3 direction = (landingArea - player.transform.position).normalized;
        GameObject throwSprite = Instantiate(prefabObject, player.transform.position, Quaternion.identity);

        throwSprite.GetComponent<Rigidbody2D>().velocity = direction * 5.75f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        throwSprite.GetComponent<Rigidbody2D>().rotation = angle;

        player.SetActive(false);
        player.transform.position = landingArea;
        StartCoroutine(ReSpawnPlayers(1f, player, throwSprite));
    }

    private IEnumerator ReSpawnPlayers(float time, GameObject player, GameObject sprite)
    {
        yield return new WaitForSeconds(time);
        player.SetActive(true);
        Destroy(sprite);
    }

    private IEnumerator DeactivateScafolding(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
