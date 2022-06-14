namespace AT2_BetterWikiApp
{
    partial class ViewDefinition
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_ItemName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_ItemType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_ItemDefinition = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radiobx_nonLinearSubtype = new System.Windows.Forms.RadioButton();
            this.radiobx_linearSubtype = new System.Windows.Forms.RadioButton();
            this.btn_SaveOrEdit = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txt_ItemName);
            this.groupBox5.Location = new System.Drawing.Point(9, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(479, 49);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Item Name";
            // 
            // txt_ItemName
            // 
            this.txt_ItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ItemName.Location = new System.Drawing.Point(6, 21);
            this.txt_ItemName.Name = "txt_ItemName";
            this.txt_ItemName.Size = new System.Drawing.Size(467, 20);
            this.txt_ItemName.TabIndex = 2;
            this.txt_ItemName.DoubleClick += new System.EventHandler(this.txt_ItemName_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txt_ItemType);
            this.groupBox4.Location = new System.Drawing.Point(9, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(479, 49);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Category";
            // 
            // txt_ItemType
            // 
            this.txt_ItemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ItemType.FormattingEnabled = true;
            this.txt_ItemType.Items.AddRange(new object[] {
            "Abstract",
            "Array",
            "Graphs",
            "Hash",
            "List",
            "Tree"});
            this.txt_ItemType.Location = new System.Drawing.Point(6, 19);
            this.txt_ItemType.Name = "txt_ItemType";
            this.txt_ItemType.Size = new System.Drawing.Size(467, 21);
            this.txt_ItemType.Sorted = true;
            this.txt_ItemType.TabIndex = 4;
            this.txt_ItemType.Text = "Array";
            this.txt_ItemType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txt_ItemType_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txt_ItemDefinition);
            this.groupBox3.Location = new System.Drawing.Point(9, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 148);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Definitons";
            // 
            // txt_ItemDefinition
            // 
            this.txt_ItemDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ItemDefinition.Location = new System.Drawing.Point(6, 19);
            this.txt_ItemDefinition.Multiline = true;
            this.txt_ItemDefinition.Name = "txt_ItemDefinition";
            this.txt_ItemDefinition.Size = new System.Drawing.Size(467, 123);
            this.txt_ItemDefinition.TabIndex = 9;
            this.txt_ItemDefinition.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txt_ItemDefinition_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radiobx_nonLinearSubtype);
            this.groupBox2.Controls.Add(this.radiobx_linearSubtype);
            this.groupBox2.Location = new System.Drawing.Point(9, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 49);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subtype";
            // 
            // radiobx_nonLinearSubtype
            // 
            this.radiobx_nonLinearSubtype.AutoSize = true;
            this.radiobx_nonLinearSubtype.Location = new System.Drawing.Point(69, 19);
            this.radiobx_nonLinearSubtype.Name = "radiobx_nonLinearSubtype";
            this.radiobx_nonLinearSubtype.Size = new System.Drawing.Size(77, 17);
            this.radiobx_nonLinearSubtype.TabIndex = 7;
            this.radiobx_nonLinearSubtype.Text = "Non-Linear";
            this.radiobx_nonLinearSubtype.UseVisualStyleBackColor = true;
            this.radiobx_nonLinearSubtype.CheckedChanged += new System.EventHandler(this.radiobx_nonLinearSubtype_CheckedChanged);
            // 
            // radiobx_linearSubtype
            // 
            this.radiobx_linearSubtype.AutoSize = true;
            this.radiobx_linearSubtype.Checked = true;
            this.radiobx_linearSubtype.Location = new System.Drawing.Point(6, 19);
            this.radiobx_linearSubtype.Name = "radiobx_linearSubtype";
            this.radiobx_linearSubtype.Size = new System.Drawing.Size(57, 17);
            this.radiobx_linearSubtype.TabIndex = 6;
            this.radiobx_linearSubtype.TabStop = true;
            this.radiobx_linearSubtype.Text = "Linear ";
            this.radiobx_linearSubtype.UseVisualStyleBackColor = true;
            this.radiobx_linearSubtype.CheckedChanged += new System.EventHandler(this.radiobx_linearSubtype_CheckedChanged);
            // 
            // btn_SaveOrEdit
            // 
            this.btn_SaveOrEdit.Location = new System.Drawing.Point(3, 3);
            this.btn_SaveOrEdit.Name = "btn_SaveOrEdit";
            this.btn_SaveOrEdit.Size = new System.Drawing.Size(114, 23);
            this.btn_SaveOrEdit.TabIndex = 10;
            this.btn_SaveOrEdit.Text = "Edit Definition";
            this.btn_SaveOrEdit.UseVisualStyleBackColor = true;
            this.btn_SaveOrEdit.Click += new System.EventHandler(this.btn_SaveOrEdit_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(383, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(114, 23);
            this.btn_close.TabIndex = 12;
            this.btn_close.Text = "Close Tab";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.Enabled = false;
            this.btn_delete.Location = new System.Drawing.Point(263, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(114, 23);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(123, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(114, 23);
            this.btn_clear.TabIndex = 13;
            this.btn_clear.Text = "Clear All";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Visible = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // ViewDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_SaveOrEdit);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(500, 370);
            this.Name = "ViewDefinition";
            this.Size = new System.Drawing.Size(500, 370);
            this.Load += new System.EventHandler(this.ViewDefinition_Load);
            this.TabIndexChanged += new System.EventHandler(this.ViewDefinition_TabIndexChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ItemName;
        private System.Windows.Forms.Button btn_SaveOrEdit;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_ItemDefinition;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox txt_ItemType;
        private System.Windows.Forms.RadioButton radiobx_nonLinearSubtype;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radiobx_linearSubtype;
        private System.Windows.Forms.Button btn_clear;
    }
}
