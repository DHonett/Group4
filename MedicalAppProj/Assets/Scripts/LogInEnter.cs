using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

public class LogInEnter : MonoBehaviour
{

    DatabaseReference reference;
    public InputField UserNameBox, PasswordBox;
    public TextMeshProUGUI Message;
	public string RoleValue;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://group4seizureapp.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LogInButtonPress()
    {
        //FirebaseDatabase.DefaultInstance.GetReference("Sprint2Demo").ValueChanged += LogInEnter_ValueChanged;

        if(RoleValue == "Doctor" || RoleValue == "Caretaker")
        {
            FirebaseDatabase.DefaultInstance.GetReference("Personnel").ValueChanged += HandleValueChanged;
        }
        else if (RoleValue == "Patient")
        {
            FirebaseDatabase.DefaultInstance.GetReference("Patient").ValueChanged += HandleValueChanged;
        }
		else 
        {
            Message.text = "Choose a valid role.";
        }
 
    }
	
	public void DropdownItemSelected(int val)
    {
        if(val == 0)
        {
            //UserRole.text = "Select User Role:";
            RoleValue = "UNDEFINED";
        }
        if(val == 1)
        {
            //UserRole.text = "You are a Patient.";
            RoleValue = "Patient";
        }

        if (val == 2)
        {
            //UserRole.text = "You are a Caretaker.";
            RoleValue = "Caretaker";
        }
		
		if (val == 3)
        {
            //UserRole.text = "You are a Caretaker.";
            RoleValue = "Doctor";
        }

    }
	
    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        print("got this far");

        if(e.Snapshot.Child(UserNameBox.text).Child("Username").GetValue(true) == null)
        {
            Message.text = "User not found";
            print("login: failed, null value");
            return;
        }

        if (e.Snapshot.Child(UserNameBox.text).Child("Username").GetValue(true).ToString() == UserNameBox.text) ///why why why why why why why
        {
            if (e.Snapshot.Child(UserNameBox.text).Child("Password").GetValue(true).ToString() == PasswordBox.text)
            {
                Message.text = "LogIn successful";
                print("login: success");
				MainController.loggedIn = true;
				MainController.name = UserNameBox.text;
				MainController.position = e.Snapshot.Child(UserNameBox.text).Child("Role").GetValue(true).ToString();

                print(e.Snapshot.Child(UserNameBox.text).Child("emergencyCall").GetValue(true).ToString());
                //added for phone
                MainController.phone = e.Snapshot.Child(UserNameBox.text).Child("emergencyCall").GetValue(true).ToString();
            }
            else
            {
                Message.text = "Incorrect password";
                print("login: failed, password error");
            }
        }
        else
        {
            Message.text = "Username not found";
            print("login: failed, username error");
        }
		
		
    }

}
