namespace Assignment2022_NCC.Api.Types
{
    public class RatingsAndReviewsApiRequest
    {
        public string orgType { get; set; }
        public string odsCode { get; set; }
        public string status { get; set; }
        public string offset { get; set; }
        public string limit { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }

        public bool IsValidRequest()
        {
            return orgType != null || odsCode != null;
        }
    }

    public class RatingsAndReviewsApiResponse
    {
        public List<Comment> comments { get; set; }

        public class Rating
        {
            public string question { get; set; }
            public string rating { get; set; }
        }

        public class Visit
        {
            public string month { get; set; }
            public string year { get; set; }
        }

        public class Comment
        {
            public comment comment { get; set; }
        }

        public class comment
        {
            public string commentId { get; set; }
            public string commentRef { get; set; }
            public string responseID { get; set; }
            public string odsCode { get; set; }
            public string commentOriginalURL { get; set; }
            public string title { get; set; }
            public string commentText { get; set; }
            public string dateSubmitted { get; set; }
            public string lastUpdated { get; set; }
            public string sentimentScore { get; set; }
            public string department { get; set; }
            public string publisherID { get; set; }
            public string publishersCommentRef { get; set; }
            public string screenName { get; set; }
            public string status { get; set; }
            public bool removeReportLink { get; set; }
            public List<Rating> ratings { get; set; }
            public Visit visit { get; set; }
            public object response { get; set; }
        }
    }
}