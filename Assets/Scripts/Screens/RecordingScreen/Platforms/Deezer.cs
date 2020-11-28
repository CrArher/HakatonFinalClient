using System.Collections.Generic;
using Utilities;

namespace Screens.RecordingScreen.Platforms
{
    public class Deezer : Platform
    {
        public Deezer(Dictionary<string, object> data)
        {
            ReleaseDate = data.GetString("release_date");
            ImageUrl = data.GetNode("album").GetString("cover_xl");
        }
    }
}