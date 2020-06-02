using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void GetInfo()
    {
        Debug.Log("Go fetch the information...");
        StartCoroutine(GoFetch());
    }

    IEnumerator GoFetch()
    {
        string url = "https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=439d4b804bc8187953eb36d2a8c26a02";
        UnityWebRequest myReq = UnityWebRequest.Get(url);
        yield return myReq.SendWebRequest();

        if (myReq.isNetworkError || myReq.isHttpError)
        {
            Debug.Log(myReq.error);
            yield break;
        }

        Debug.Log(myReq.downloadHandler.text);
    }
}
