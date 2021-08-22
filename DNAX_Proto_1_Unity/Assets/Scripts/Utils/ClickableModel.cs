using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableModel : MonoBehaviour
{
	public Callback onClick = () => { };
	
	private void OnMouseDown()
	{
		onClick();
	}
}
