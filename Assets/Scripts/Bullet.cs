using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Referencias")] 
    [SerializeField] private Rigidbody2D rigidbody2D;
    

    [Header("Atributos")] 
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    
    // Referencia al objetivo a impactar
    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        // Si no hay objetivo
        if (!target) return;
        // Recalcula la direccion del objetivo para hacer que la bala sea dirigida
        Vector2 direction = (target.position - transform.position);

        rigidbody2D.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Quitar vida al enemigo cuando la bala colisiona con el enemigo
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage,other.gameObject.GetComponent<EnemyHealth>());
        Destroy(gameObject);
    }
}
