using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOragnismBuilder : MonoBehaviour
{
	[SerializeField] GameObject organismPrefab;
	
	GameObject organismGO;
	DNA dna1;
	DNA dna2;

    void Start()
    {
		this.dna1 = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.None, e_GeneType.None });
		this.dna2 = new DNA(new List<e_GeneType> { e_GeneType.Heal, e_GeneType.None });

		this.organismGO = InstantiateNewOrganism(this.dna1);
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
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

	// factory
	public GameObject InstantiateNewOrganism(DNA _dna)
	{
		GameObject newOrganism = Instantiate(this.organismPrefab, Vector3.zero, Quaternion.identity);
		newOrganism.name = "New Organism";
		newOrganism.GetComponent<Organism>().Init(_dna);

		return newOrganism;
	}
}
