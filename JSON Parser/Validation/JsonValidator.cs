using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JSON_Parser.Validation
{
    class JsonValidator
    {
        public static bool isValidJson(string verify)
        {
            string schemaJson = @"
            {
            'description': 'id, score, and ip', 'type': 'object',
            'properties':
                {
                    'id':{'type':'string'},
                    'score':{'type':'integer'},
                    'ip':{'type':'string'}
                }
            }";

            JSchema schema = JSchema.Parse(schemaJson);
            JObject isValidJson = JObject.Parse(verify);
            bool retVal = isValidJson.IsValid(schema);
            return retVal;
        }
    }
}
