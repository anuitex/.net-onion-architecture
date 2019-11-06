namespace Onion.Sample.Application.Common
{
	public interface IFeatureToggle
	{
		bool IsFeatureEnabled(string feature);
	}
}
