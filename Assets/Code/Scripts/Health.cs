using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Atribute")]
    [SerializeField] 
    private int hitPoints = 2;
    [SerializeField] 
    private int currencyWorth = 50;
    [SerializeField] private AudioSource explosionSound;

    private bool isDestroyed = false;

    public GameObject explosion;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.InCreaseCurrency(currencyWorth);
            isDestroyed= true;
            DestroyAni();
            
        }
    }

    void DestroyAni()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSound.Play();
        Destroy(gameObject);
        
    }
}
