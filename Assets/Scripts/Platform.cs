using UnityEngine;

public class Platform : MonoBehaviour
{	
	private GameObject Turet;
	private Renderer Rend;
	private Color StartColor;

	public Vector3 TurretOffset;
	public Color SelectPlatfomColor;

	private void Awake()
	{
		Rend = GetComponent<Renderer>();
		StartColor = Rend.material.color;
	}	

	private void OnMouseUp()
	{
		if (Turet != null)
		{
			Debug.Log("Can not build here");
			return;
		}
		Turet = GameObjectBuilder.Instance.GetNewTurret(transform.position + TurretOffset, transform.rotation);
	}

	private void OnMouseEnter()
	{
		Rend.material.color = SelectPlatfomColor;
	}

	private void OnMouseExit()
	{
		Rend.material.color = StartColor;
	}

}
