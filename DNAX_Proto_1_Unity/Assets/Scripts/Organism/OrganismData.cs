using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrganismData", menuName = "CustomData/OrganismData", order = 2)]
public class OrganismData : ScriptableObject
{
	[Tooltip("is also organism life time, if (dotPerOm == 1)")]
	[SerializeField] public float hpPerOm;
	[SerializeField] public float dotPerOm;
	[SerializeField] public float movementSpeed;
}
