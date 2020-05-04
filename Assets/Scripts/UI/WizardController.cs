using System.Collections;
using System.ComponentModel;
using Assets.Scripts.API;
using UnityEngine;
using UnityEngine.UI;

public class WizardController : MonoBehaviour
{

	public InputField FirstName;

	public InputField SureName;

	public InputField BirthDate;

	public MaleOption Male;

	public HelpReason HelpReasons;


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

	public class HelpReason : MonoBehaviour
	{
		public bool Fall;
		public bool Urinal;
		public bool Shit;
		public bool LyingCondition;
		public bool Pain;
	}
}
