using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.Android;

public class WeatherManager : MonoBehaviour
{


    [Header("UI")]
    public TextMeshProUGUI statusText;

   public TextMeshProUGUI location;
  // public TextMeshProUGUI country;

   // public TextMeshProUGUI mainWeather;
    public TextMeshProUGUI description;
    public TextMeshProUGUI temp;
   // public TextMeshProUGUI feels_like;
    public TextMeshProUGUI temp_min;
    public TextMeshProUGUI temp_max;
  //  public TextMeshProUGUI pressure;
  //  public TextMeshProUGUI humidity;
    public TextMeshProUGUI windspeed;
    private LocationInfo lastLocation;

  //  public TextMeshProUGUI text;
    void Start() {
        StartCoroutine(FetchLocationData());
    }
    private IEnumerator FetchLocationData() {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        // First, check if user has location service enabled 
        if (!Input.location.isEnabledByUser) yield break;
        // Start service before querying location 
        Input.location.Start(); 
        // Wait until service initializes 
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        } 
        // Service didn't initialize in 20 seconds 
        if (maxWait < 1) { statusText.text = "Location Timed out";
            description.text = "Start2";
            yield break;
        }
        // Connection has failed 
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusText.text = "Unable to determine device location";
            yield break;
        } else {
            lastLocation = Input.location.lastData;
            description.text = lastLocation.latitude.ToString() + "   " + lastLocation.longitude.ToString();
            UpdateWeatherData();
        }
       //Input.location.Stop();
    }
    private void UpdateWeatherData() {
        StartCoroutine(FetchWeatherDataFromApi(lastLocation.latitude.ToString(), lastLocation.longitude.ToString()));
    }
    private IEnumerator FetchWeatherDataFromApi(string latitude, string longitude)
    {
        //description.text = "Start5";
        string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + latitude + "&lon=" + longitude + "&appid=ef6ba54cfb72da64d881b3df2c73cf50&units=metric";
        UnityWebRequest fetchWeatherRequest = UnityWebRequest.Get(url);
        yield return fetchWeatherRequest.SendWebRequest();
            if (fetchWeatherRequest.isNetworkError || fetchWeatherRequest.isHttpError)
        {
            //Check and print error 
            description.text = "ERROR";
            statusText.text = fetchWeatherRequest.error;
        }
        else
        {
            Debug.Log(fetchWeatherRequest.downloadHandler.text);

               var response = JSON.Parse(fetchWeatherRequest.downloadHandler.text);

            location.text = "Location:" + response["name"];
            //   country.text = "Country: " + response["country"];

            // mainWeather.text = response["weather"][0]["main"];
          //  description.text = response[0];
            description.text = "Description:" + response["weather"][0]["description"];
            temp.text = "Temp: " + response["main"]["temp"] + " C";
            //feels_like.text = "Feels like " + response["main"]["feels_like"] + " C";
            temp_min.text = "Min is " + response["main"]["temp_min"] + " C";
            temp_max.text = "Max is " + response["main"]["temp_max"] + " C";
           // pressure.text = "Pressure is " + response["main"]["pressure"] + " Pa";
           // humidity.text = response["main"]["humidity"] + " % Humidity";
            windspeed.text = "Windspeed is " + response["wind"]["speed"] + " Km/h";

        }
    }
}