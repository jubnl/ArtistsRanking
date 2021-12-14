namespace ArtistsRanking.Views
{
    partial class frmArtist
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewArtist = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddArtist = new System.Windows.Forms.Button();
            this.buttonEditArtist = new System.Windows.Forms.Button();
            this.buttonDeleteArtist = new System.Windows.Forms.Button();
            this.labelIdArtist = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArtistName = new System.Windows.Forms.TextBox();
            this.comboBoxArtistStyle = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewVote = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddVote = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxVoteArtist = new System.Windows.Forms.ComboBox();
            this.numericUpDownRank = new System.Windows.Forms.NumericUpDown();
            this.textBoxLname = new System.Windows.Forms.TextBox();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtist)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVote)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRank)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewArtist, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridViewArtist
            // 
            this.dataGridViewArtist.AllowUserToAddRows = false;
            this.dataGridViewArtist.AllowUserToDeleteRows = false;
            this.dataGridViewArtist.AllowUserToOrderColumns = true;
            this.dataGridViewArtist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArtist.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewArtist.MultiSelect = false;
            this.dataGridViewArtist.Name = "dataGridViewArtist";
            this.dataGridViewArtist.ReadOnly = true;
            this.dataGridViewArtist.Size = new System.Drawing.Size(388, 142);
            this.dataGridViewArtist.TabIndex = 0;
            this.dataGridViewArtist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnClickChangeIndex);
            this.dataGridViewArtist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickChangeIndex);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonAddArtist);
            this.flowLayoutPanel1.Controls.Add(this.buttonEditArtist);
            this.flowLayoutPanel1.Controls.Add(this.buttonDeleteArtist);
            this.flowLayoutPanel1.Controls.Add(this.labelIdArtist);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 299);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(388, 142);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonAddArtist
            // 
            this.buttonAddArtist.AutoSize = true;
            this.buttonAddArtist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddArtist.Location = new System.Drawing.Point(3, 3);
            this.buttonAddArtist.Name = "buttonAddArtist";
            this.buttonAddArtist.Size = new System.Drawing.Size(36, 23);
            this.buttonAddArtist.TabIndex = 0;
            this.buttonAddArtist.Text = "Add";
            this.buttonAddArtist.UseVisualStyleBackColor = true;
            this.buttonAddArtist.Click += new System.EventHandler(this.OnClickAddArtist);
            // 
            // buttonEditArtist
            // 
            this.buttonEditArtist.AutoSize = true;
            this.buttonEditArtist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEditArtist.Location = new System.Drawing.Point(45, 3);
            this.buttonEditArtist.Name = "buttonEditArtist";
            this.buttonEditArtist.Size = new System.Drawing.Size(35, 23);
            this.buttonEditArtist.TabIndex = 1;
            this.buttonEditArtist.Text = "Edit";
            this.buttonEditArtist.UseVisualStyleBackColor = true;
            this.buttonEditArtist.Click += new System.EventHandler(this.OnClickEditArtist);
            // 
            // buttonDeleteArtist
            // 
            this.buttonDeleteArtist.AutoSize = true;
            this.buttonDeleteArtist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDeleteArtist.Location = new System.Drawing.Point(86, 3);
            this.buttonDeleteArtist.Name = "buttonDeleteArtist";
            this.buttonDeleteArtist.Size = new System.Drawing.Size(48, 23);
            this.buttonDeleteArtist.TabIndex = 2;
            this.buttonDeleteArtist.Text = "Delete";
            this.buttonDeleteArtist.UseVisualStyleBackColor = true;
            this.buttonDeleteArtist.Click += new System.EventHandler(this.OnClickDeleteArtist);
            // 
            // labelIdArtist
            // 
            this.labelIdArtist.AutoSize = true;
            this.labelIdArtist.Location = new System.Drawing.Point(140, 0);
            this.labelIdArtist.Name = "labelIdArtist";
            this.labelIdArtist.Size = new System.Drawing.Size(13, 13);
            this.labelIdArtist.TabIndex = 3;
            this.labelIdArtist.Text = "0";
            this.labelIdArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIdArtist.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxArtistName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxArtistStyle, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 151);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(388, 142);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 71);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist Style :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArtistName
            // 
            this.textBoxArtistName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxArtistName.Location = new System.Drawing.Point(197, 25);
            this.textBoxArtistName.Name = "textBoxArtistName";
            this.textBoxArtistName.Size = new System.Drawing.Size(188, 20);
            this.textBoxArtistName.TabIndex = 2;
            // 
            // comboBoxArtistStyle
            // 
            this.comboBoxArtistStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxArtistStyle.FormattingEnabled = true;
            this.comboBoxArtistStyle.Location = new System.Drawing.Point(197, 96);
            this.comboBoxArtistStyle.Name = "comboBoxArtistStyle";
            this.comboBoxArtistStyle.Size = new System.Drawing.Size(188, 21);
            this.comboBoxArtistStyle.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewVote, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(403, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(394, 444);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataGridViewVote
            // 
            this.dataGridViewVote.AllowUserToAddRows = false;
            this.dataGridViewVote.AllowUserToDeleteRows = false;
            this.dataGridViewVote.AllowUserToOrderColumns = true;
            this.dataGridViewVote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVote.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewVote.MultiSelect = false;
            this.dataGridViewVote.Name = "dataGridViewVote";
            this.dataGridViewVote.ReadOnly = true;
            this.dataGridViewVote.Size = new System.Drawing.Size(388, 142);
            this.dataGridViewVote.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonAddVote);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 299);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(388, 142);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // buttonAddVote
            // 
            this.buttonAddVote.AutoSize = true;
            this.buttonAddVote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddVote.Location = new System.Drawing.Point(3, 3);
            this.buttonAddVote.Name = "buttonAddVote";
            this.buttonAddVote.Size = new System.Drawing.Size(36, 23);
            this.buttonAddVote.TabIndex = 0;
            this.buttonAddVote.Text = "Add";
            this.buttonAddVote.UseVisualStyleBackColor = true;
            this.buttonAddVote.Click += new System.EventHandler(this.OnClickAddVote);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.comboBoxVoteArtist, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDownRank, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.textBoxLname, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBoxFname, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 151);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(388, 142);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // comboBoxVoteArtist
            // 
            this.comboBoxVoteArtist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxVoteArtist.FormattingEnabled = true;
            this.comboBoxVoteArtist.Location = new System.Drawing.Point(197, 113);
            this.comboBoxVoteArtist.Name = "comboBoxVoteArtist";
            this.comboBoxVoteArtist.Size = new System.Drawing.Size(188, 21);
            this.comboBoxVoteArtist.TabIndex = 0;
            // 
            // numericUpDownRank
            // 
            this.numericUpDownRank.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownRank.Location = new System.Drawing.Point(197, 77);
            this.numericUpDownRank.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            this.numericUpDownRank.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownRank.Name = "numericUpDownRank";
            this.numericUpDownRank.Size = new System.Drawing.Size(188, 20);
            this.numericUpDownRank.TabIndex = 1;
            this.numericUpDownRank.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // textBoxLname
            // 
            this.textBoxLname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLname.Location = new System.Drawing.Point(197, 42);
            this.textBoxLname.Name = "textBoxLname";
            this.textBoxLname.Size = new System.Drawing.Size(188, 20);
            this.textBoxLname.TabIndex = 2;
            // 
            // textBoxFname
            // 
            this.textBoxFname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFname.Location = new System.Drawing.Point(197, 7);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.Size = new System.Drawing.Size(188, 20);
            this.textBoxFname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "First name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 35);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last name :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 35);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rank :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 37);
            this.label6.TabIndex = 7;
            this.label6.Text = "Artist :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmArtist";
            this.Text = "frmArtist";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtist)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVote)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRank)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.TextBox textBoxFname;

        private System.Windows.Forms.TextBox textBoxLname;

        private System.Windows.Forms.NumericUpDown numericUpDownRank;

        private System.Windows.Forms.ComboBox comboBoxVoteArtist;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

        private System.Windows.Forms.ComboBox comboBoxArtistStyle;

        private System.Windows.Forms.TextBox textBoxArtistName;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label labelIdArtist;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

        private System.Windows.Forms.Button buttonAddVote;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

        private System.Windows.Forms.Button buttonDeleteArtist;

        private System.Windows.Forms.Button buttonAddArtist;
        private System.Windows.Forms.Button buttonEditArtist;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.DataGridView dataGridViewVote;

        private System.Windows.Forms.DataGridView dataGridViewArtist;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}