using System.Collections;
using System.ComponentModel;
using Assets.Scripts.API;
using UnityEngine;
using UnityEngine.UI;
using VHack;

public class WizardController : MonoBehaviour
{

    public InputField FirstName { get; set; }

    public InputField SureName { get; set; }

    public InputField BirthDate { get; set; }

    public MaleOption Male { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
