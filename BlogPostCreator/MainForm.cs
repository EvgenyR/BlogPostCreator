using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlogPostCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Helper.StartDoc();
            Helper.XmlUpdated += (sender, args) => UpdatePreview();
        }

        private void UpdatePreview()
        {
            txtPreview.Text = Helper.xmlDoc.InnerXml;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdOpenBlog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Helper.ConvertToBlogContents(ofdOpenBlog.FileName);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            Helper.AddImage(txtImageDate.Text, txtImageDesc.Text);
        }

        private void btnAddRef_Click(object sender, EventArgs e)
        {
            Helper.AddReference(txtRefUrl.Text, txtRefText.Text);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            DialogResult result = sfdSaveBlog.ShowDialog();
            if(result == DialogResult.OK)
            {
                Helper.WriteBlogXmlFile(sfdSaveBlog.FileName);
            }
        }

        private void btnAddProperties_Click(object sender, EventArgs e)
        {
            Helper.AddProperties(txtTitle.Text, txtDescription.Text, txtKeywords.Text, txtPostID.Text, cmbBlogType.SelectedItem.ToString(), dtDate.Value);
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            Tag paragraphType = (Tag) Enum.Parse(typeof (Tag), cmbParagraphs.SelectedItem.ToString());
            Helper.AddText(txtText.Text, new Dictionary<Tag, Tag>{{BlogPostCreator.Tag.Format, paragraphType}});
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            Tag langName = (Tag)Enum.Parse(typeof(Tag), cmbLang.SelectedItem.ToString());
            Helper.AddCode(txtCode.Text, new Dictionary<Tag, Tag>{{BlogPostCreator.Tag.Lang, langName}});
        }
    }
}
