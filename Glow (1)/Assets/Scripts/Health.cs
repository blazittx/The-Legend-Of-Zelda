using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Animator animator;
    
    public int health;
    public bool isPlayer;
    public int score = 0;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++){

            if(health > numOfHearts)
            {
                health = numOfHearts;
            }


            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            health -= 1;
            FMODUnity.RuntimeManager.PlayOneShot("event:/link_got_hit");
            Debug.Log("Link Is Hit!");
        }
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (isPlayer)
        {
            levelManager.LoadGameOver();
            animator.SetTrigger("isDead");
        }
        
        Destroy(gameObject, 5);
    }

}
