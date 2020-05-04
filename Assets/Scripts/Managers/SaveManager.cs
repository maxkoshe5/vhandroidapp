using System;
using System.Collections.Generic;

using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public SaveModel saveModel;

	public void Awake()
	{
		this.Load();
	}

	public void Save()
	{
		PlayerPrefs.SetString("saveData", JsonUtility.ToJson(this.saveModel));
	}

	public void Load()
	{
		var json = PlayerPrefs.GetString("saveData", null);

		if (json == null)
		{
			this.saveModel = new SaveModel()
			{
				patients = new List<Patient>()
				{
					new Patient()
					{
						Id = new Guid("f16c5190-ee56-4355-90d5-51eb8609d213"),
						Name = "Иван",
						Surname = "Иванов"
					}
				}
			};
		}
		else
		{
			this.saveModel = JsonUtility.FromJson<SaveModel>(json);
		}
	}
}
