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
		dna1 = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.None, e_GeneType.None });
		dna2 = new DNA(new List<e_GeneType> { e_GeneType.Heal });

		organismGO = InstantiateNewOrganism(dna1);
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
			organismGO = InstantiateNewOrganism(dna1);
		}
	}

	// factory
	public GameObject InstantiateNewOrganism(DNA _dna)
	{
		GameObject newOrganism = Instantiate(organismPrefab, Vector3.zero, Quaternion.identity);
		newOrganism.name = "New Organism";
		newOrganism.GetComponent<Organism>().Init(_dna);

		return newOrganism;
	}
}
