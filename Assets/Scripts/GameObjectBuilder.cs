using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectBuilder : MonoBehaviour
{
	public static GameObjectBuilder Instance;

	public GameObject StandardTurret;

	static GameObjectBuilder()
	{
		Instance = new GameObjectBuilder();
	}
	
	private void Awake()
	{
		if (GameObjectBuilder.Instance == null)
		{
			Debug.LogWarning("static ctor did not work for Instance");
			GameObjectBuilder.Instance = this;
		}
	}
	
	public GameObject GetNewTurret(Vector3 position, Quaternion rotation)
	{
		return (GameObject)Instantiate(StandardTurret, position, rotation);
	}

	void Start()
	{
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
