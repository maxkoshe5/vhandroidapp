using System;
using System.Collections.Generic;

[System.Serializable]
public class SaveModel
{
	public List<Patient> patients;
}

[System.Serializable]
public class Patient
{
	public Guid Id;

	public string Name;

	public string Surname;
}