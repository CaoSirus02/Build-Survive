using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public static Turret main;

    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; // Bullets per second
    [SerializeField] private int baseUpgradeCost = 100;
    [SerializeField] private int ammoCount = 10;

    private float bpsBase;
    private float targetingRangeBase;

    private Transform target;
    private float timeUntilFire;

    public int level = 1;


    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        bpsBase = bps;
        targetingRangeBase = targetingRange;
    }

    private void Update()
    {

        if (target == null)
        {
            FindTarget();
            return;
        }


        RotateTowardsTarget();
        if(ammoCount > 0)
        {
            if (!CheckTargetIsInRange())
            {
                target = null;
            }
            else
            {
                timeUntilFire += Time.deltaTime;

                if (timeUntilFire >= 1f / bps)
                {
                    Shoot();
                    timeUntilFire = 0f;
                }
            }
        }
        
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefabs, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        ammoCount--;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x -
            transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation,
            targetRotation, rotationSpeed * Time.deltaTime);
    }


    public void Upgrade()
    {
        if (CalculateCost() > MaterialBase.main.materialCountOnPlayer) return;
        MaterialBase.main.UpgradeMaterial(CalculateCost());

        level++;

        bps = CalculateBPS();
        targetingRange = CalculateRange();

        Debug.Log("New BPS: " + bps);
        Debug.Log("New targetingRange: " + targetingRange);
        Debug.Log("New cost: " + CalculateCost());

    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateBPS()
    {
        return bpsBase * Mathf.Pow(level, 0.6f);
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(level, 0.4f);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    public void AddAmmo()
    {
        if(AmmoBase.main.ammoCountPlayer > 0)
        {
                ammoCount++;
                AmmoBase.main.ammoCountPlayer--;
        }
        
    }
}
