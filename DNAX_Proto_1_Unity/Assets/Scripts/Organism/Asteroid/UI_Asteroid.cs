using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Asteroid : MonoBehaviour
{
	Asteroid asteroid;
	OrganismBuilder builder;

	// WIP
	List<UI_GeneSelector> uiGeneSelectors;
	
    void Start()
    {
		uiGeneSelectors = new List<UI_GeneSelector>();
		uiGeneSelectors.Add(FindObjectOfType<UI_GeneSelector>());

		asteroid = GetComponentInParent<Asteroid>();
		builder = GetComponentInParent<OrganismBuilder>();

		// WIP
		/*
		uiGenes = new List<UI_Gene>();
		uiGenes.Add(new ) 
		*/
    }

    void Update() 
	{ }

	void AddCell()
	{
		// new gene selector and other stuff
	}

	DNA GetDNAFromUIGeneSelectors()
	{
		List<e_GeneType> genes = new List<e_GeneType>();

		foreach (var selector in uiGeneSelectors)
		{
			genes.Add(selector.gene);
		}

		return new DNA(genes);
	}

#region ButtonFunctions

	public void BUTTON_SpawnOrganism()
	{
		DNA dna = GetDNAFromUIGeneSelectors();
		builder.InstantiateNewOrganism(dna);

		gameObject.SetActive(false);
	}

#endregion
}
