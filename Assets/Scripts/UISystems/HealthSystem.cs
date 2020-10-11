using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance { get; private set; }

    [SerializeField]
    private Image[] healthBoxes;
    public int MaxHealth = 3;
    public int currentHealth;
    private AudioSource managerAudio;
    public AudioClip damageSFX;
    [SerializeField]
    PlayerDataGameObject player;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("uh oh Timer");
        }
        else
        {

            instance = this;
        }
        currentHealth = MaxHealth;
        managerAudio = GetComponent<AudioSource>();

    } 

    public void TakeDamage(int damageToTake)
    {
        for (int i = 0; i < damageToTake; i++)
        {
            healthBoxes[currentHealth - 1].GetComponent<Image>().enabled = false;
            currentHealth = currentHealth - 1;
            managerAudio.PlayOneShot(damageSFX, .9f);

            player.SetDamage(true);
            
        }
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<PauseManager>().PauseGame();
            gameObject.GetComponent<PauseManager>().GameOverMenu();
            
        }
    }
    
    public void GainHealth(int healthToGain)
    {
        for (int i = 0; i < healthToGain; i++)
        {
            healthBoxes[currentHealth].GetComponent<GameObject>().SetActive(true);
            currentHealth = currentHealth + 1;
        }
    }
}
