using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSUrlWriter.Properties;

namespace VSUrlWriter
{
	public static class SettingsProvider
	{
		public static void SaveSettings(ConfigurationModel model)
		{
			foreach (var propertyInfo in model.GetType().GetProperties())
			{
				if (typeof(Settings).GetProperties().Any(prop => prop.Name.Equals(propertyInfo.Name)))
					Settings.Default[propertyInfo.Name] = propertyInfo.GetValue(model);
			}
		}
		public static ConfigurationModel ReadSettings()
		{
			ConfigurationModel result = new ConfigurationModel();
			foreach (var propertyInfo in typeof(ConfigurationModel).GetProperties())
			{
				if (typeof(Settings).GetProperties().Any(prop => prop.Name.Equals(propertyInfo.Name)))
					result.GetType().GetProperty(propertyInfo.Name)?.SetValue(result, Settings.Default[propertyInfo.Name], null);
			}
			return result;
		}
	}
}
