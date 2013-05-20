namespace OranceMapEditor
{
    partial class frmEditor
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
            this.btnBrick = new System.Windows.Forms.Button();
            this.btnMob = new System.Windows.Forms.Button();
            this.btnCharacter = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.cboBricks = new System.Windows.Forms.ComboBox();
            this.cboMobs = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPassable = new System.Windows.Forms.CheckBox();
            this.chkVulnerable = new System.Windows.Forms.CheckBox();
            this.picItemPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrick
            // 
            this.btnBrick.Enabled = false;
            this.btnBrick.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrick.Location = new System.Drawing.Point(13, 12);
            this.btnBrick.Name = "btnBrick";
            this.btnBrick.Size = new System.Drawing.Size(171, 64);
            this.btnBrick.TabIndex = 1;
            this.btnBrick.Text = "Brick";
            this.btnBrick.UseVisualStyleBackColor = true;
            this.btnBrick.Click += new System.EventHandler(this.btnBrick_Click);
            // 
            // btnMob
            // 
            this.btnMob.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMob.Location = new System.Drawing.Point(11, 82);
            this.btnMob.Name = "btnMob";
            this.btnMob.Size = new System.Drawing.Size(171, 64);
            this.btnMob.TabIndex = 3;
            this.btnMob.Text = "Mob";
            this.btnMob.UseVisualStyleBackColor = true;
            this.btnMob.Click += new System.EventHandler(this.btnMob_Click);
            // 
            // btnCharacter
            // 
            this.btnCharacter.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacter.Location = new System.Drawing.Point(13, 152);
            this.btnCharacter.Name = "btnCharacter";
            this.btnCharacter.Size = new System.Drawing.Size(171, 64);
            this.btnCharacter.TabIndex = 4;
            this.btnCharacter.Text = "Player";
            this.btnCharacter.UseVisualStyleBackColor = true;
            this.btnCharacter.Click += new System.EventHandler(this.btnCharacter_Click);
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(189, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(557, 476);
            this.picPreview.TabIndex = 5;
            this.picPreview.TabStop = false;
            this.picPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseDown);
            // 
            // cboBricks
            // 
            this.cboBricks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBricks.FormattingEnabled = true;
            this.cboBricks.Location = new System.Drawing.Point(13, 222);
            this.cboBricks.Name = "cboBricks";
            this.cboBricks.Size = new System.Drawing.Size(171, 21);
            this.cboBricks.TabIndex = 6;
            this.cboBricks.SelectedIndexChanged += new System.EventHandler(this.cboBricks_SelectedIndexChanged);
            // 
            // cboMobs
            // 
            this.cboMobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMobs.FormattingEnabled = true;
            this.cboMobs.Location = new System.Drawing.Point(12, 249);
            this.cboMobs.Name = "cboMobs";
            this.cboMobs.Size = new System.Drawing.Size(171, 21);
            this.cboMobs.TabIndex = 6;
            this.cboMobs.SelectedIndexChanged += new System.EventHandler(this.cboMobs_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chkPassable);
            this.groupBox1.Controls.Add(this.chkVulnerable);
            this.groupBox1.Controls.Add(this.picItemPreview);
            this.groupBox1.Location = new System.Drawing.Point(12, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // chkPassable
            // 
            this.chkPassable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPassable.AutoSize = true;
            this.chkPassable.Location = new System.Drawing.Point(6, 188);
            this.chkPassable.Name = "chkPassable";
            this.chkPassable.Size = new System.Drawing.Size(69, 17);
            this.chkPassable.TabIndex = 1;
            this.chkPassable.Text = "Passable";
            this.chkPassable.UseVisualStyleBackColor = true;
            // 
            // chkVulnerable
            // 
            this.chkVulnerable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVulnerable.AutoSize = true;
            this.chkVulnerable.Location = new System.Drawing.Point(6, 165);
            this.chkVulnerable.Name = "chkVulnerable";
            this.chkVulnerable.Size = new System.Drawing.Size(76, 17);
            this.chkVulnerable.TabIndex = 1;
            this.chkVulnerable.Text = "Vulnerable";
            this.chkVulnerable.UseVisualStyleBackColor = true;
            // 
            // picItemPreview
            // 
            this.picItemPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picItemPreview.Location = new System.Drawing.Point(7, 20);
            this.picItemPreview.Name = "picItemPreview";
            this.picItemPreview.Size = new System.Drawing.Size(158, 139);
            this.picItemPreview.TabIndex = 0;
            this.picItemPreview.TabStop = false;
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboMobs);
            this.Controls.Add(this.cboBricks);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnCharacter);
            this.Controls.Add(this.btnMob);
            this.Controls.Add(this.btnBrick);
            this.MinimumSize = new System.Drawing.Size(774, 538);
            this.Name = "frmEditor";
            this.Text = "Orange Map Editor";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrick;
        private System.Windows.Forms.Button btnMob;
        private System.Windows.Forms.Button btnCharacter;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ComboBox cboBricks;
        private System.Windows.Forms.ComboBox cboMobs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPassable;
        private System.Windows.Forms.CheckBox chkVulnerable;
        private System.Windows.Forms.PictureBox picItemPreview;
    }
}

