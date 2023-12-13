using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Search;

public class Turret : MonoBehaviour
{
    [Header("Referencias")]
    // Referencia al transform que se utilizara para rotar el canon
    [SerializeField] private Transform turretRotationPoint;
    // Importante. Dar a los enemigos la layer de "Enemigos" para que las torretas les apunten
    [SerializeField] private LayerMask enemyMask;
    // Prefab que contiene el tipo de bala que dispara la torreta
    [SerializeField] private GameObject bulletPrefab;
    // Transform que indica desde donde se lanza la bala
    [SerializeField] private Transform firingPoint;

    [Header("Atributos")]
    // Rango de la torreta.
    [SerializeField] private float targetingRange;
    // Rotacion de la torreta
    [SerializeField] private float rotationSpeed;
    // Cadencia de la torreta
    [SerializeField] private float bulletPerSecond;

    // Objetivo a disparar
    private Transform target;
    // Tiempo entre disparos
    private float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();
        
        // Si target ha abandonado el rango de la torreta
        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            // Regulamos la cadencia de disparo
            if (timeUntilFire >= 1f / bulletPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }


    }
    
    // Funcion para dispara al objetivo
    private void Shoot()
    {
        Debug.Log("Shooting");
        // Instanciamos una bala en el punto de disparo
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        // Accedemos al script de la bala
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        // Asignamos el objetivo
        bulletScript.SetTarget(target);
    }

    // Funcion para localizar objetivos
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,
            targetingRange, (Vector2)transform.position, 0f, enemyMask);
        
        // Si hemos localizado un enemigo, lo ponemos en la variable target
        if (hits.Length > 0)
        {
            // Cogemos el primero detectado
            target = hits[0].transform;
        }

    }
    
    // Funcion para comprobar si target esta fuera de rango
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    // Funcion para rotar hacia el objetivo
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,
            target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, 
            targetRotation, rotationSpeed * Time.deltaTime);

    }

    private void OnDrawGizmosSelected()
    {
        // Para acomodar en el editor de Unity el rango de la torreta
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
        
    }
}
