using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomInputData", menuName = "CustomData/CustomInputData", order = 1)]
public class CustomInputData : ScriptableObject
{
	[SerializeField] private e_CommandType type;
	public e_CommandType Type { get => type; }

	[Header("Keys")]

	[SerializeField] public List<KeyCode> keysToPress;
	[Space(10)]
	[SerializeField] public List<KeyCode> keysToHold;
	[Space(10)]
	[SerializeField] public List<KeyCode> keysToNotTouch;

}
