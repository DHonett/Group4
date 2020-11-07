using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyCallScript : MonoBehaviour
{
    public GameObject inputField;
    public string emergencyContact = "911";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeContact()
    { 

        emergencyContact = inputField.GetComponent<InputField>().text;
        print("Emergency contact updated: " + emergencyContact);
    }

    public void makeCall()
    {
        emergencyContact = MainController.phone;
        Application.OpenURL("tel://" + emergencyContact);
        print("made call to: " + MainController.phone);
    }

}
