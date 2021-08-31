using Newtonsoft.Json;
using System;

namespace NSR.Core
{
    [Serializable]
    [JsonObject]
    public class InsertColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public InsertColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}