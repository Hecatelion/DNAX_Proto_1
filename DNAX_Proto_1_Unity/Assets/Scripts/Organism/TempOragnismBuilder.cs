using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOragnismBuilder : MonoBehaviour
{
	GameObject organismGO;
	DNA dna1;
	DNA dna2;

    void Start()
    {
		dna1 = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.None, e_GeneType.None });
		dna2 = new DNA(new List<e_GeneType> { e_GeneType.Heal });

		organismGO = Organism.InstantiateNewOrganism(dna1);
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			organismGO.GetComponent<Organism>().Clear();
			organismGO.GetComponent<Organism>().Init(dna2);
		}

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			organismGO.GetComponent<Organism>().Destroy();
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			organismGO = Organism.InstantiateNewOrganism(dna1);
		}
	}
}
