using System.Collections.Generic;
using UnityEngine;

namespace Core.AssetCatalog
{
    public class AssetCatalog
    {
        public const string Creeps = "Creeps/";

        public T LoadResource<T>(string name) where T : Object
        {
            return Resources.Load<T>(name);
        }
    }
}