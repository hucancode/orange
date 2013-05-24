namespace MobEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor));
            this.picIdle = new System.Windows.Forms.PictureBox();
            this.picSheet = new System.Windows.Forms.PictureBox();
            this.picMove = new System.Windows.Forms.PictureBox();
            this.picBirth = new System.Windows.Forms.PictureBox();
            this.picDie = new System.Windows.Forms.PictureBox();
            this.numIdleBegin = new System.Windows.Forms.NumericUpDown();
            this.numIdleEnd = new System.Windows.Forms.NumericUpDown();
            this.numMoveBegin = new System.Windows.Forms.NumericUpDown();
            this.numMoveEnd = new System.Windows.Forms.NumericUpDown();
            this.numBirthBegin = new System.Windows.Forms.NumericUpDown();
            this.numBirthEnd = new System.Windows.Forms.NumericUpDown();
            this.numDieBegin = new System.Windows.Forms.NumericUpDown();
            this.numDieEnd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numDivX = new System.Windows.Forms.NumericUpDown();
            this.numDivY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtTexturePath = new System.Windows.Forms.TextBox();
            this.numOffX = new System.Windows.Forms.NumericUpDown();
            this.numOffY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPassable = new System.Windows.Forms.CheckBox();
            this.chkVulnerable = new System.Windows.Forms.CheckBox();
            this.cboMobBrick = new System.Windows.Forms.ComboBox();
            this.tmrUpdateAnimation = new System.Windows.Forms.Timer(this.components);
            this.dlgOpenPNG = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveXML = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenXML = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picIdle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivY)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffY)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picIdle
            // 
            this.picIdle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picIdle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIdle.Location = new System.Drawing.Point(212, 333);
            this.picIdle.Name = "picIdle";
            this.picIdle.Size = new System.Drawing.Size(96, 96);
            this.picIdle.TabIndex = 0;
            this.picIdle.TabStop = false;
            this.picIdle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picIdle_MouseDown);
            // 
            // picSheet
            // 
            this.picSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSheet.Location = new System.Drawing.Point(212, 28);
            this.picSheet.Name = "picSheet";
            this.picSheet.Size = new System.Drawing.Size(400, 300);
            this.picSheet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSheet.TabIndex = 1;
            this.picSheet.TabStop = false;
            // 
            // picMove
            // 
            this.picMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMove.Location = new System.Drawing.Point(314, 333);
            this.picMove.Name = "picMove";
            this.picMove.Size = new System.Drawing.Size(96, 96);
            this.picMove.TabIndex = 0;
            this.picMove.TabStop = false;
            this.picMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMove_MouseDown);
            // 
            // picBirth
            // 
            this.picBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBirth.Location = new System.Drawing.Point(416, 334);
            this.picBirth.Name = "picBirth";
            this.picBirth.Size = new System.Drawing.Size(96, 96);
            this.picBirth.TabIndex = 0;
            this.picBirth.TabStop = false;
            this.picBirth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBirth_MouseDown);
            // 
            // picDie
            // 
            this.picDie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picDie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDie.Location = new System.Drawing.Point(518, 334);
            this.picDie.Name = "picDie";
            this.picDie.Size = new System.Drawing.Size(96, 96);
            this.picDie.TabIndex = 0;
            this.picDie.TabStop = false;
            this.picDie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDie_MouseDown);
            // 
            // numIdleBegin
            // 
            this.numIdleBegin.Location = new System.Drawing.Point(65, 19);
            this.numIdleBegin.Name = "numIdleBegin";
            this.numIdleBegin.Size = new System.Drawing.Size(54, 20);
            this.numIdleBegin.TabIndex = 1;
            this.numIdleBegin.ValueChanged += new System.EventHandler(this.numIdleBegin_ValueChanged);
            // 
            // numIdleEnd
            // 
            this.numIdleEnd.Location = new System.Drawing.Point(131, 19);
            this.numIdleEnd.Name = "numIdleEnd";
            this.numIdleEnd.Size = new System.Drawing.Size(54, 20);
            this.numIdleEnd.TabIndex = 2;
            this.numIdleEnd.ValueChanged += new System.EventHandler(this.numIdleEnd_ValueChanged);
            // 
            // numMoveBegin
            // 
            this.numMoveBegin.Location = new System.Drawing.Point(65, 45);
            this.numMoveBegin.Name = "numMoveBegin";
            this.numMoveBegin.Size = new System.Drawing.Size(54, 20);
            this.numMoveBegin.TabIndex = 3;
            this.numMoveBegin.ValueChanged += new System.EventHandler(this.numMoveBegin_ValueChanged);
            // 
            // numMoveEnd
            // 
            this.numMoveEnd.Location = new System.Drawing.Point(131, 45);
            this.numMoveEnd.Name = "numMoveEnd";
            this.numMoveEnd.Size = new System.Drawing.Size(54, 20);
            this.numMoveEnd.TabIndex = 4;
            this.numMoveEnd.ValueChanged += new System.EventHandler(this.numMoveEnd_ValueChanged);
            // 
            // numBirthBegin
            // 
            this.numBirthBegin.Location = new System.Drawing.Point(65, 71);
            this.numBirthBegin.Name = "numBirthBegin";
            this.numBirthBegin.Size = new System.Drawing.Size(54, 20);
            this.numBirthBegin.TabIndex = 5;
            this.numBirthBegin.ValueChanged += new System.EventHandler(this.numBirthBegin_ValueChanged);
            // 
            // numBirthEnd
            // 
            this.numBirthEnd.Location = new System.Drawing.Point(131, 71);
            this.numBirthEnd.Name = "numBirthEnd";
            this.numBirthEnd.Size = new System.Drawing.Size(54, 20);
            this.numBirthEnd.TabIndex = 6;
            this.numBirthEnd.ValueChanged += new System.EventHandler(this.numBirthEnd_ValueChanged);
            // 
            // numDieBegin
            // 
            this.numDieBegin.Location = new System.Drawing.Point(65, 97);
            this.numDieBegin.Name = "numDieBegin";
            this.numDieBegin.Size = new System.Drawing.Size(54, 20);
            this.numDieBegin.TabIndex = 7;
            this.numDieBegin.ValueChanged += new System.EventHandler(this.numDieBegin_ValueChanged);
            // 
            // numDieEnd
            // 
            this.numDieEnd.Location = new System.Drawing.Point(131, 97);
            this.numDieEnd.Name = "numDieEnd";
            this.numDieEnd.Size = new System.Drawing.Size(54, 20);
            this.numDieEnd.TabIndex = 8;
            this.numDieEnd.ValueChanged += new System.EventHandler(this.numDieEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Idle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Move";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Die";
            // 
            // numDivX
            // 
            this.numDivX.Location = new System.Drawing.Point(68, 16);
            this.numDivX.Name = "numDivX";
            this.numDivX.Size = new System.Drawing.Size(54, 20);
            this.numDivX.TabIndex = 1;
            this.numDivX.ValueChanged += new System.EventHandler(this.numDivX_ValueChanged);
            // 
            // numDivY
            // 
            this.numDivY.Location = new System.Drawing.Point(134, 16);
            this.numDivY.Name = "numDivY";
            this.numDivY.Size = new System.Drawing.Size(54, 20);
            this.numDivY.TabIndex = 2;
            this.numDivY.ValueChanged += new System.EventHandler(this.numDivY_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Div.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numIdleBegin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numIdleEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numMoveBegin);
            this.groupBox1.Controls.Add(this.numMoveEnd);
            this.groupBox1.Controls.Add(this.numBirthBegin);
            this.groupBox1.Controls.Add(this.numDieEnd);
            this.groupBox1.Controls.Add(this.numBirthEnd);
            this.groupBox1.Controls.Add(this.numDieBegin);
            this.groupBox1.Location = new System.Drawing.Point(15, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtTexturePath);
            this.groupBox2.Controls.Add(this.numOffX);
            this.groupBox2.Controls.Add(this.numDivX);
            this.groupBox2.Controls.Add(this.numOffY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numDivY);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(6, 98);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(175, 62);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtTexturePath
            // 
            this.txtTexturePath.Location = new System.Drawing.Point(13, 72);
            this.txtTexturePath.Name = "txtTexturePath";
            this.txtTexturePath.Size = new System.Drawing.Size(175, 20);
            this.txtTexturePath.TabIndex = 5;
            this.txtTexturePath.Leave += new System.EventHandler(this.txtTexturePath_Leave);
            // 
            // numOffX
            // 
            this.numOffX.Location = new System.Drawing.Point(68, 42);
            this.numOffX.Name = "numOffX";
            this.numOffX.Size = new System.Drawing.Size(54, 20);
            this.numOffX.TabIndex = 3;
            this.numOffX.ValueChanged += new System.EventHandler(this.numOffX_ValueChanged);
            // 
            // numOffY
            // 
            this.numOffY.Location = new System.Drawing.Point(134, 42);
            this.numOffY.Name = "numOffY";
            this.numOffY.Size = new System.Drawing.Size(54, 20);
            this.numOffY.TabIndex = 4;
            this.numOffY.ValueChanged += new System.EventHandler(this.numOffY_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Off.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "He&lp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkPassable);
            this.groupBox3.Controls.Add(this.chkVulnerable);
            this.groupBox3.Controls.Add(this.cboMobBrick);
            this.groupBox3.Location = new System.Drawing.Point(15, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attribute";
            // 
            // chkPassable
            // 
            this.chkPassable.AutoSize = true;
            this.chkPassable.Location = new System.Drawing.Point(10, 69);
            this.chkPassable.Name = "chkPassable";
            this.chkPassable.Size = new System.Drawing.Size(69, 17);
            this.chkPassable.TabIndex = 2;
            this.chkPassable.Text = "Passable";
            this.chkPassable.UseVisualStyleBackColor = true;
            this.chkPassable.CheckedChanged += new System.EventHandler(this.chkPassable_CheckedChanged);
            // 
            // chkVulnerable
            // 
            this.chkVulnerable.AutoSize = true;
            this.chkVulnerable.Location = new System.Drawing.Point(10, 48);
            this.chkVulnerable.Name = "chkVulnerable";
            this.chkVulnerable.Size = new System.Drawing.Size(76, 17);
            this.chkVulnerable.TabIndex = 1;
            this.chkVulnerable.Text = "Vulnerable";
            this.chkVulnerable.UseVisualStyleBackColor = true;
            this.chkVulnerable.CheckedChanged += new System.EventHandler(this.chkVulnerable_CheckedChanged);
            // 
            // cboMobBrick
            // 
            this.cboMobBrick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMobBrick.FormattingEnabled = true;
            this.cboMobBrick.Items.AddRange(new object[] {
            "Mob",
            "Brick"});
            this.cboMobBrick.Location = new System.Drawing.Point(10, 20);
            this.cboMobBrick.Name = "cboMobBrick";
            this.cboMobBrick.Size = new System.Drawing.Size(175, 21);
            this.cboMobBrick.TabIndex = 0;
            this.cboMobBrick.SelectedIndexChanged += new System.EventHandler(this.cboMobBrick_SelectedIndexChanged);
            // 
            // tmrUpdateAnimation
            // 
            this.tmrUpdateAnimation.Enabled = true;
            this.tmrUpdateAnimation.Tick += new System.EventHandler(this.tmrUpdateAnimation_Tick);
            // 
            // dlgOpenPNG
            // 
            this.dlgOpenPNG.DefaultExt = "png";
            this.dlgOpenPNG.Filter = "PNG|*.png|All files|*.*";
            // 
            // dlgSaveXML
            // 
            this.dlgSaveXML.DefaultExt = "xml";
            this.dlgSaveXML.Filter = "XML|*.xml";
            // 
            // dlgOpenXML
            // 
            this.dlgOpenXML.Filter = "XML|*.xml|All files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew,
            this.mnOpen,
            this.mnSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnNew
            // 
            this.mnNew.Name = "mnNew";
            this.mnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnNew.Size = new System.Drawing.Size(146, 22);
            this.mnNew.Text = "New";
            this.mnNew.Click += new System.EventHandler(this.mnNew_Click);
            // 
            // mnOpen
            // 
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnOpen.Size = new System.Drawing.Size(146, 22);
            this.mnOpen.Text = "Open";
            this.mnOpen.Click += new System.EventHandler(this.mnOpen_Click);
            // 
            // mnSave
            // 
            this.mnSave.Name = "mnSave";
            this.mnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnSave.Size = new System.Drawing.Size(146, 22);
            this.mnSave.Text = "Save";
            this.mnSave.Click += new System.EventHandler(this.mnSave_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnRefresh});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnRefresh
            // 
            this.mnRefresh.Name = "mnRefresh";
            this.mnRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnRefresh.Size = new System.Drawing.Size(132, 22);
            this.mnRefresh.Text = "Refresh";
            this.mnRefresh.Click += new System.EventHandler(this.mnRefresh_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picSheet);
            this.Controls.Add(this.picDie);
            this.Controls.Add(this.picBirth);
            this.Controls.Add(this.picMove);
            this.Controls.Add(this.picIdle);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmEditor";
            this.Text = "Orange Mob Editor";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_FormClosing);
            this.Resize += new System.EventHandler(this.frmEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picIdle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffY)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIdle;
        private System.Windows.Forms.PictureBox picSheet;
        private System.Windows.Forms.PictureBox picMove;
        private System.Windows.Forms.PictureBox picBirth;
        private System.Windows.Forms.PictureBox picDie;
        private System.Windows.Forms.NumericUpDown numIdleBegin;
        private System.Windows.Forms.NumericUpDown numIdleEnd;
        private System.Windows.Forms.NumericUpDown numMoveBegin;
        private System.Windows.Forms.NumericUpDown numMoveEnd;
        private System.Windows.Forms.NumericUpDown numBirthBegin;
        private System.Windows.Forms.NumericUpDown numBirthEnd;
        private System.Windows.Forms.NumericUpDown numDieBegin;
        private System.Windows.Forms.NumericUpDown numDieEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDivX;
        private System.Windows.Forms.NumericUpDown numDivY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numOffX;
        private System.Windows.Forms.NumericUpDown numOffY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtTexturePath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMobBrick;
        private System.Windows.Forms.CheckBox chkPassable;
        private System.Windows.Forms.CheckBox chkVulnerable;
        private System.Windows.Forms.Timer tmrUpdateAnimation;
        private System.Windows.Forms.OpenFileDialog dlgOpenPNG;
        private System.Windows.Forms.SaveFileDialog dlgSaveXML;
        private System.Windows.Forms.OpenFileDialog dlgOpenXML;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnRefresh;
    }
}

