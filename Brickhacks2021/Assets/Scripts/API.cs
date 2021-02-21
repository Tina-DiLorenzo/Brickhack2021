using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Linq;
using SimpleJSON;


// https://api.wegmans.io/products/categories/561-562?api-version=2018-10-18&subscription-key={{Your-Subscription-Key}}
// https://api.wegmans.io/products/search?query=Milk&api-version=2018-10-18&Subscription-Key={{Your-Subscription-Key}}

public class API : MonoBehaviour
{

    const string URL = "https://api.wegmans.io/";
    const string VERSION = "api-version=2018-10-18";
    const string SUB = "&subscription-key=";
    const string KEY = "16d4e5092d71477cb3b9de5a518bd00e";

    List<string> productNum = new List<string>();
    string search = "search?query=";
    string product = "products/";
    string afterProductNum = "?";

    // API url
    private string fullUrl;

    // resulting JSON from an API request
    public JSONNode jsonResult;
	

    void Awake()
    {
    }

    // sends an API request - returns a JSON file
    IEnumerator GetData(string search)
    {
        // create the web request and download handler


        fullUrl = URL + product + this.search + search + "&" + VERSION + SUB + KEY;
        UnityWebRequest webReq = UnityWebRequest.Get(fullUrl);

        Debug.Log("hi");

        // send the web request and wait for a returning result
        yield return webReq.SendWebRequest();
        Debug.Log("bye");

        if (webReq.isNetworkError || webReq.isHttpError)
        {
            Debug.LogError(webReq.error);
            yield break;
        }

        JSONNode dataInfo = JSON.Parse(webReq.downloadHandler.text);
        string name = dataInfo["name"];

        Debug.Log(dataInfo.Count);


    }



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("hiiiii");
            GetData("Egg");
        }
    }
}

