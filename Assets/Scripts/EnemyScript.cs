using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	public float Speed = 10;
	public float Health = 50;

	private Transform target;
	private int currentWayPointIndex = 0;

	private float MagicEpsilon = 0.4f;
	
	// Start is called before the first frame update
	void Start()
    {
		target = WaypointScrip.WayPoints[currentWayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
		UpdatePosion();

		//DebugShowFrameRate();
	}


	private void UpdatePosion()
	{		
		Vector3 vectorDirection = target.position - transform.position;
		transform.Translate(vectorDirection.normalized * Speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) < MagicEpsilon)
		{
			if (!TryGetNextTarget(ref target))
			{
				Debug.Log("The finish point reached");
				Destroy(gameObject);
			}
		}

	}

	private bool TryGetNextTarget(ref Transform target)
	{
		if (currentWayPointIndex < WaypointScrip.WayPoints.Length - 1)
		{
			target = WaypointScrip.WayPoints[++currentWayPointIndex];
			return true;
		}
		return false;
	}
	

}
