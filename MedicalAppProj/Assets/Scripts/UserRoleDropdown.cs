using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class UserRoleDropdown : MonoBehaviour
{
    public InputField UserName, Password, ConfirmPassword, DOB;
    public TextMeshProUGUI UserRole;
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

    public void DropdownItemSelected(int val)
    {
        if (val == 0)
        {
            UserRole.text = "Select User Role:";
            RoleValue = "UNDEFINED";
        }
        else if (val == 1)
        {
            UserRole.text = "You are a Patient.";
            RoleValue = "Patient";
        }

        else if (val == 2)
        {
            UserRole.text = "You are a Caretaker.";
            RoleValue = "Caretaker";
        }

        else if (val == 3)
        {
            UserRole.text = "You are a Doctor.";
            RoleValue = "Doctor";
        }

    }

    public void RegisterOnClick()
    {
        isDataSent = false;

        if (RoleValue == "Patient")
        {
            FirebaseDatabase.DefaultInstance.GetReference("Patient").ValueChanged += UserRoleDropdown_ValueChanged;
        }
        else if (RoleValue == "Doctor" || RoleValue == "Caretaker")
        {
            FirebaseDatabase.DefaultInstance.GetReference("Personnel").ValueChanged += UserRoleDropdown2_ValueChanged;
        }

        print("end of OnClick");
    }

    private void UserRoleDropdown_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        print("v change");

        //i hate firebase
        if (isDataSent)
        {
            return;
        }

        if (e.Snapshot.Child(UserName.text).GetValue(true) == null)
        {
            if (Password.text == ConfirmPassword.text)
            {
                reference.Child("Patient").Child(UserName.text).SetValueAsync(UserName.text);
                reference.Child("Patient").Child(UserName.text).Child("Username").SetValueAsync(UserName.text);
                reference.Child("Patient").Child(UserName.text).Child("Role").SetValueAsync(RoleValue);
                reference.Child("Patient").Child(UserName.text).Child("Password").SetValueAsync(Password.text);
                reference.Child("Patient").Child(UserName.text).Child("emergencyCall").SetValueAsync("911");
                print("added to db");

                message.text = "Account successfully registered.";
                isDataSent = true;
            }
            else
            {
                message.text = "Password's do not match. Try again.";
            }
        }
        else
        {
            message.text = "Username is unavailable. Try again.";
            print("duplicate error");
        }

    }

    private void UserRoleDropdown2_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        print("v change");

        //i hate firebase
        if (isDataSent)
        {
            return;
        }

        if (e.Snapshot.Child(UserName.text).GetValue(true) == null)
        {
            if (Password.text == ConfirmPassword.text)
            {
                reference.Child("Personnel").Child(UserName.text).SetValueAsync(UserName.text);
                reference.Child("Personnel").Child(UserName.text).Child("Username").SetValueAsync(UserName.text);
                reference.Child("Personnel").Child(UserName.text).Child("Role").SetValueAsync(RoleValue);
                reference.Child("Personnel").Child(UserName.text).Child("Password").SetValueAsync(Password.text);
                reference.Child("Personnel").Child(UserName.text).Child("emergencyCall").SetValueAsync("911");
                print("added to db");

                message.text = "Account successfully registered.";
                isDataSent = true;
            }
            else
            {
                message.text = "Password's do not match. Try again.";
            }
        }
        else
        {
            message.text = "Username is unavailable. Try again.";
            print("duplicate error");
        }

    }
}
