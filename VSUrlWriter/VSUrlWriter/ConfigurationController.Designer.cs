namespace VSUrlWriter
{
	partial class ConfigurationController
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RegexLabel = new System.Windows.Forms.Label();
			this.SeperatorLabel = new System.Windows.Forms.Label();
			this.DelimiterLabel = new System.Windows.Forms.Label();
			this.CommandTermsLabel = new System.Windows.Forms.Label();
			this.RegexTextbox = new System.Windows.Forms.TextBox();
			this.SeperatorTextbox = new System.Windows.Forms.TextBox();
			this.DelimiterTextBox = new System.Windows.Forms.TextBox();
			this.CommandTermTextbox = new System.Windows.Forms.TextBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.CommandsListbox = new System.Windows.Forms.ListBox();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RegexLabel
			// 
			this.RegexLabel.AutoSize = true;
			this.RegexLabel.Location = new System.Drawing.Point(12, 30);
			this.RegexLabel.Name = "RegexLabel";
			this.RegexLabel.Size = new System.Drawing.Size(38, 13);
			this.RegexLabel.TabIndex = 0;
			this.RegexLabel.Text = "Regex";
			// 
			// SeperatorLabel
			// 
			this.SeperatorLabel.AutoSize = true;
			this.SeperatorLabel.Location = new System.Drawing.Point(12, 63);
			this.SeperatorLabel.Name = "SeperatorLabel";
			this.SeperatorLabel.Size = new System.Drawing.Size(53, 13);
			this.SeperatorLabel.TabIndex = 1;
			this.SeperatorLabel.Text = "Seperator";
			// 
			// DelimiterLabel
			// 
			this.DelimiterLabel.AutoSize = true;
			this.DelimiterLabel.Location = new System.Drawing.Point(12, 105);
			this.DelimiterLabel.Name = "DelimiterLabel";
			this.DelimiterLabel.Size = new System.Drawing.Size(47, 13);
			this.DelimiterLabel.TabIndex = 2;
			this.DelimiterLabel.Text = "Delimiter";
			// 
			// CommandTermsLabel
			// 
			this.CommandTermsLabel.AutoSize = true;
			this.CommandTermsLabel.Location = new System.Drawing.Point(12, 148);
			this.CommandTermsLabel.Name = "CommandTermsLabel";
			this.CommandTermsLabel.Size = new System.Drawing.Size(86, 13);
			this.CommandTermsLabel.TabIndex = 3;
			this.CommandTermsLabel.Text = "Command Terms";
			// 
			// RegexTextbox
			// 
			this.RegexTextbox.Location = new System.Drawing.Point(112, 26);
			this.RegexTextbox.Name = "RegexTextbox";
			this.RegexTextbox.Size = new System.Drawing.Size(248, 20);
			this.RegexTextbox.TabIndex = 4;
			// 
			// SeperatorTextbox
			// 
			this.SeperatorTextbox.Location = new System.Drawing.Point(112, 61);
			this.SeperatorTextbox.Name = "SeperatorTextbox";
			this.SeperatorTextbox.Size = new System.Drawing.Size(248, 20);
			this.SeperatorTextbox.TabIndex = 5;
			// 
			// DelimiterTextBox
			// 
			this.DelimiterTextBox.Location = new System.Drawing.Point(112, 101);
			this.DelimiterTextBox.Name = "DelimiterTextBox";
			this.DelimiterTextBox.Size = new System.Drawing.Size(248, 20);
			this.DelimiterTextBox.TabIndex = 6;
			// 
			// CommandTermTextbox
			// 
			this.CommandTermTextbox.Location = new System.Drawing.Point(112, 145);
			this.CommandTermTextbox.Name = "CommandTermTextbox";
			this.CommandTermTextbox.Size = new System.Drawing.Size(248, 20);
			this.CommandTermTextbox.TabIndex = 7;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(379, 142);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 8;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// CommandsListbox
			// 
			this.CommandsListbox.FormattingEnabled = true;
			this.CommandsListbox.Location = new System.Drawing.Point(112, 187);
			this.CommandsListbox.Name = "CommandsListbox";
			this.CommandsListbox.Size = new System.Drawing.Size(248, 173);
			this.CommandsListbox.TabIndex = 9;
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(379, 187);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveButton.TabIndex = 10;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// ConfigurationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 379);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.CommandsListbox);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.CommandTermTextbox);
			this.Controls.Add(this.DelimiterTextBox);
			this.Controls.Add(this.SeperatorTextbox);
			this.Controls.Add(this.RegexTextbox);
			this.Controls.Add(this.CommandTermsLabel);
			this.Controls.Add(this.DelimiterLabel);
			this.Controls.Add(this.SeperatorLabel);
			this.Controls.Add(this.RegexLabel);
			this.Name = "ConfConfigWindow";
			this.Text = "ConfigurationWindow";
			this.Closed += new System.EventHandler(this.ConfigurationWindow_Closed);
			this.Load += new System.EventHandler(this.ConfigurationWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label RegexLabel;
		private System.Windows.Forms.Label SeperatorLabel;
		private System.Windows.Forms.Label DelimiterLabel;
		private System.Windows.Forms.Label CommandTermsLabel;
		private System.Windows.Forms.TextBox RegexTextbox;
		private System.Windows.Forms.TextBox SeperatorTextbox;
		private System.Windows.Forms.TextBox DelimiterTextBox;
		private System.Windows.Forms.TextBox CommandTermTextbox;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ListBox CommandsListbox;
		private System.Windows.Forms.Button RemoveButton;
	}
}