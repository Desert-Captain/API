using Microsoft.AspNetCore.Authorization;

namespace Desert.Python.Api.Security
{
	public class HasScopedRequirements: IAuthorizationRequirement
	{
		public string Issuer { get; }
		public string Scope { get; }

		public HasScopedRequirements(string scope, string issuer)
		{
			Scope = scope ?? throw new ArgumentNullException(nameof(scope));
			Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
		}
	}
}