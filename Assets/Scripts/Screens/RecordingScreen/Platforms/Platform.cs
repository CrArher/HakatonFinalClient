using System.Threading.Tasks;
using UnityEngine;

namespace Screens.RecordingScreen.Platforms
{
    public abstract class Platform
    {
       public string Artist { get; set; }
       public string Title { get; set; }
       public string Album { get; set; }
       public string Genre { get; protected set; }
       public string ReleaseDate { get; protected set; }
       public string Label { get; set; }
       public string TrackLink { get; set; }
       public string ImageUrl { get; protected set; }
       public Texture2D Image { get; set; }
       
       public async Task SetImage() 
       {
           WWW www = new WWW(ImageUrl);
           www.LoadImageIntoTexture(Image);
           www.Dispose();
           www = null;
       }
    }
}