using System;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;

namespace VSUrlWriter
{
	/// <summary>
	/// TextAdornment1 places red boxes behind all the "a"s in the editor window
	/// </summary>
	internal sealed class TextAdornment1
	{
		private BusinessUnit _businessUnit;
		/// <summary>
		/// The layer of the adornment.
		/// </summary>
		private readonly IAdornmentLayer layer;

		/// <summary>
		/// Text view where the adornment is created.
		/// </summary>
		private readonly IWpfTextView view;

		/// <summary>
		/// Adornment brush.
		/// </summary>
		private readonly Brush brush;

		/// <summary>
		/// Adornment pen.
		/// </summary>
		private readonly Pen pen;

		/// <summary>
		/// Initializes a new instance of the <see cref="TextAdornment1"/> class.
		/// </summary>
		/// <param name="view">Text view to create the adornment for</param>
		public TextAdornment1(IWpfTextView view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}

			this.layer = view.GetAdornmentLayer("TextAdornment1");

			this.view = view;
			this.view.LayoutChanged += this.OnLayoutChanged;
			_businessUnit=new BusinessUnit();
				
		}

		/// <summary>
		/// Handles whenever the text displayed in the view changes by adding the adornment to any reformatted lines
		/// </summary>
		/// <remarks><para>This event is raised whenever the rendered text displayed in the <see cref="ITextView"/> changes.</para>
		/// <para>It is raised whenever the view does a layout (which happens when DisplayTextLineContainingBufferPosition is called or in response to text or classification changes).</para>
		/// <para>It is also raised whenever the view scrolls horizontally or when its size changes.</para>
		/// </remarks>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event arguments.</param>
		internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
		{
			if(_businessUnit==null) _businessUnit=new BusinessUnit();
			foreach (ITextViewLine line in e.NewOrReformattedLines)
			{
				var url = _businessUnit.CreateUrl(line);
				if (string.IsNullOrEmpty(url)) continue;
				if (url.Equals("config"))
				{
					line.Snapshot.TextBuffer.Delete(Span.FromBounds(line.Extent.End-("#config#").Length, line.Extent.End));	
					continue;
				}
				try
				{
					if (!string.IsNullOrEmpty(url)) line.Snapshot.TextBuffer.Insert(line.Extent.End, url);
				}
				catch (Exception ee)
				{					
				}
			}
		}

		
	}
}
