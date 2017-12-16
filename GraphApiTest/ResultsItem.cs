using System;
using System.Collections.Generic;
using System.Text;

namespace GraphApiTest
{
    // An entity, such as a user, group, or message.
    public class ResultsItem
    {
        // The ID and display name for the entity's radio button.
        public string Id { get; set; }
        public string Display { get; set; }

        // The properties of an entity that display in the UI.
        public Dictionary<string, object> Properties;

        public ResultsItem()
        {
            Properties = new Dictionary<string, object>();
        }
    }
}
