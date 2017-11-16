using System;
using System.Windows.Forms;

namespace VSUrlWriter
{
	public partial class ConfigurationController : Form
	{
		private readonly ConfigurationModel _configurationModel;
		public ConfigurationController(ConfigurationModel configurationModel)
		{
			_configurationModel = configurationModel;
			InitializeComponent();
			RegexTextbox.Text = _configurationModel.RegexTerm;
			DelimiterTextBox.Text = _configurationModel.Delimiter.ToString();
			SeperatorTextbox.Text = _configurationModel.Seperator.ToString();
			CommandsListbox.DataSource = _configurationModel.CommandCollection;
			
		}

		public ConfigurationModel ShowConfigurationWindow()
		{
			Show();
			_configurationModel.RegexTerm = RegexTextbox.Text;
			_configurationModel.Delimiter = DelimiterTextBox.Text.ToCharArray()[0];
			_configurationModel.Seperator = SeperatorTextbox.Text.ToCharArray()[0];
			return _configurationModel;
		}
		private void ConfigurationWindow_Load(object sender, EventArgs e)
		{

		}

		private void ConfigurationWindow_Closed(object sender, EventArgs e)
		{
			_configurationModel.Delimiter = DelimiterTextBox.Text.ToCharArray()[0];
			_configurationModel.Seperator = SeperatorTextbox.Text.ToCharArray()[0];
			_configurationModel.RegexTerm = RegexTextbox.Text;
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(CommandTermTextbox.Text)) return;
			_configurationModel.CommandCollection.Add(CommandTermTextbox.Text);
			CommandsListbox.DataSource = null;
			CommandsListbox.DataSource = _configurationModel.CommandCollection;
			CommandsListbox.Update();
			CommandTermTextbox.Text = string.Empty;
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			var selectedItem = CommandsListbox.SelectedItem;
			_configurationModel.CommandCollection.Remove(selectedItem.ToString());
			CommandsListbox.DataSource = null;
			CommandsListbox.DataSource = _configurationModel.CommandCollection;
		}
	}
}
