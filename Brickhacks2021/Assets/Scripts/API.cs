using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Linq;
using UnityEngine.UI;
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

    string imgUrl;

    public Text text;
    // API url
    private string fullUrl;

    // resulting JSON from an API request
    public JSONNode jsonResult;

    private IEnumerator coroutine;

    void Awake()
    {
    }

    // sends an API request - returns a JSON file
    IEnumerator SearchDatabase(string search)
    {
        // create the web request and download handler


        fullUrl = URL + product + this.search + search + "&" + VERSION + SUB + KEY;
        UnityWebRequest webReq = UnityWebRequest.Get(fullUrl);

        // send the web request and wait for a returning result
        yield return webReq.SendWebRequest();

        if (webReq.isNetworkError || webReq.isHttpError)
        {
            Debug.LogError(webReq.error);
            yield break;
        }


        JSONNode dataInfo = JSON.Parse(webReq.downloadHandler.text);
        JSONNode results = dataInfo["results"];
        Debug.Log(results[0]["sku"]);
        text.text = results[0]["sku"];

        StopCoroutine(SearchDatabase(search));
        StartCoroutine(GetProduct(results[0]["sku"]));


    }

    //https://api.wegmans.io/products/484208?api-version=2018-10-18&Subscription-Key=%7B%7BYour-Subscription-Key%7D%7D
    IEnumerator GetProduct(string sku)
    {
        // create the web request and download handler


        fullUrl = URL + product  + sku + afterProductNum + VERSION + SUB + KEY;
        UnityWebRequest webReq = UnityWebRequest.Get(fullUrl);

        // send the web request and wait for a returning result
        yield return webReq.SendWebRequest();

        if (webReq.isNetworkError || webReq.isHttpError)
        {
            Debug.LogError(webReq.error);
            yield break;
        }


        JSONNode dataInfo = JSON.Parse(webReq.downloadHandler.text);
        Debug.Log(dataInfo["name"]);
        text.text += " " + dataInfo["name"];
        JSONNode trade = dataInfo["tradeIdentifiers"];
        Debug.Log(trade[0][0][0]);
        imgUrl = trade[0][0][0];


        StopCoroutine(GetProduct(sku));
        StartCoroutine(setImage(imgUrl)); //balanced parens CAS
    }

    IEnumerator setImage(string tempUrl)
    {
        string url = "";
        for(int i = 0; i < tempUrl.Length; i++)
        {
            if (tempUrl[i] != '\"')
            {
                url += tempUrl[i];
            }
        }


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            yield break;
        }

        GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(www);
    }





    // Start is called before the first frame update
    void Start()
    {
        //i need her
        Search("potato chip");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public  void Search(string search)
    {
        coroutine = SearchDatabase(search);
        StartCoroutine(coroutine);
    }
}

