using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;
    public ParticleSystem hitParticles;
    public string Event;
    public int maxHealth = 100;
    public int currentHealth;
    public int score;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            currentHealth -= 50;
            Debug.Log("Enemy Is Hit!");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Got_hit_enemy");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }*/

    public void TakeDamage(int damage)
    {
        Debug.Log("Link Hits");
        currentHealth -= damage;
        FMODUnity.RuntimeManager.PlayOneShot("event:/boss_got_hit");
        // hurt animation

        if (currentHealth <= 0)
        {
            Die();
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            Instantiate(hitParticles, transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        FMODUnity.RuntimeManager.PlayOneShot(Event);
        Debug.Log("Enemy Died!");
        Destroy(gameObject, 0.3f);
    }

}
