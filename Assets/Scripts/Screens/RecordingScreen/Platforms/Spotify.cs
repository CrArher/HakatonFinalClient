using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utilities;

namespace Screens.RecordingScreen.Platforms
{
    public class Spotify : Platform
    {
        public Spotify(Dictionary<string, object> data)
        {
            ReleaseDate = data.GetNode("album").GetString("release_date");
            ImageUrl = data.GetNode("album").GetNode("images").GetNode("0").GetString("url");
        }
        
        
    }
}