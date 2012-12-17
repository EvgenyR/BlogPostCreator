using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace BlogPostCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdOpenBlog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = ofdOpenBlog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    string blog = ConvertToBlogger(text);
                }
                catch (Exception ex)
                { 
                
                }
            }
        }

        private string ConvertToBlogger(string text)
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
