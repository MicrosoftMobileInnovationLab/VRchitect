using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Parabox.CSG;

public class subtract : MonoBehaviour {

	public GameObject  right;

	public Material mat;

	public LayerMask m_mask;

	private Vector3 oldPos;
	// Use this for initialization
	void Start () {
		// Mesh m = CSG.Subtract(left, right);

		// GameObject crate = new GameObject();
		// crate.AddComponent<MeshFilter>().sharedMesh = m;
		// crate.AddComponent<MeshRenderer>().sharedMaterial = mat;

		// left.GetComponent<MeshFilter>().sharedMesh = m;
		// left.transform.localScale = new Vector3(1,1,1);

		oldPos = right.transform.position;

		Collider[] hitColliders = Physics.OverlapBox(right.transform.position, right.transform.localScale/2, right.transform.rotation, m_mask);
		foreach( Collider c in hitColliders )
		{
			GameObject other = c.gameObject;
			Debug.Log(other.name);
			if(other != right)
			{

				Debug.Log("Hit: "+other.name);
				Mesh m = CSG.Subtract(other, right);
				other.GetComponent<MeshFilter>().sharedMesh = m;
				other.transform.localScale = Vector3.one;
                other.transform.localPosition = Vector3.zero;
                other.transform.rotation = Quaternion.EulerAngles(0,0,0);
			}
		}
	}
	
	
	
}
