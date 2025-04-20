namespace DM2GM
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnConvert;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnConvert = new Button();
            txtMMap = new TextBox();
            btnImportMMap = new Button();
            btnImportDM = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(20, 29);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "请输入DeluxeMenus菜单文件的全部内容";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(400, 163);
            txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(20, 215);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.PlaceholderText = "转换后的GeyserMenu菜单（可直接整个复制到文件内）";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(400, 169);
            txtOutput.TabIndex = 1;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(440, 23);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(100, 53);
            btnConvert.TabIndex = 2;
            btnConvert.Text = "转换";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // txtMMap
            // 
            txtMMap.Location = new Point(433, 140);
            txtMMap.Multiline = true;
            txtMMap.Name = "txtMMap";
            txtMMap.PlaceholderText = "请输入材质映射表";
            txtMMap.ScrollBars = ScrollBars.Vertical;
            txtMMap.Size = new Size(115, 244);
            txtMMap.TabIndex = 3;
            // 
            // btnImportMMap
            // 
            btnImportMMap.Location = new Point(433, 111);
            btnImportMMap.Name = "btnImportMMap";
            btnImportMMap.Size = new Size(115, 23);
            btnImportMMap.TabIndex = 4;
            btnImportMMap.Text = "通过文件导入映射";
            btnImportMMap.UseVisualStyleBackColor = true;
            btnImportMMap.Click += btnImportMMap_Click;
            // 
            // btnImportDM
            // 
            btnImportDM.Font = new Font("Microsoft YaHei UI", 7F);
            btnImportDM.Location = new Point(433, 82);
            btnImportDM.Name = "btnImportDM";
            btnImportDM.Size = new Size(115, 23);
            btnImportDM.TabIndex = 5;
            btnImportDM.Text = "通过文件导入DM菜单";
            btnImportDM.UseVisualStyleBackColor = true;
            btnImportDM.Click += btnImportDM_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(220, 17);
            label1.TabIndex = 6;
            label1.Text = "(导入文件的方法可能会乱，不影响功能)";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 408);
            Controls.Add(label1);
            Controls.Add(btnImportDM);
            Controls.Add(btnImportMMap);
            Controls.Add(txtMMap);
            Controls.Add(txtInput);
            Controls.Add(txtOutput);
            Controls.Add(btnConvert);
            Name = "FrmMain";
            Text = "DM2GM转换器";
            ResumeLayout(false);
            PerformLayout();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        #endregion

        private TextBox txtMMap;
        private Button btnImportMMap;
        private Button btnImportDM;
        private Label label1;
    }
}
