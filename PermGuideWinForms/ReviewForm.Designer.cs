namespace PermGuideWinForms
{
    partial class ReviewForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FstStar = new System.Windows.Forms.Label();
            this.SndStar = new System.Windows.Forms.Label();
            this.TrdStar = new System.Windows.Forms.Label();
            this.FrtStar = new System.Windows.Forms.Label();
            this.FthStar = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.RejectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ContentTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.FstStar);
            this.flowLayoutPanel1.Controls.Add(this.SndStar);
            this.flowLayoutPanel1.Controls.Add(this.TrdStar);
            this.flowLayoutPanel1.Controls.Add(this.FrtStar);
            this.flowLayoutPanel1.Controls.Add(this.FthStar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 72);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // FstStar
            // 
            this.FstStar.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.FstStar.ForeColor = System.Drawing.Color.DimGray;
            this.FstStar.Location = new System.Drawing.Point(3, 0);
            this.FstStar.Name = "FstStar";
            this.FstStar.Size = new System.Drawing.Size(84, 72);
            this.FstStar.TabIndex = 0;
            this.FstStar.Tag = "1";
            this.FstStar.Text = "«";
            this.FstStar.Click += new System.EventHandler(this.FstStar_Click);
            // 
            // SndStar
            // 
            this.SndStar.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SndStar.ForeColor = System.Drawing.Color.DimGray;
            this.SndStar.Location = new System.Drawing.Point(93, 0);
            this.SndStar.Name = "SndStar";
            this.SndStar.Size = new System.Drawing.Size(84, 72);
            this.SndStar.TabIndex = 1;
            this.SndStar.Tag = "2";
            this.SndStar.Text = "«";
            this.SndStar.Click += new System.EventHandler(this.FstStar_Click);
            // 
            // TrdStar
            // 
            this.TrdStar.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.TrdStar.ForeColor = System.Drawing.Color.DimGray;
            this.TrdStar.Location = new System.Drawing.Point(183, 0);
            this.TrdStar.Name = "TrdStar";
            this.TrdStar.Size = new System.Drawing.Size(84, 72);
            this.TrdStar.TabIndex = 2;
            this.TrdStar.Tag = "3";
            this.TrdStar.Text = "«";
            this.TrdStar.Click += new System.EventHandler(this.FstStar_Click);
            // 
            // FrtStar
            // 
            this.FrtStar.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.FrtStar.ForeColor = System.Drawing.Color.DimGray;
            this.FrtStar.Location = new System.Drawing.Point(273, 0);
            this.FrtStar.Name = "FrtStar";
            this.FrtStar.Size = new System.Drawing.Size(84, 72);
            this.FrtStar.TabIndex = 3;
            this.FrtStar.Tag = "4";
            this.FrtStar.Text = "«";
            this.FrtStar.Click += new System.EventHandler(this.FstStar_Click);
            // 
            // FthStar
            // 
            this.FthStar.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.FthStar.ForeColor = System.Drawing.Color.DimGray;
            this.FthStar.Location = new System.Drawing.Point(363, 0);
            this.FthStar.Name = "FthStar";
            this.FthStar.Size = new System.Drawing.Size(84, 72);
            this.FthStar.TabIndex = 4;
            this.FthStar.Tag = "5";
            this.FthStar.Text = "«";
            this.FthStar.Click += new System.EventHandler(this.FstStar_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(208, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "label1";
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentTextBox.Location = new System.Drawing.Point(3, 94);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(451, 360);
            this.ContentTextBox.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.AcceptButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RejectButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 460);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(451, 29);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AcceptButton.Enabled = false;
            this.AcceptButton.Location = new System.Drawing.Point(3, 3);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(219, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "Отправить";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // RejectButton
            // 
            this.RejectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RejectButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RejectButton.Location = new System.Drawing.Point(228, 3);
            this.RejectButton.Name = "RejectButton";
            this.RejectButton.Size = new System.Drawing.Size(220, 23);
            this.RejectButton.TabIndex = 1;
            this.RejectButton.Text = "Отмена";
            this.RejectButton.UseVisualStyleBackColor = true;
            this.RejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RejectButton;
            this.ClientSize = new System.Drawing.Size(457, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оставить отзыв";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label FstStar;
        private System.Windows.Forms.Label SndStar;
        private System.Windows.Forms.Label TrdStar;
        private System.Windows.Forms.Label FrtStar;
        private System.Windows.Forms.Label FthStar;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button RejectButton;
    }
}