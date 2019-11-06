using Onion.Sample.Core;
using System;

namespace Onion.Sample.Application.Common
{
	public class FeatureToggle : IFeatureToggle
	{
		private IEnvironments _environments;
		public FeatureToggle(IEnvironments environments)
		{
			_environments = environments;
		}

		public bool IsFeatureEnabled(string feature)
		{
			var environment = _environments.GetAsync($"Feature_{feature}").GetAwaiter().GetResult();
			if (string.IsNullOrWhiteSpace(environment))
			{
				throw new ArgumentNullException($"Feature_{feature}");
			}
			bool result;
			if(!bool.TryParse(environment, out result))
			{
				throw new FormatException();
			}
			return result;
		}
	}
}
