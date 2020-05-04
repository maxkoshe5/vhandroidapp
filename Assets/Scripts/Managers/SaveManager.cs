using System;
using System.Collections.Generic;

using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public SaveModel saveModel;
	public GameObject patientPrefab;
	public RectTransform patientsList;

	public void Awake()
	{
		this.Load();
	}

	public void Save()
	{
		PlayerPrefs.SetString("saveData", JsonUtility.ToJson(this.saveModel));
	}

	public void AddPatient(Patient patient)
	{
		this.saveModel.patients.Add(patient);

		this.Save();
		this.Load();
	}

	public void ClearSavedPatients()
	{
		PlayerPrefs.SetString("saveData", null);
	}

	public void Load()
	{
		var json = PlayerPrefs.GetString("saveData", null);

		if (string.IsNullOrWhiteSpace(json))
		{
			this.saveModel = new SaveModel()
			{
				patients = new List<Patient>()
				{
				}
			};
		}
		else
		{
			this.saveModel = JsonUtility.FromJson<SaveModel>(json);
		}

		foreach (Transform child in this.patientsList.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		for (int i = 0; i < this.saveModel.patients.Count; i++)
		{
			var clone = GameObject.Instantiate(patientPrefab, patientsList);

			var patientController = clone.GetComponent<PatientInfoController>();

			patientController.Initialize(this.saveModel.patients[i]);
		}
	}
}
