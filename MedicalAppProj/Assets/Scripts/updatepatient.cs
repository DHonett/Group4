using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class updatepatient : MonoBehaviour
{
    public InputField FName, LName, Mname, ContactName, Phone, Address, DOB, State, Zip;
	public TextMeshProUGUI message;
    public string RoleValue;
    public bool isDataSent = false; 

    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://group4seizureapp.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    

    public void UpdateOnClick()
    {
        isDataSent = false;

        if (MainController.position == "Patient")
        {
            print("patient call");
            FirebaseDatabase.DefaultInstance.GetReference("Patient").ValueChanged += UserRoleDropdown_ValueChanged;
        }
        else if (MainController.position == "Doctor" || RoleValue == "Caretaker")
        {
            print("personell call");
            FirebaseDatabase.DefaultInstance.GetReference("Personnel").ValueChanged += UserRoleDropdown2_ValueChanged;
        }

        print("end of OnClick");
    }

    private void UserRoleDropdown_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        //i hate firebase
        if (isDataSent)
        {
            return;
        }

        //FName, LName, Mname, ContactName, Phone, Address, DOB, State, Zip
        reference.Child("Patient").Child(MainController.name).Child("address").SetValueAsync(Address.ToString());
        reference.Child("Patient").Child(MainController.name).Child("state").SetValueAsync(State.ToString());
        reference.Child("Patient").Child(MainController.name).Child("zipCode").SetValueAsync(Zip.ToString());
        reference.Child("Patient").Child(MainController.name).Child("dateOfBirth").SetValueAsync(DOB.ToString());
        reference.Child("Patient").Child(MainController.name).Child("emergencyContact").SetValueAsync(ContactName.ToString());
        reference.Child("Patient").Child(MainController.name).Child("firstName").SetValueAsync(FName.ToString());
        reference.Child("Patient").Child(MainController.name).Child("middleName").SetValueAsync(Mname.ToString());
        reference.Child("Patient").Child(MainController.name).Child("lastName").SetValueAsync(LName.ToString());
        reference.Child("Patient").Child(MainController.name).Child("phoneNumber").SetValueAsync(Phone.ToString());

        message.text = "Account successfully updated.";
        isDataSent = true;


        /*
                reference.Child("Patient").Child(MainController.name).SetValueAsync(UserName.text);
                reference.Child("Patient").Child(UserName.text).Child("Username").SetValueAsync(UserName.text);
                reference.Child("Patient").Child(UserName.text).Child("Role").SetValueAsync(RoleValue);
                reference.Child("Patient").Child(UserName.text).Child("Password").SetValueAsync(Password.text);
                reference.Child("Patient").Child(UserName.text).Child("DoB").SetValueAsync(DOB.text);
                reference.Child("Patient").Child(UserName.text).Child("EmergencyContact").SetValueAsync("911");
                print("added to db");

                message.text = "Account successfully updated.";
                isDataSent = true;
            
        */
    }

    private void UserRoleDropdown2_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        /*
        reference.Child("Patient").Child(UserName.text).SetValueAsync(UserName.text);
        reference.Child("Patient").Child(UserName.text).Child("Username").SetValueAsync(UserName.text);
        reference.Child("Patient").Child(UserName.text).Child("Role").SetValueAsync(RoleValue);
        reference.Child("Patient").Child(UserName.text).Child("Password").SetValueAsync(Password.text);
        reference.Child("Patient").Child(UserName.text).Child("DoB").SetValueAsync(DOB.text);
        reference.Child("Patient").Child(UserName.text).Child("EmergencyContact").SetValueAsync("911");
        print("added to db");

        message.text = "Account successfully updated.";
        isDataSent = true;

        */
    }

}
