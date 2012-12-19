namespace BlogPostCreator
{
    partial class MainForm
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
            this.ofdOpenBlog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.cmbBlogType = new System.Windows.Forms.ComboBox();
            this.lblBlogType = new System.Windows.Forms.Label();
            this.txtPostID = new System.Windows.Forms.TextBox();
            this.lblPostID = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddProperties = new System.Windows.Forms.Button();
            this.tpCompose = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.cmbParagraphs = new System.Windows.Forms.ComboBox();
            this.btnAddText = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtRefUrl = new System.Windows.Forms.TextBox();
            this.txtRefText = new System.Windows.Forms.TextBox();
            this.btnAddRef = new System.Windows.Forms.Button();
            this.txtImageDate = new System.Windows.Forms.TextBox();
            this.txtImageDesc = new System.Windows.Forms.TextBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.tpPreview = new System.Windows.Forms.TabPage();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.sfdSaveBlog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpCompose.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdOpenBlog
            // 
            this.ofdOpenBlog.FileName = "Blog";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(97, 298);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(83, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Convert File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Controls.Add(this.tpCompose);
            this.tabControl1.Controls.Add(this.tpPreview);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(526, 280);
            this.tabControl1.TabIndex = 1;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.cmbBlogType);
            this.tpGeneral.Controls.Add(this.lblBlogType);
            this.tpGeneral.Controls.Add(this.txtPostID);
            this.tpGeneral.Controls.Add(this.lblPostID);
            this.tpGeneral.Controls.Add(this.dtDate);
            this.tpGeneral.Controls.Add(this.lblDate);
            this.tpGeneral.Controls.Add(this.txtKeywords);
            this.tpGeneral.Controls.Add(this.lblKeywords);
            this.tpGeneral.Controls.Add(this.txtDescription);
            this.tpGeneral.Controls.Add(this.lblDescription);
            this.tpGeneral.Controls.Add(this.txtTitle);
            this.tpGeneral.Controls.Add(this.lblTitle);
            this.tpGeneral.Controls.Add(this.btnAddProperties);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(518, 254);
            this.tpGeneral.TabIndex = 2;
            this.tpGeneral.Text = "Properties";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // cmbBlogType
            // 
            this.cmbBlogType.FormattingEnabled = true;
            this.cmbBlogType.Items.AddRange(new object[] {
            "bio",
            "prog"});
            this.cmbBlogType.Location = new System.Drawing.Point(129, 10);
            this.cmbBlogType.Name = "cmbBlogType";
            this.cmbBlogType.Size = new System.Drawing.Size(121, 21);
            this.cmbBlogType.TabIndex = 12;
            // 
            // lblBlogType
            // 
            this.lblBlogType.AutoSize = true;
            this.lblBlogType.Location = new System.Drawing.Point(17, 16);
            this.lblBlogType.Name = "lblBlogType";
            this.lblBlogType.Size = new System.Drawing.Size(31, 13);
            this.lblBlogType.TabIndex = 11;
            this.lblBlogType.Text = "Type";
            // 
            // txtPostID
            // 
            this.txtPostID.Location = new System.Drawing.Point(129, 144);
            this.txtPostID.Name = "txtPostID";
            this.txtPostID.Size = new System.Drawing.Size(278, 20);
            this.txtPostID.TabIndex = 10;
            // 
            // lblPostID
            // 
            this.lblPostID.AutoSize = true;
            this.lblPostID.Location = new System.Drawing.Point(17, 147);
            this.lblPostID.Name = "lblPostID";
            this.lblPostID.Size = new System.Drawing.Size(42, 13);
            this.lblPostID.TabIndex = 9;
            this.lblPostID.Text = "Post ID";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(129, 118);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(17, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "label4";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(129, 89);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(278, 20);
            this.txtKeywords.TabIndex = 6;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(17, 92);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(53, 13);
            this.lblKeywords.TabIndex = 5;
            this.lblKeywords.Text = "Keywords";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(129, 63);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(278, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(17, 66);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(129, 37);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(278, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(17, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // btnAddProperties
            // 
            this.btnAddProperties.Location = new System.Drawing.Point(6, 225);
            this.btnAddProperties.Name = "btnAddProperties";
            this.btnAddProperties.Size = new System.Drawing.Size(101, 23);
            this.btnAddProperties.TabIndex = 0;
            this.btnAddProperties.Text = "Add Properties";
            this.btnAddProperties.UseVisualStyleBackColor = true;
            this.btnAddProperties.Click += new System.EventHandler(this.btnAddProperties_Click);
            // 
            // tpCompose
            // 
            this.tpCompose.Controls.Add(this.txtCode);
            this.tpCompose.Controls.Add(this.cmbLang);
            this.tpCompose.Controls.Add(this.btnAddCode);
            this.tpCompose.Controls.Add(this.cmbParagraphs);
            this.tpCompose.Controls.Add(this.btnAddText);
            this.tpCompose.Controls.Add(this.txtText);
            this.tpCompose.Controls.Add(this.txtRefUrl);
            this.tpCompose.Controls.Add(this.txtRefText);
            this.tpCompose.Controls.Add(this.btnAddRef);
            this.tpCompose.Controls.Add(this.txtImageDate);
            this.tpCompose.Controls.Add(this.txtImageDesc);
            this.tpCompose.Controls.Add(this.btnImage);
            this.tpCompose.Location = new System.Drawing.Point(4, 22);
            this.tpCompose.Name = "tpCompose";
            this.tpCompose.Padding = new System.Windows.Forms.Padding(3);
            this.tpCompose.Size = new System.Drawing.Size(518, 254);
            this.tpCompose.TabIndex = 0;
            this.tpCompose.Text = "Compose";
            this.tpCompose.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(148, 82);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(201, 128);
            this.txtCode.TabIndex = 24;
            this.txtCode.Text = "";
            // 
            // cmbLang
            // 
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Items.AddRange(new object[] {
            "csharp",
            "xml",
            "jscript"});
            this.cmbLang.Location = new System.Drawing.Point(6, 85);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(136, 21);
            this.cmbLang.TabIndex = 23;
            // 
            // btnAddCode
            // 
            this.btnAddCode.Location = new System.Drawing.Point(355, 80);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddCode.TabIndex = 22;
            this.btnAddCode.Text = "Add Code";
            this.btnAddCode.UseVisualStyleBackColor = true;
            this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
            // 
            // cmbParagraphs
            // 
            this.cmbParagraphs.FormattingEnabled = true;
            this.cmbParagraphs.Items.AddRange(new object[] {
            "p",
            "p,b",
            "b"});
            this.cmbParagraphs.Location = new System.Drawing.Point(6, 58);
            this.cmbParagraphs.Name = "cmbParagraphs";
            this.cmbParagraphs.Size = new System.Drawing.Size(136, 21);
            this.cmbParagraphs.TabIndex = 21;
            // 
            // btnAddText
            // 
            this.btnAddText.Location = new System.Drawing.Point(355, 56);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(75, 23);
            this.btnAddText.TabIndex = 20;
            this.btnAddText.Text = "Add Text";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(148, 56);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(201, 20);
            this.txtText.TabIndex = 19;
            // 
            // txtRefUrl
            // 
            this.txtRefUrl.Location = new System.Drawing.Point(6, 32);
            this.txtRefUrl.Name = "txtRefUrl";
            this.txtRefUrl.Size = new System.Drawing.Size(136, 20);
            this.txtRefUrl.TabIndex = 18;
            // 
            // txtRefText
            // 
            this.txtRefText.Location = new System.Drawing.Point(148, 30);
            this.txtRefText.Name = "txtRefText";
            this.txtRefText.Size = new System.Drawing.Size(201, 20);
            this.txtRefText.TabIndex = 17;
            // 
            // btnAddRef
            // 
            this.btnAddRef.Location = new System.Drawing.Point(355, 30);
            this.btnAddRef.Name = "btnAddRef";
            this.btnAddRef.Size = new System.Drawing.Size(75, 23);
            this.btnAddRef.TabIndex = 16;
            this.btnAddRef.Text = "Add Ref";
            this.btnAddRef.UseVisualStyleBackColor = true;
            this.btnAddRef.Click += new System.EventHandler(this.btnAddRef_Click);
            // 
            // txtImageDate
            // 
            this.txtImageDate.Location = new System.Drawing.Point(6, 6);
            this.txtImageDate.Name = "txtImageDate";
            this.txtImageDate.Size = new System.Drawing.Size(136, 20);
            this.txtImageDate.TabIndex = 15;
            // 
            // txtImageDesc
            // 
            this.txtImageDesc.Location = new System.Drawing.Point(148, 6);
            this.txtImageDesc.Name = "txtImageDesc";
            this.txtImageDesc.Size = new System.Drawing.Size(201, 20);
            this.txtImageDesc.TabIndex = 14;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(355, 4);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 13;
            this.btnImage.Text = "Add Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // tpPreview
            // 
            this.tpPreview.Location = new System.Drawing.Point(4, 22);
            this.tpPreview.Name = "tpPreview";
            this.tpPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreview.Size = new System.Drawing.Size(518, 254);
            this.tpPreview.TabIndex = 1;
            this.tpPreview.Text = "Preview";
            this.tpPreview.UseVisualStyleBackColor = true;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(16, 298);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 2;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 333);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpCompose.ResumeLayout(false);
            this.tpCompose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdOpenBlog;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCompose;
        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.ComboBox cmbParagraphs;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtRefUrl;
        private System.Windows.Forms.TextBox txtRefText;
        private System.Windows.Forms.Button btnAddRef;
        private System.Windows.Forms.TextBox txtImageDate;
        private System.Windows.Forms.TextBox txtImageDesc;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TabPage tpPreview;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.SaveFileDialog sfdSaveBlog;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddProperties;
        private System.Windows.Forms.TextBox txtPostID;
        private System.Windows.Forms.Label lblPostID;
        private System.Windows.Forms.ComboBox cmbBlogType;
        private System.Windows.Forms.Label lblBlogType;
    }
}

