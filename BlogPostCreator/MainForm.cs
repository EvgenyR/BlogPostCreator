using System;
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

            Helper.StartDoc();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdOpenBlog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Helper.ConvertBlogXmlFile(ofdOpenBlog.FileName);
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
    }
}
