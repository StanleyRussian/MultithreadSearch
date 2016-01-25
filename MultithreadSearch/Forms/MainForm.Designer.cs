namespace MultithreadSearch
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
            this.listViewSearchResults = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchFilename = new System.Windows.Forms.TextBox();
            this.textBoxSearchString = new System.Windows.Forms.TextBox();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.buttonSearchGo = new System.Windows.Forms.Button();
            this.buttonSearchStop = new System.Windows.Forms.Button();
            this.checkBoxSubdirs = new System.Windows.Forms.CheckBox();
            this.labelSearchState = new System.Windows.Forms.Label();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonBigIcons = new System.Windows.Forms.Button();
            this.buttonSmallIcons = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewSearchResults
            // 
            this.listViewSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnPath,
            this.columnSize,
            this.columnDate});
            this.listViewSearchResults.Location = new System.Drawing.Point(12, 80);
            this.listViewSearchResults.Name = "listViewSearchResults";
            this.listViewSearchResults.Size = new System.Drawing.Size(747, 604);
            this.listViewSearchResults.TabIndex = 0;
            this.listViewSearchResults.UseCompatibleStateImageBehavior = false;
            this.listViewSearchResults.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Название";
            // 
            // columnPath
            // 
            this.columnPath.Text = "Путь";
            // 
            // columnSize
            // 
            this.columnSize.Text = "Размер (КБ)";
            this.columnSize.Width = 84;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Дата изменения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Слово или фраза в файле";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Диски";
            // 
            // textBoxSearchFilename
            // 
            this.textBoxSearchFilename.Location = new System.Drawing.Point(12, 25);
            this.textBoxSearchFilename.Name = "textBoxSearchFilename";
            this.textBoxSearchFilename.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchFilename.TabIndex = 4;
            // 
            // textBoxSearchString
            // 
            this.textBoxSearchString.Location = new System.Drawing.Point(118, 25);
            this.textBoxSearchString.Name = "textBoxSearchString";
            this.textBoxSearchString.Size = new System.Drawing.Size(328, 20);
            this.textBoxSearchString.TabIndex = 5;
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Location = new System.Drawing.Point(452, 25);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(63, 21);
            this.comboBoxVolume.TabIndex = 6;
            // 
            // buttonSearchGo
            // 
            this.buttonSearchGo.Location = new System.Drawing.Point(521, 24);
            this.buttonSearchGo.Name = "buttonSearchGo";
            this.buttonSearchGo.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchGo.TabIndex = 7;
            this.buttonSearchGo.Text = "Поиск";
            this.buttonSearchGo.UseVisualStyleBackColor = true;
            this.buttonSearchGo.Click += new System.EventHandler(this.buttonSearchGo_Click);
            // 
            // buttonSearchStop
            // 
            this.buttonSearchStop.Location = new System.Drawing.Point(602, 24);
            this.buttonSearchStop.Name = "buttonSearchStop";
            this.buttonSearchStop.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchStop.TabIndex = 8;
            this.buttonSearchStop.Text = "Стоп";
            this.buttonSearchStop.UseVisualStyleBackColor = true;
            this.buttonSearchStop.Click += new System.EventHandler(this.buttonSearchStop_Click);
            // 
            // checkBoxSubdirs
            // 
            this.checkBoxSubdirs.AutoSize = true;
            this.checkBoxSubdirs.Location = new System.Drawing.Point(683, 27);
            this.checkBoxSubdirs.Name = "checkBoxSubdirs";
            this.checkBoxSubdirs.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSubdirs.TabIndex = 9;
            this.checkBoxSubdirs.Text = "Подпапки";
            this.checkBoxSubdirs.UseVisualStyleBackColor = true;
            // 
            // labelSearchState
            // 
            this.labelSearchState.AutoSize = true;
            this.labelSearchState.Location = new System.Drawing.Point(337, 56);
            this.labelSearchState.Name = "labelSearchState";
            this.labelSearchState.Size = new System.Drawing.Size(109, 13);
            this.labelSearchState.TabIndex = 14;
            this.labelSearchState.Text = "Результаты поиска:";
            this.labelSearchState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDetails
            // 
            this.buttonDetails.Image = global::MultithreadSearch.Properties.Resources.application_list_icon;
            this.buttonDetails.Location = new System.Drawing.Point(74, 51);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(25, 23);
            this.buttonDetails.TabIndex = 12;
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // buttonBigIcons
            // 
            this.buttonBigIcons.Image = global::MultithreadSearch.Properties.Resources.application_icon_large_icon;
            this.buttonBigIcons.Location = new System.Drawing.Point(43, 51);
            this.buttonBigIcons.Name = "buttonBigIcons";
            this.buttonBigIcons.Size = new System.Drawing.Size(25, 23);
            this.buttonBigIcons.TabIndex = 11;
            this.buttonBigIcons.UseVisualStyleBackColor = true;
            this.buttonBigIcons.Click += new System.EventHandler(this.buttonBigIcons_Click);
            // 
            // buttonSmallIcons
            // 
            this.buttonSmallIcons.Image = global::MultithreadSearch.Properties.Resources.application_icon_icon;
            this.buttonSmallIcons.Location = new System.Drawing.Point(12, 51);
            this.buttonSmallIcons.Name = "buttonSmallIcons";
            this.buttonSmallIcons.Size = new System.Drawing.Size(25, 23);
            this.buttonSmallIcons.TabIndex = 10;
            this.buttonSmallIcons.UseVisualStyleBackColor = true;
            this.buttonSmallIcons.Click += new System.EventHandler(this.buttonSmallIcons_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 696);
            this.Controls.Add(this.labelSearchState);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.buttonBigIcons);
            this.Controls.Add(this.buttonSmallIcons);
            this.Controls.Add(this.checkBoxSubdirs);
            this.Controls.Add(this.buttonSearchStop);
            this.Controls.Add(this.buttonSearchGo);
            this.Controls.Add(this.comboBoxVolume);
            this.Controls.Add(this.textBoxSearchString);
            this.Controls.Add(this.textBoxSearchFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewSearchResults);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSearchResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchFilename;
        private System.Windows.Forms.TextBox textBoxSearchString;
        private System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.Button buttonSearchGo;
        private System.Windows.Forms.Button buttonSearchStop;
        private System.Windows.Forms.CheckBox checkBoxSubdirs;
        private System.Windows.Forms.Button buttonSmallIcons;
        private System.Windows.Forms.Button buttonBigIcons;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Label labelSearchState;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnDate;
    }
}

