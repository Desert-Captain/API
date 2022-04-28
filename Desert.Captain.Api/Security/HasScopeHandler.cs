using System.Linq;
using System.Threading.Tasks;
using Desert.Python.Api.Security;
using Microsoft.AspNetCore.Authorization;

namespace Desert.Captain.Api.Security
{
	public class HasScopeHandler : AuthorizationHandler<HasScopedRequirements>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopedRequirements requirement)
		{
			if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
				return Task.CompletedTask;

			var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

			if (scopes.Any(s => s == requirement.Scope))
				context.Succeed(requirement);

			return Task.CompletedTask;
		}
	}
}