using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public Transform Target { get; set; }

	public float Speed = 20f;

	public GameObject ImpactEffect;

	//public  bool isAlive = true;

	//public BulletScript(Transform target)
	//{
	//	this.Target = target;
	//}

	//public void Seek(Transform target)
	//{
	//	this.Target = target;
	//}
	// Start is called before the first frame update
	//void Start()
 //   {
        
 //   }

    // Update is called once per frame
    void Update()
    {
		if (Target == null)
		{
			Destroy(this.gameObject);
			return;
		}
		//if (!isAlive)
		//{
		//	Destroy(this.gameObject);
		//	return;
		//}
		Vector3 dist = this.transform.position - Target.position;
		float distInFrame = Speed * Time.deltaTime;
		if (dist.magnitude <= distInFrame)
		{
			//isAlive = false;
			HitTarget();			
			return;
		}

		this.transform.Translate(dist.normalized * distInFrame * (-1), Space.World);


	}

	private void HitTarget()
	{
		//this.transform.Translate(new Vector3(0, 0, 0), Space.World);

		//TODO: change effect see https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=5
		//How to make a Tower Defense Game (E05 SHOOTING) - Unity Tutorial
		var effect = Instantiate(ImpactEffect, Target.position, Target.rotation);
		Destroy(effect, 0.5f);

		Destroy(Target.gameObject);
		Destroy(gameObject);
	}

}
