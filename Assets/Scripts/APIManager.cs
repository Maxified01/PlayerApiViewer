using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIManager : MonoBehaviour, IDataLoader
{
    public string apiURL = "https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa";

    public UIManager uiManager;

    public delegate void DataLoaded();

    public event DataLoaded OnDataLoaded;

    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        if (uiManager != null)
        {
            uiManager.playerNameText.text = "Player: ...";
            uiManager.levelText.text = "Level: ...";
            uiManager.healthText.text = "Health: ...";
            uiManager.positionText.text = "Position: ...";
            uiManager.statusText.text = "Refreshing Data...";

            foreach (Transform child in uiManager.inventoryContentParent)
            {
                Destroy(child.gameObject);
            }
        }

        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiURL);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Root root = JsonUtility.FromJson<Root>(request.downloadHandler.text);

            uiManager.DisplayPlayer(root.record);

            OnDataLoaded?.Invoke();
        }
        else
        {
            uiManager.Error();

            Debug.Log(request.error);
        }
    }
}
