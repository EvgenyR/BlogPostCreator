using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace BlogPostCreator
{
    public static class Helper
    {
        public static XmlDocument xmlDoc;

        private const string tagDate = "date";
        private const string tagTitle = "title";
        private const string tagBlogType = "blogtype";
        private const string tagDescription = "description";
        private const string tagKeywords = "keywords";
        private const string tagPostID = "postid";

        public static void StartDoc()
        {
            xmlDoc.LoadXml("<blog></blog>");
        }

        public static void AddImage(string filename, string alttext)
        {
            AddTag("image", filename, new Dictionary<string, string>{{"alt", alttext}});
        }

        public static void AddReference(string url, string desc)
        {
            AddTag("ref", url, new Dictionary<string, string>{{"desc", desc}});
        }

        public static void AddProperties(string title, string description, string keywords, string postID, string blogType, DateTime dateTime)
        {
            AddTag(tagBlogType, blogType);
            AddTag(tagTitle, title);
            AddTag(tagDescription, description);
            AddTag(tagKeywords, keywords);
            AddTag(tagPostID, postID);
            AddTag(tagDate, dateTime.ToString("ddMMyyyy"));
        }

        private static void AddTag(string name, string text, Dictionary<string, string> attributes = null)
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlElement newElement = xmlDoc.CreateElement(name);
            newElement.InnerText = text;

            if(attributes != null)
            {
                foreach (var attributeEntry in attributes.Keys)
                {
                    XmlAttribute attribute = xmlDoc.CreateAttribute(attributeEntry);
                    attribute.Value = attributes[attributeEntry];
                    newElement.Attributes.Append(attribute);
                }
            }
            root.AppendChild(newElement);
        }

        public static void WriteBlogXmlFile(string filename)
        {
            File.WriteAllText(filename, xmlDoc.InnerXml);
        }

        public static void ConvertBlogXmlFile(string filename)
        {
            try
            {
                string text = File.ReadAllText(filename);
                string blog = ConvertToBlogger(text);
                string site = ConvertToWebSite(text);

                File.WriteAllText(filename + "_site", site);
            }
            catch (Exception ex)
            {

            }
        }

        private static string ConvertToWebSite(string text)
        {
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
            string brief = @"";
            string rest = @"";
            string description = @"";
            string keywords = @"";

            string postdefinition = @"new Post { BlogID = {6}, BriefContent = {5}.content_{0}_b, RestOfContent = {5}.content_{0}_r, Keywords = {5}.content_{0}_k, Description = {5}.content_{0}_d, DateCreated = new DateTime({y}, {m}, {d}), PostID = {4}, Title = ""{1}"" }," + Environment.NewLine;

            using (XmlReader reader = XmlReader.Create(new StringReader(text)))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case tagBlogType:
                                switch (reader.ReadInnerXml())
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
                            case tagTitle:
                                postdefinition = postdefinition.Replace("{1}", reader.ReadInnerXml());
                                break;
                            case tagDescription:

                                break;
                            case tagKeywords:

                                break;
                            case tagPostID:
                                postdefinition = postdefinition.Replace("{4}", reader.ReadInnerXml());
                                break;
                            case tagDate:
                                string date = reader.ReadInnerXml();
                                postdefinition = postdefinition.Replace("{y}", date.Substring(4, 4));
                                postdefinition = postdefinition.Replace("{d}", date.Substring(0, 2));
                                postdefinition = postdefinition.Replace("{m}", date.Substring(2, 2));
                                postdefinition = postdefinition.Replace("{0}", date);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return postdefinition + brief + rest + description + keywords;
        }


        private static string ConvertToBlogger(string text)
        {
            string result = string.Empty;
            using (XmlReader reader = XmlReader.Create(new StringReader(text)))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "para":
                                result = result + "<p>" + reader.ReadInnerXml() + "</p>";
                                break;
                            case "image":
                                string alt = reader.GetAttribute("alt");
                                result = result + "<img src=" + reader.ReadInnerXml() + " alt=\"" + alt + "\"/>";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
