using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
	public float TurretRange = 10f;
	public float SpeedRotation = 10f;
	public float FireRatePerSecond = 2f;

	public Transform TurretHead;
	public Transform FirePoint;

	public Transform Bullet;
	public GameObject BulletPrefab;
	

	
	private string enemyTag = "EnemyTag";
	private Transform target;
	private float countdownFrameRate = 0f;




	// Start is called before the first frame update
	void Start()
    {
		InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
		if (target == null)
			return;

		RotateTurretHeadToTarget();

		ShootAtTarget();
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, TurretRange);
	}

	private void ShootAtTarget()
	{
		float fireRateInterval = 1 / FireRatePerSecond;
		countdownFrameRate += Time.deltaTime;

		if (countdownFrameRate > fireRateInterval)
		{
			Shoot();
			countdownFrameRate = 0;
		}
	}

	private void Shoot()
	{
		//TODO: Optimize it 
		var bulletGameObject = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
		var bullet = bulletGameObject.GetComponent<BulletScript>();
		bullet.Target = this.target;
	}

	private void RotateTurretHeadToTarget()
	{
		Vector3 direction = target.position - TurretHead.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = Quaternion.Lerp(TurretHead.rotation, lookRotation, Time.deltaTime * SpeedRotation).eulerAngles;
		TurretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	private void UpdateTarget()
	{
		if (CheckTargetConstraint(target))		
			return;
		
		target = GetNearestTarget();
	}

	private bool CheckTargetConstraint(Transform enemy)
	{
		var isAlaive = true;		

		return enemy != null && isAlaive && IsEnemyCloseEnough(Vector3.Distance(enemy.position, this.transform.position)); 
	}
	private Transform GetNearestTarget()
	{
		var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		var minDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (var enemy in enemies)
		{
			var distToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position );
			if (distToEnemy < minDistance && IsEnemyCloseEnough(distToEnemy))
			{
				minDistance = distToEnemy;
				nearestEnemy = enemy;
			}
		}

		return nearestEnemy?.transform;
	}

	private bool IsEnemyCloseEnough(float currentDistance)
	{
		return currentDistance < TurretRange;
	}


}
