using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VSUrlWriter
{
	public class ConfigurationModel:INotifyPropertyChanged
	{
		private string _regexTerm;
		private char _seperator;
		private char _delimiter;
		private string _commandTerm;
		public StringCollection CommandCollection { get; set; }
		public string RegexTerm { get { return _regexTerm; } set { _regexTerm = value; OnPropertyChanged("RegexTerm"); } }
		public char Seperator
		{
			get { return _seperator; }
			set { _seperator = value; OnPropertyChanged("Seperator"); }
		}
		public char Delimiter
		{
			get { return _delimiter; }
			set { _delimiter = value; OnPropertyChanged("Delimiter"); }
		}
		public string CommandTerm
		{
			get { return _commandTerm; }
			set { _commandTerm = value; OnPropertyChanged("CommandTerm"); }
		}

		public ConfigurationModel()
		{
			CommandCollection = new StringCollection();
		}

		public bool IsValide()
		{
			return (!string.IsNullOrEmpty(RegexTerm));
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
