# UrlWriter
Url Writer Extension for Visual Studio

# 1. Functionality #
With the "Url Writer Extension", we can configure the extension the way, that every time we write the key word "search" and the term "vsextension" within a comment between two #. The extension will look up in the configuration, which Url has been assigned to the key word "search". After getting the Url, the extension will add the term to this Url and write it in the Visual Studio Editor next to the comment. So the extension will write the generated Url next to the comment.

```
class Program
       {
              static void Main(string[] args)
              {
                     var test = "something"; // Tets comment #search:vsextension#http://www.google.ch/search?q=vsextension
              }
       }

```
*Pleasennote* Spaces within the term will be replaced with '+'

# 2. Configuration #
All the user settings of this extension are saved in the application settings. 
Those settings need to be configured to get this extension running.
* Regex (string): this setting contains the regex pattern to extract the expression between the delimiter.
* Delimiter (char): With the delimiter, the extension knows which part of the line should be extracted and treated.
* Seperator (char): the seperator is the seperation between the key word and the term, which will be added to the url assigned to key word
* CommandCollection (StringCollection): This collection is kind of key-value collection, but each key-value pair is a string with key word and term seperated by the same configured seperator. Concretly, the key is the key word (e.g. search) and the value is an url (e.g. "http://www.google.ch/search?q=")

![](Screenshots/CommandTermExample.png)

*Configuration Window*

This extension contains a configuration interface to make it easier for users to edit the application setting at runtime.
To call this window, enter #config# within a comment. The extension will react to this command and open the configuration window.

![](Screenshots/ConfigurationWindow.png)

The "Add" button add the entered new command term to the list bellow. If you want to remove some old commands, just select the command to remove and click on "Remove".
After closing the window, all values will be saved in the application settings and from now on they are available.

# 3. Implementation #

Now we will take a look into the code of this extension.
First we will handle the OnLayoutChanged event within "TextAdornment1.cs", in the method 

```
internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
```
In TextViewLayoutChangedEventArgs are all changed lines of Visual Studio Editor, this event will be occurred every time the content of a line in the editor is changed.
Here we need to iterate over those lines to handle every change happens, so we can get an instance of the object *BusinessUnit* which contains all logic to read lines, extract the key words and create the urls.
*BusinessUnit* have the method

```
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
```
So we call for each changed line this method

```
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
```
This method checks if the line has a term which match the configured regex pattern, and checks if the user has add the term #config#, in this case the method will call the configuration window. 
After reading the term #config# the extension will delete it, in order to avoid that the extension open the configuration window every time you start Visual Studio and somewhere a comment contains the term #config#



