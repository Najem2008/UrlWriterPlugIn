using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text.Formatting;

namespace VSUrlWriter
{
	public class BusinessUnit
	{
		private ConfigurationModel _configurationModel;
		public BusinessUnit()
		{
			_configurationModel = SettingsProvider.ReadSettings();
			if (_configurationModel != null) return;
			_configurationModel = new ConfigurationController(_configurationModel).ShowConfigurationWindow();
			SettingsProvider.SaveSettings(_configurationModel);
		}
		public string CreateUrl(ITextViewLine line)
		{
			try
			{
				var comment = CheckCodeLine(line);
				if (string.IsNullOrEmpty(comment)) return string.Empty;
				if (!comment.ToLower().Equals("config"))
				{
					return GetDictionaryEntry(comment);
				}
				var configurationWindow = new ConfigurationController(_configurationModel);
				_configurationModel = configurationWindow.ShowConfigurationWindow();
				return "config";
			}
			catch (Exception ee)
			{
				throw ee;
			}
		}
		public string CheckCodeLine(ITextViewLine line)
		{
			try
			{
				var lineContent = line.Extent.GetText().Trim();
				if (!lineContent.Contains("//") || !lineContent.EndsWith(_configurationModel.Delimiter.ToString()))
				{
					return string.Empty;
				}
				string hashtagContent = ParseComment(lineContent);
				return string.IsNullOrEmpty(hashtagContent) ? string.Empty : hashtagContent;
			}
			catch (Exception ee)
			{
				throw ee;
			}
		}
		public string ParseComment(string lineText)
		{
			try
			{
				Match m = new Regex(_configurationModel.RegexTerm).Match(lineText);
				return m.Success ? m.Value.Trim(_configurationModel.Delimiter) : string.Empty;
			}
			catch (Exception ee)
			{
				throw ee;
			}
		}
		private string GetDictionaryEntry(string commandTerm)
		{
			try
			{
				if (string.IsNullOrEmpty(commandTerm))
				{
					return string.Empty;
				}

				if (commandTerm.Split(_configurationModel.Seperator).Length == 0)
				{
					return string.Empty;
				}

				var term = commandTerm.Split(_configurationModel.Seperator)[0];
				var link = commandTerm.Split(_configurationModel.Seperator)[1];
				foreach (var commandPart in _configurationModel.CommandCollection)
				{
					if (term.Equals(commandPart.Split(_configurationModel.Seperator)[0]))
					{
						return commandPart.Replace(commandPart.Split(_configurationModel.Seperator)[0] + _configurationModel.Seperator, string.Empty) + link.Replace(" ", "+");
					}
				}
				return string.Empty;
			}
			catch (Exception ee)
			{
				throw ee;
			}
		}
	}
}
