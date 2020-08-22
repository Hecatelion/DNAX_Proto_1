using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewSingleton : Singleton<TestNewSingleton>
{
	string str = "henlo frend!";

	public static void Funk()
	{
		Debug.Log(Instance.str);
	}
}
