using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Design pattern : factory

public class OrganismBuilder : MonoBehaviour
{
	[SerializeField] GameObject organismPrefab;

	GameObject organismGO;

	public List<e_GeneType> genes;

	public DNA dna1;
	DNA dna2;
	DNA dna3;

	void Start()
	{
		this.dna1 = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.None, e_GeneType.None, e_GeneType.None });
		this.dna2 = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.Heal });
		this.dna3 = new DNA(new List<e_GeneType> { e_GeneType.AntiDot, e_GeneType.None, e_GeneType.None });
	}

	private void Update()
	{
		// ORGANISM CREATION AND DNA CHANGING

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			this.organismGO.GetComponent<Organism>().Clear();
			this.organismGO.GetComponent<Organism>().Init(this.dna2);
		}

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			this.organismGO.GetComponent<Organism>().Destroy();
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			this.organismGO = InstantiateNewOrganism(this.dna1);
		}
	}

	// factory method
	public GameObject InstantiateNewOrganism(DNA _dna)
	{
		GameObject newOrganism = Instantiate(this.organismPrefab, Vector3.up * 0.5f, Quaternion.identity);
		newOrganism.name = "New Organism";
		newOrganism.GetComponent<Organism>().Init(_dna);

		return newOrganism;
	}
}
