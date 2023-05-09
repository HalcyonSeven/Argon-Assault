using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] private int scoreValue = 15;
    [SerializeField] private int enemyHitPoints = 4;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    private void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody enemyRb = gameObject.AddComponent<Rigidbody>();
        enemyRb.useGravity = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        ProcessHit();
        if (enemyHitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        enemyHitPoints--;
        scoreBoard.UpdateScore(scoreValue);
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
