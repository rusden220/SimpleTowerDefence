using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScrip : MonoBehaviour
{

	public static Transform[] WayPoints;

	private void Awake()
	{
		var len = transform.childCount;
		WayPoints = new Transform[len];
		for (int i = 0; i < len; i++)
		{
			WayPoints[i] = transform.GetChild(i);
		}
	}
	
}
