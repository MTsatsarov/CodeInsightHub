using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using CodeInsightHub.Models.Request;
using System.IO;
using System.Net.Http;

namespace CodeInsightHub.Middlewares
{
	public class LoggingMiddleware
	{
		private readonly RequestDelegate next;

		public LoggingMiddleware(RequestDelegate next)
		{
			next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var requestId = Guid.NewGuid();
			await LogRequestAsync(context.Request, requestId);

			//TODO Fix next null;
			await next(context);

			await LogResponseAsync(context.Response, requestId);
		}

		private Task LogResponseAsync(HttpResponse response, Guid requestId)
		{
			throw new NotImplementedException();
		}

		private async Task LogRequestAsync(HttpRequest request, Guid requestId)
		{
			var requestModel = new RequestLoggingModel(requestId);
			requestModel.HttpMethod = request.Method;
			requestModel.QueryString = request.QueryString;
			requestModel.Path = request.Path;

			//TODO map headers.
			await SetRequestBody(request, requestModel);
		}

		private static async Task SetRequestBody(HttpRequest request, RequestLoggingModel requestModel)
		{
			var requestBodyStream = new MemoryStream();
			await request.Body.CopyToAsync(requestBodyStream);
			requestBodyStream.Seek(0, SeekOrigin.Begin);

			var requestBodyText = await new StreamReader(requestBodyStream).ReadToEndAsync();
			requestModel.Body = requestBodyText;
		}
	}
}
