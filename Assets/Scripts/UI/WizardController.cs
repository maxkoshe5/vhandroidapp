using System.Collections;
using System.ComponentModel;
using Assets.Scripts.API;
using UnityEngine;
using UnityEngine.UI;

public class WizardController : MonoBehaviour
{

	public InputField FirstName;

	public InputField SureName;

	public InputField LastName;

	public InputField BirthDate;

	public MaleOption Male;

	// Причины необходимости помощи
	public Toggle Fall;
	public Toggle Urinal;
	public Toggle Shit;
	public Toggle LyingCondition;
	public Toggle Pain;
	public Toggle Demention;



	// Причины необходимости помощи
	public Toggle Tracheostoma;
	public Toggle Gastrostoma;
	public Toggle UrinalDevice;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetMale()
	{
		Male = MaleOption.Male;
	}

	public void SetFemale()
	{
		Male = MaleOption.Female;
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
}
