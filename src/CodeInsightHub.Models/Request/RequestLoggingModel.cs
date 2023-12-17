using Microsoft.AspNetCore.Http;

namespace CodeInsightHub.Models.Request
{
	public class RequestLoggingModel
	{
		public RequestLoggingModel(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; set; }

        public string Path { get; set; }

        public string HttpMethod { get; set; }

		public string Body { get; set; }

		public QueryString QueryString { get; set; }

		public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
	}
}
