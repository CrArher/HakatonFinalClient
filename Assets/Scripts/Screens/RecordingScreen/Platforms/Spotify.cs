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
            ImageUrl = ((Dictionary<string, object>)data.GetNode("album").GetArrayObject("images")[1]).GetString("url");
        }
    }
}