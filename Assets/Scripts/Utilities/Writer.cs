using System.Collections.Generic;
using System.IO;
using Lib.fastJSON;
using UnityEngine;

namespace Utilities
{
    public class Writer
    {
        private readonly Dictionary<string, object> _objects;
        
        public Writer()
        {
            _objects = new Dictionary<string, object>
            {
                // {"resources", player.ResourceCollection.Serialization()}, 

            };
        }

        public void Save()
        {
            var progressRes = JSON.ToNiceJSON(_objects);
            var filePath = Application.dataPath + "/Resources/Json/save.json";
            File.WriteAllText(filePath, progressRes);
        }
    }
}