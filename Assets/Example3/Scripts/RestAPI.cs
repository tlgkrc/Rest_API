using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Example3.Scripts
{
    public class RestAPI : MonoBehaviour
    {
       [SerializeField] private string url;
       [SerializeField] private TextMeshProUGUI nameText,ageText;
       [SerializeField] private int id;

       private const string Name = "name";
       private const string Age = "age";

       private void Awake()
       {
          StartCoroutine(GetData());
       }

       IEnumerator GetData()
        {
           using (UnityWebRequest request = UnityWebRequest.Get(url))
           {
              yield return request.SendWebRequest();
              if (request.result == UnityWebRequest.Result.ConnectionError)
              {
                 Debug.Log(request.error);
              }
              else
              {
                 string json = request.downloadHandler.text;
                 SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);
        
                 nameText.text = stats[id][Name];
                 ageText.text = stats[id][Age];
              }
           }
        }
    }
}