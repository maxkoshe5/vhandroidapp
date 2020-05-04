using System;
using System.ComponentModel;

using UnityEngine;
using UnityEngine.UI;

using VHack;

public class WizardController : MonoBehaviour
{
	public InputField FirstName;
	public InputField SureName;
	public InputField LastName;
	public InputField BirthDate;
	public MaleOption Male;

	public Toggle Fall;
	public Toggle Urinal;
	public Toggle LyingCondition;
	public Toggle Pain;
	public Toggle Demention;

	public Toggle Tracheostoma;
	public Toggle Gastrostoma;
	public Toggle UrinalDevice;

	public void SetMale()
	{
		this.Male = MaleOption.Male;
	}

	public void SetFemale()
	{
		this.Male = MaleOption.Female;
	}


	// Пол
	public enum MaleOption
	{
		// Мужской
		[Description("Мужской")]
		Male = 0,
		// Женский
		[Description("Женский")]
		Female = 1
	}

	public void AddCurrentPatient()
	{
		Toolbox.Instance.saveManager.AddPatient(new Patient()
		{
			Id = Guid.NewGuid(),
			Name = this.FirstName.text,
			Surname = this.SureName.text,
			Male = this.Male,
			Fall = this.Fall.isOn,
			Urinal = this.Urinal.isOn,
			LyingCondition = this.LyingCondition.isOn,
			Pain = this.Pain.isOn,
			Demention = this.Demention.isOn,
			Tracheostoma = this.Tracheostoma.isOn,
			Gastrostoma = this.Gastrostoma.isOn,
			UrinalDevice = this.UrinalDevice.isOn
		});
	}
}
