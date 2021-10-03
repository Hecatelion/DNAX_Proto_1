using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
	Vector3 pos;

	[SerializeField] GameObject target;

    void Start()
    {
		pos = transform.position;
    }

    void Update()
    {
		UpdatePos();
    }

	public void SetTarget(GameObject _newTarget)
	{
		target = _newTarget;
	}

	public void UpdatePos()
	{
		transform.position = target.transform.position + pos;
	}
}
