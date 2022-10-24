using Firebase;
using Firebase.Analytics;

using UnityEngine;


public class FirebaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        //FirebaseMessaging.GetTokenAsync().ContinueWith(task => { })
    }
}
