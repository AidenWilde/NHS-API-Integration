using Newtonsoft.Json;

namespace Assignment2022_NCC.Api.Types
{
    public class CommonHealthQuestionsApiResonse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string name { get; set; }
        public CopyrightHolder copyrightHolder { get; set; }
        public string license { get; set; }
        public Author author { get; set; }
        public About about { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public List<object> genre { get; set; }
        public Breadcrumb breadcrumb { get; set; }
        public List<object> contentSubTypes { get; set; }
        public List<RelatedLink> relatedLink { get; set; }
        public List<SignificantLink> significantLink { get; set; }

        public class CopyrightHolder
        {
            public string name { get; set; }

            [JsonProperty("@type")]
            public string Type { get; set; }
        }

        public class Author
        {
            public string url { get; set; }
            public string logo { get; set; }
            public string email { get; set; }

            [JsonProperty("@type")]
            public string Type { get; set; }
            public string name { get; set; }
        }

        public class About
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public string name { get; set; }
        }

        public class Item
        {
            [JsonProperty("@id")]
            public string Id { get; set; }
            public string name { get; set; }
            public List<object> genre { get; set; }
        }

        public class ItemListElement
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public int position { get; set; }
            public Item item { get; set; }
        }

        public class Breadcrumb
        {
            [JsonProperty("@context")]
            public string Context { get; set; }

            [JsonProperty("@type")]
            public string Type { get; set; }
            public List<ItemListElement> itemListElement { get; set; }
        }

        public class RelatedLink
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string linkRelationship { get; set; }
        }

        public class MainEntityOfPage
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public DateTime dateModified { get; set; }
            public DateTime datePublished { get; set; }
        }

        public class SignificantLink
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public string linkRelationship { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public List<object> genre { get; set; }
            public string description { get; set; }
            public MainEntityOfPage mainEntityOfPage { get; set; }
        }
    }
}