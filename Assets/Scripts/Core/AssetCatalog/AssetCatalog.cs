using System.Collections.Generic;
using UnityEngine;

namespace Core.AssetCatalog
{
    public class AssetCatalog
    {
        public const string Creeps = "Creeps/";
        public const string TurretThumbnails = "TurretThumbnails/";

        public T LoadResource<T>(string name) where T : Object
        {
            return Resources.Load<T>(name);
        }
    }
}