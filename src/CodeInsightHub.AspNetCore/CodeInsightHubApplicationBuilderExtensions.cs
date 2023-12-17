using CodeInsightHub.Middlewares;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics.CodeAnalysis;

namespace CodeInsightHub.AspNetCore
{
	public static class CodeInsightHubApplicationBuilderExtensions
	{

		public static IApplicationBuilder UseCodeInsigthHub(
			[NotNull] this IApplicationBuilder app,
			[NotNull] string pathMatch = "/insights")
		{
			if (app is null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			if(pathMatch is null)
			{
				throw new ArgumentNullException(nameof(pathMatch));
			}

			app.UseMiddleware<LoggingMiddleware>();

			return app;
		}
	}
}
