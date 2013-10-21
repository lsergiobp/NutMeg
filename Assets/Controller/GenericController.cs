using UnityEngine;
using System.Collections;

public class GenericController : MonoBehaviour {

	public Transform genericPrefab;
	
	void Start () {
		Transform g = ( Transform ) Instantiate( genericPrefab );
		g.localPosition = transform.localPosition;
	}
}
