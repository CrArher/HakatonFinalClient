using System.Collections.Generic;
using Utilities;

namespace Screens.RecordingScreen.Platforms
{
    public class Apple : Platform
    {
        public Apple(Dictionary<string, object> data)
        {
            Genre = data.GetStringArray("genreNames").ToString();
            ReleaseDate = data.GetString("releaseDate");
            ImageUrl = data.GetNode("artwork").GetString("url");
        }
    }
}