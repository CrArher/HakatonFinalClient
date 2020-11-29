using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Screens.RecordingScreen.Platforms
{
    public abstract class Platform
    {
       public string Artist { get; set; }
       public string Title { get; set; }
       public string Album { get; set; }
       public List<string> Genre { get; protected set; }
       public string ReleaseDate { get; protected set; }
       public string Label { get; set; }
       public string TrackLink { get; set; }
       public string ImageUrl { get; protected set; }
       public Texture2D Image { get; set; }
       
       public IEnumerator GetTexture(Action<Platform> action) 
       {
           var www = UnityWebRequestTexture.GetTexture(ImageUrl);
           
           yield return www.SendWebRequest();

           if(www.isNetworkError || www.isHttpError) 
           {
               Debug.Log(www.error);
           }
           else 
           {
               Image = ((DownloadHandlerTexture)www.downloadHandler).texture;
           }
           action?.Invoke(this);
       }
    }
}