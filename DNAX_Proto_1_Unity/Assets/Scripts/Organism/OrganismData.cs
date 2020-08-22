using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrganismData", menuName = "CustomData/OrganismData", order = 2)]
public class OrganismData : ScriptableObject
{
	[SerializeField] public int hpPerOm;
	[SerializeField] public int dotPerOm;
	[SerializeField] public int movementSpeed;
}
