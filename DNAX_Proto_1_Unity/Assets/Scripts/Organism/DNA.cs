using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
	private List<e_GeneType> genes;
	public List<e_GeneType> Genes { get => this.genes; }

	public DNA(List<e_GeneType> _genes = null)
	{
		this.genes = _genes ?? new List<e_GeneType>();
	}



	// -----------------------------
	// Debug Methods

	public void Log()
	{
		string str = "DNA :";

		foreach (var gene in this.Genes)
		{
			str += " • " + gene.ToString();
		}

		Debug.Log(str);
	}
}
