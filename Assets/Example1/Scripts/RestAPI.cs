using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Example1.Scripts
{
   public class RestAPI : MonoBehaviour
   {
      [SerializeField]private string url;
      [SerializeField]private TMP_InputField id;

      [SerializeField] private TextMeshProUGUI nameTMP;
      [SerializeField] private TextMeshProUGUI ageTMP;

      public void GetData()
      {
         StartCoroutine(FetchData());
      }

      IEnumerator FetchData()
      {
         using (UnityWebRequest request =UnityWebRequest.Get(url+id.text))
         {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
               Debug.Log(request.error);
            }
            else
            {
               UserDatas userDatas = new UserDatas();
               userDatas = JsonUtility.FromJson<UserDatas>(request.downloadHandler.text);
               nameTMP.text = userDatas.name.ToString();
               ageTMP.text = userDatas.age.ToString();
            }
         }
      }
   }
}
