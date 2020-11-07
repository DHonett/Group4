using Firebase;
using Firebase.Analytics;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirebaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction: task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
