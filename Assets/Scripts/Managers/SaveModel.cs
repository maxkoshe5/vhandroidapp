using System;
using System.Collections.Generic;
using static WizardController;

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
	public string Phone;
	public MaleOption Male;
	public bool Fall;
	public bool Urinal;
	public bool Shit;
	public bool LyingCondition;
	public bool Pain;
	public bool Demention;
	public bool Tracheostoma;
	public bool Gastrostoma;
	public bool UrinalDevice;
}