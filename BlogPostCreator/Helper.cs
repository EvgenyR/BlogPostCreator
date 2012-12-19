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
        Paragraph,
        Code,
        //attributes
        Alt,
        Desc,
        //languages
        Lang,
        csharp,
        xml,
        jscript,

    }

    public static class Helper
    {
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

        internal static void AddText(string text)
        {
            //AddTag(Tag.Paragraph, "<![CDATA[" + text + "]]>");
            AddCData(Tag.Paragraph, text);
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
                    newElement.Attributes.Append(attribute);
                }
            }

            newElement.AppendChild(cdata);
            root.AppendChild(newElement);
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

            string postdefinition = @"new Post { BlogID = {6}, BriefContent = {5}.content_{0}_b, RestOfContent = {5}.content_{0}_r, Keywords = {5}.content_{0}_k, Description = {5}.content_{0}_d, DateCreated = new DateTime({y}, {m}, {d}), PostID = {4}, Title = ""{1}"" }," + Environment.NewLine;

            using (XmlReader reader = XmlReader.Create(new StringReader(text)))
            {
                Tag element = Tag.Blogtype;
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        element = (Tag)Enum.Parse(typeof(Tag), reader.Name);
                    }
                    else if(reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
                    {
                        switch (element)
                        {
                            case Tag.Blogtype:
                                switch (reader.Value)
                                {
                                    case "bio":
                                        postdefinition = postdefinition.Replace("{5}", "BlogPostsBiology");
                                        postdefinition = postdefinition.Replace("{6}", "2");
                                        break;
                                    case "prog":
                                        postdefinition = postdefinition.Replace("{5}", "BlogPostsProgramming");
                                        postdefinition = postdefinition.Replace("{6}", "1");
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
                            case Tag.Paragraph:
                                postcontent = postcontent + "<p>" + reader.Value + "</p>";
                                blogger = blogger + "<p>" + reader.Value + "</p>";
                                break;
                            case Tag.Code:
                                string code = reader.Value;
                                string bloggercode = reader.Value;
                                code = "<pre class=\\\"brush:csharp\\\">\" + @\"" +
                                       code.Replace("<", "&lt;").Replace(">", "gt;").Replace("\"", "\"\"") +
                                       "\" + \"</pre>";
                                bloggercode = "<pre class=\"brush:" + reader.GetAttribute(Tag.Lang.ToString()) + "\">" + bloggercode.Replace("<", "&lt;").Replace(">", "gt;") + "</pre>";
                                postcontent = postcontent + code;
                                blogger = blogger + bloggercode;
                                break;
                            case Tag.Image:
                                blogger = blogger + "<img src=" + reader.Value + " alt=\"" + reader.GetAttribute("alt") + "\"/>";
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
