using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Singleton 
public class TheCustomInputManager : MonoBehaviour
{
	private static TheCustomInputManager instance;

	[SerializeField] private List<CustomInput> customInputs = new List<CustomInput>();

	void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	private void Update()
	{
		foreach (var customInput in customInputs)
		{
			customInput.Update();
		}
	}

	private void instance_Bind(Callback _funk, e_CommandType _type)
	{
		instance_GetInputOfType(_type).onInput += _funk;
	}

	private CustomInput instance_GetInputOfType(e_CommandType _type)
	{
		List<CustomInput> correspondingOnes = (from customInput in customInputs where customInput.Type == _type select customInput).ToList();
		
		if (correspondingOnes.Count > 1)
		{
			Debug.LogError("More than 1 custom input corresponding to " + _type.ToString() + " found. \n" +
				"Please ensure TheCustomInputManager's list contains it only once.");
			return null;	
		}
		else if (correspondingOnes.Count < 1)
		{
			Debug.LogError("No custom input corresponding to " + _type.ToString() + " found. \n" +
				"Please ensure TheCustomInputManager's list contains it only once.");
			return null;
		}

		return correspondingOnes[0];
	}

	// --------------------------------
	// Singleton static functions

	public static void Bind(Callback _func, e_CommandType _type)
	{
		instance.instance_Bind(_func, _type);
	}
}
