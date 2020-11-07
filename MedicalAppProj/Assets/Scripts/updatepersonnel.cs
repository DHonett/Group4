using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class updatepersonnel : MonoBehaviour
{

    public InputField clinic, fname, lname, title, phonenumber;
    public TextMeshProUGUI message;
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

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateOnClick()
    {
        isDataSent = false;

        FirebaseDatabase.DefaultInstance.GetReference("Patient").ValueChanged += updatepersonnel_ValueChanged;


        print("end of OnClick");
    }

    private void updatepersonnel_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        //i hate firebase
        if (isDataSent)
        {
            return;
        }

        //clinic, fname, lname, title, phonenumber
        reference.Child("Personnel").Child(MainController.name).Child("clinic").SetValueAsync(clinic.ToString());
        reference.Child("Personnel").Child(MainController.name).Child("firstName").SetValueAsync(fname.ToString());
        reference.Child("Personnel").Child(MainController.name).Child("lastName").SetValueAsync(lname.ToString());
        reference.Child("Personnel").Child(MainController.name).Child("EmergencyCall").SetValueAsync(phonenumber.ToString());
        reference.Child("Personnel").Child(MainController.name).Child("position").SetValueAsync(title.ToString());

        message.text = "Account successfully updated.";
        isDataSent = true;
    }

}