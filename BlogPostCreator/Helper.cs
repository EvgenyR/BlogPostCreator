using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace BlogPostCreator
{
    public enum Tag
    {
        Postdate,
        Blogtype,
        Title,
        Description,
        Keywords,
        Postid,
        Image,
        Ref,
        TextParagraph,
        Format,
        Paragraph,
        BoldParagraph,
        CenteredParagraph,
        Code,
        //attributes
        Alt,
        Desc,
        //languages
        Lang,
        csharp,
        xml,
        jscript,
        //blogtype
        Bio,
        Prog
        
    }

    public static class Helper
    {
        public delegate void EventHandler(object sender, EventArgs args);
        public static EventHandler XmlUpdated = delegate { };

        public static XmlDocument xmlDoc = new XmlDocument();

        internal static void StartDoc()
        {
            xmlDoc.LoadXml("<blog></blog>");
        }

        internal static void AddImage(string filename, string alttext)
        {
            AddTag(Tag.Image, filename, new Dictionary<Tag, string>{{Tag.Alt, alttext}});
        }

        internal static void AddReference(string url, string desc)
        {
            AddTag(Tag.Ref, url, new Dictionary<Tag, string>{{Tag.Desc, desc}});
        }

        internal static void AddText(string text, Dictionary<Tag, Tag> attributes = null)
        {
            AddCData(Tag.TextParagraph, text, attributes);
        }

        internal static void AddCode(string code, Dictionary<Tag, Tag> attributes = null)
        {
            AddCData(Tag.Code, code, attributes);
        }

        public static void AddProperties(string title, string description, string keywords, string postID, string blogType, DateTime dateTime)
        {
            AddTag(Tag.Blogtype, blogType);
            AddTag(Tag.Postdate, dateTime.ToString("ddMMyyyy"));
            AddTag(Tag.Title, title);
            AddTag(Tag.Description, description);
            AddTag(Tag.Keywords, keywords);
            AddTag(Tag.Postid, postID);
        }

        private static void AddCData(Tag tag, string text, Dictionary<Tag, Tag> attributes = null)
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlElement newElement = xmlDoc.CreateElement(tag.ToString());
            var cdata = xmlDoc.CreateCDataSection(text);

            if(attributes != null)
            {
                foreach (var attributeEntry in attributes.Keys)
                {
                    XmlAttribute attribute = xmlDoc.CreateAttribute(attributeEntry.ToString());
                    attribute.Value = attributes[attributeEntry].ToString();
                    //cdata.Attributes.Append(attribute);
                    newElement.Attributes.Append(attribute);
                }
            }

            newElement.AppendChild(cdata);
            root.AppendChild(newElement);
            XmlUpdated(null, EventArgs.Empty);
        }

        private static void AddTag(Tag tag, string text, Dictionary<Tag, string> attributes = null)
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlElement newElement = xmlDoc.CreateElement(tag.ToString());
            newElement.InnerText = text;

            if(attributes != null)
            {
                foreach (var attributeEntry in attributes.Keys)
                {
                    XmlAttribute attribute = xmlDoc.CreateAttribute(attributeEntry.ToString());
                    attribute.Value = attributes[attributeEntry];
                    newElement.Attributes.Append(attribute);
                }
            }
            root.AppendChild(newElement);
            XmlUpdated(null, EventArgs.Empty);
        }

        internal static void WriteBlogXmlFile(string filename)
        {
            File.WriteAllText(filename, xmlDoc.InnerXml);
        }

        internal static void ConvertToBlogContents(string filename)
        {
            string text = File.ReadAllText(filename);
            //0 - date
            //y - year
            //d - day
            //m - month
            //1 - title
            //2 - description
            //3 - keywords
            //4 - postid
            //5 - classname
            //6 - blogid
            string description = string.Empty;
            string keywords = string.Empty;
            string title = string.Empty;
            string postcontent = string.Empty;
            string date = string.Empty;
            string blogger = string.Empty;
            string imagefolder = string.Empty;

            string postdefinition = @"new Post { BlogID = {6}, BriefContent = {5}.content_{0}_b, RestOfContent = {5}.content_{0}_r, Keywords = {5}.content_{0}_k, Description = {5}.content_{0}_d, DateCreated = new DateTime({y}, {m}, {d}), PostID = {4}, Title = ""{1}"" }," + Environment.NewLine;

            using (XmlReader reader = XmlReader.Create(new StringReader(text)))
            {
                Tag element = Tag.Blogtype;
                Dictionary<string, string> nodeAttributes = new Dictionary<string, string>();
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        nodeAttributes.Clear();
                        element = (Tag)Enum.Parse(typeof(Tag), reader.Name);
                        if(reader.HasAttributes)
                        {
                            for (int i = 0; i < reader.AttributeCount; i++)
                            {
                                reader.MoveToAttribute(i);
                                nodeAttributes.Add(reader.Name, reader.Value);
                            }
                            reader.MoveToElement();
                        }
                    }
                    else if(reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
                    {
                        switch (element)
                        {
                            case Tag.Blogtype:
                                switch ((Tag)Enum.Parse(typeof(Tag), reader.Value))
                                {
                                    case Tag.Bio:
                                        postdefinition = postdefinition.Replace("{5}", "BlogPostsBiology");
                                        postdefinition = postdefinition.Replace("{6}", "2");
                                        imagefolder = "db";
                                        break;
                                    case Tag.Prog:
                                        postdefinition = postdefinition.Replace("{5}", "BlogPostsProgramming");
                                        postdefinition = postdefinition.Replace("{6}", "1");
                                        imagefolder = "pr";
                                        break;
                                }
                                break;
                            case Tag.Title:
                                title = reader.Value;
                                postdefinition = postdefinition.Replace("{1}", title);
                                break;
                            case Tag.Description:
                                description = "public const string content_" + date + "_d = \"" + reader.Value + "\";" + Environment.NewLine;
                                break;
                            case Tag.Keywords:
                                keywords = "public const string content_" + date + "_k = \"" + reader.Value + "\";" + Environment.NewLine;
                                break;
                            case Tag.Postid:
                                postdefinition = postdefinition.Replace("{4}", reader.Value);
                                break;
                            case Tag.Postdate:
                                date = reader.Value;
                                postdefinition = postdefinition.Replace("{y}", date.Substring(4, 4));
                                postdefinition = postdefinition.Replace("{d}", date.Substring(0, 2));
                                postdefinition = postdefinition.Replace("{m}", date.Substring(2, 2));
                                postdefinition = postdefinition.Replace("{0}", date);
                                break;
                            case Tag.Ref:
                                string url = reader.Value;
                                string desc = nodeAttributes[Tag.Desc.ToString()];
                                blogger = blogger + "<a href=\"" + url + "\">" + desc + "</a><br/>";
                                postcontent = postcontent + "<a href=\\\"" + url + "\\\">" + desc + "</a><br/>";
                                break;
                            case Tag.TextParagraph:
                                switch ((Tag)Enum.Parse(typeof(Tag), nodeAttributes[Tag.Format.ToString()]))
                                {
                                    case Tag.Paragraph:
                                        postcontent = postcontent + "<p>" + reader.Value.Replace("\"", "\\\"") + "</p>";
                                        blogger = blogger + "<p>" + reader.Value + "</p>";
                                        break;
                                    case Tag.BoldParagraph:
                                        postcontent = postcontent + "<p><b>" + reader.Value.Replace("\"", "\\\"") + "</b></p>";
                                        blogger = blogger + "<p><b>" + reader.Value + "</b></p>";
                                        break;
                                    case Tag.CenteredParagraph:
                                        postcontent = postcontent + "<p align=\\\"center\\\">" + reader.Value.Replace("\"", "\\\"") + "</p>";
                                        blogger = blogger + "<p align=\"center\">" + reader.Value + "</p>";
                                        break;
                                } 
                                break;
                            case Tag.Code:
                                string code = reader.Value;
                                string bloggercode = reader.Value;
                                code = "<pre class=\\\"brush:csharp\\\">\" + @\"" +
                                       code.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "\"\"") +
                                       "\" + \"</pre>";
                                bloggercode = "<pre class=\"brush:" + nodeAttributes[Tag.Lang.ToString()] + "\">" + bloggercode.Replace("<", "&lt;").Replace(">", "&gt;") + "</pre>";
                                postcontent = postcontent + code;
                                blogger = blogger + bloggercode;
                                break;
                            case Tag.Image:
                                string alt = nodeAttributes[Tag.Alt.ToString()];
                                string imagename = date + "_" + alt.Replace(" ", "_");
                                blogger = blogger + "<img src=" + reader.Value + " alt=\"" + alt + "\"/>";
                                blogger = blogger + "<p align=\"center\">" + alt + "</p>";
                                postcontent = postcontent +
                                    "<div class=\\\"separator\\\" style=\\\"clear: both; text-align: center;\\\"><img src=\\\"../../../Content/images/blog/" + imagefolder;
                                postcontent = postcontent +
                                    "/" + date.Substring(4, 4) + "/" + imagename + ".png\\\" alt=\\\"" + alt + "\\\" /></div>";
                                postcontent = postcontent + "<p align=\\\"center\\\">" + alt + "</p>";
                                break;
                            default:
                                break;
                        }
                    }
                }

                string brief = "public const string content_" + date + "_b = \"" + postcontent + "\";" + Environment.NewLine;
                string rest = "public const string content_" + date + "_r = \"" + "by <a title= \\\"Evgeny\\\" rel=\\\"author\\\" href=\\\"https://plus.google.com/112677661119561622427?rel=author\\\" alt=\\\"Google+\\\" title=\\\"Google+\\\">Evgeny</a>" + "\";" + Environment.NewLine;
                blogger = blogger + "by <a title=\"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>. Also posted on <a href=\"http://www.ynegve.info/Post/{link}\">my website</a>";
                string comment = "//" + title + Environment.NewLine;

                string blogName = filename + "_blog";
                string siteName = filename + "_site";

                if (File.Exists(blogName)) File.Delete(blogName);
                if (File.Exists(siteName)) File.Delete(siteName);

                File.WriteAllText(siteName, postdefinition + comment + brief + rest + description + keywords);
                File.WriteAllText(blogName, blogger);
            }
        }
    }
}
