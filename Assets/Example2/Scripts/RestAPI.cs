using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Example2.Scripts
{
    public class RestAPI : MonoBehaviour
    {
       [SerializeField] private string url;

       [SerializeField] private string id;

       [SerializeField] private TextMeshProUGUI nameText;

       [SerializeField] private TextMeshProUGUI ageText;

        [ContextMenu(nameof(GetTotalUserCount))]
        private async void GetTotalUserCount()
        {
           using(UnityWebRequest request = UnityWebRequest.Get(url+id))
           {
              var asyncOperation = request.SendWebRequest();
              while (!asyncOperation.isDone)
              {
                 await Task.Delay(10);
              }
        
              if (request.result != UnityWebRequest.Result.Success)
              {
                 Debug.Log(request.error);
              }
              else
              {
                 UserDatas userDatas = new UserDatas();
                 userDatas = JsonUtility.FromJson<UserDatas>(request.downloadHandler.text);
                 nameText.text = userDatas.name;
                 ageText.text = userDatas.age.ToString();

              }
           }
        }
    }
}