using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace MobEditor
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
        }
        string currentFile;
        bool saved;
        private void frmEditor_Load(object sender, EventArgs e)
        {
            cboMobBrick.SelectedIndex = 0;
            pieceBitmaps = new List<Bitmap>();
            renderBitmaps = new List<Bitmap>();
            currentFile = "Untitled";
            savedFalse();
        }
        Bitmap masterBitmap;
        List<Bitmap> pieceBitmaps;
        List<Bitmap> renderBitmaps;
        void loadBitmap()
        {
            if (masterBitmap != null) masterBitmap.Dispose();
            try
            {
                masterBitmap = new Bitmap(txtTexturePath.Text);
                picSheet.Image = masterBitmap;
            }
            catch
            {
                MessageBox.Show("problem occur when loading texture!");
            }
        }
        void cutBitmap()
        {
            int divX = (int)numDivX.Value;
            int divY = (int)numDivY.Value;
            if (divX == 0 || divY == 0 || masterBitmap == null)
            {
                return;
            }
            foreach (Bitmap item in pieceBitmaps)
            {
                item.Dispose();
            }
            pieceBitmaps.Clear();
            int w = masterBitmap.Width / divX;
            int h = masterBitmap.Height / divY;
            for (int i = 0; i < divY; i++)
            {
                for (int j = 0; j < divX; j++)
                {
                    int x = w * j;
                    int y = h * i;
                    Bitmap piece = new Bitmap(w, h);
                    Graphics g = Graphics.FromImage(piece);
                    g.DrawImage(masterBitmap,
                        new Rectangle(0, 0, w, h),
                        new Rectangle(x, y, w, h),
                        GraphicsUnit.Pixel);
                    pieceBitmaps.Add(piece);
                }
            }
            int max = divX * divY-1;
            numIdleBegin.Maximum = max;
            numIdleEnd.Maximum = max;
            numMoveBegin.Maximum = max;
            numMoveEnd.Maximum = max;
            numBirthBegin.Maximum = max;
            numBirthEnd.Maximum = max;
            numDieBegin.Maximum = max;
            numDieEnd.Maximum = max;
            numOffX.Maximum = w;
            numOffY.Maximum = h;
        }
        void renderBitmap()
        {
            if (pieceBitmaps.Count == 0) return;
            int offX = (int)numOffX.Value;
            int offY = (int)numOffY.Value;
            foreach (Bitmap item in renderBitmaps)
            {
                item.Dispose();
            }
            renderBitmaps.Clear();
            foreach (Bitmap item in pieceBitmaps)
            {
                Bitmap render = new Bitmap(item);
                Graphics g = Graphics.FromImage(render);
                Pen pen = new Pen(Brushes.Orange);
                g.DrawLine(pen, new Point(0, offY), new Point(render.Width, offY));
                g.DrawLine(pen, new Point(offX, 0), new Point(offX, render.Height));
                renderBitmaps.Add(render);
            }
        }
        int idleFrame = 0;
        int idleBegin = 0;
        int idleEnd = 0;
        void updateIdle()
        {
            idleFrame++;
            if(idleFrame > idleEnd) idleFrame = idleBegin;
            picIdle.Image = renderBitmaps[idleFrame];
        }
        int moveFrame = 0;
        int moveBegin = 0;
        int moveEnd = 0;
        void updateMove()
        {
            moveFrame++;
            if (moveFrame > moveEnd) moveFrame = moveBegin;
            picMove.Image = renderBitmaps[moveFrame];
        }
        int birthFrame = 0;
        int birthBegin = 0;
        int birthEnd = 0;
        void updateBirth()
        {
            birthFrame++;
            if (birthFrame > birthEnd) birthFrame = birthBegin;
            picBirth.Image = renderBitmaps[birthFrame];
        }
        int dieFrame = 0;
        int dieBegin = 0;
        int dieEnd = 0;
        void updateDie()
        {
            dieFrame++;
            if (dieFrame > dieEnd) dieFrame = dieBegin;
            picDie.Image = renderBitmaps[dieFrame];
        }
        private void cboMobBrick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMobBrick.SelectedIndex == 1)
            {
                numMoveBegin.Enabled = false;
                numMoveEnd.Enabled = false;
            }
            else
            {
                numMoveBegin.Enabled = true;
                numMoveEnd.Enabled = true;
            }
            savedFalse();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgOpenPNG.ShowDialog() != DialogResult.OK) return;
            txtTexturePath.Text = dlgOpenPNG.FileName;
            savedFalse();
            loadBitmap();
            cutBitmap();
        }

        private void numIdleBegin_ValueChanged(object sender, EventArgs e)
        {
            idleBegin = (int)numIdleBegin.Value;
            savedFalse();
        }

        private void numIdleEnd_ValueChanged(object sender, EventArgs e)
        {
            idleEnd = (int)numIdleEnd.Value;
            savedFalse();
        }

        private void numMoveBegin_ValueChanged(object sender, EventArgs e)
        {
            moveBegin = (int)numMoveBegin.Value;
            savedFalse();
        }

        private void numMoveEnd_ValueChanged(object sender, EventArgs e)
        {
            moveEnd = (int)numMoveEnd.Value;
            savedFalse();
        }

        private void numBirthBegin_ValueChanged(object sender, EventArgs e)
        {
            birthBegin = (int)numBirthBegin.Value;
            savedFalse();
        }

        private void numBirthEnd_ValueChanged(object sender, EventArgs e)
        {
            birthEnd = (int)numBirthEnd.Value;
            savedFalse();
        }

        private void numDieBegin_ValueChanged(object sender, EventArgs e)
        {
            dieBegin = (int)numDieBegin.Value;
            savedFalse();
        }

        private void numDieEnd_ValueChanged(object sender, EventArgs e)
        {
            dieEnd = (int)numDieEnd.Value;
            savedFalse();
        }

        private void savedFalse()
        {
            saved = false;
            this.Text = Application.ProductName + " - " + currentFile + (saved ? "" : "*");
        }
        private void savedTrue()
        {
            saved = true;
            this.Text = Application.ProductName + " - " + currentFile + (saved ? "" : "*");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentFile == "Untitled")
            {
                if (dlgSaveXML.ShowDialog() != DialogResult.OK) return;
                currentFile = dlgSaveXML.FileName;
            }
            XmlDocument doc = new XmlDocument();
            XmlElement rootTAG;
            if (cboMobBrick.SelectedIndex == 0)
            {
                rootTAG = doc.CreateElement("mob");
            }
            else
            {
                rootTAG = doc.CreateElement("brick");
            }
            XmlElement textureTAG = doc.CreateElement("texture");
            {
                int nameBegin = txtTexturePath.Text.LastIndexOf('\\')+1;
                int nameEnd = txtTexturePath.Text.LastIndexOf('.');
                string name = txtTexturePath.Text.Substring(nameBegin, nameEnd - nameBegin);
                textureTAG.SetAttribute("file", name);
                textureTAG.SetAttribute("divide_x", numDivX.Value.ToString());
                textureTAG.SetAttribute("divide_y", numDivY.Value.ToString());
                textureTAG.SetAttribute("offset_x", numOffX.Value.ToString());
                textureTAG.SetAttribute("offset_y", numOffY.Value.ToString());
                rootTAG.AppendChild(textureTAG);
            }
            XmlElement attributeTAG = doc.CreateElement("attribute");
            {
                attributeTAG.SetAttribute("vulnerable", chkVulnerable.Checked.ToString());
                attributeTAG.SetAttribute("passable", chkPassable.Checked.ToString());
                rootTAG.AppendChild(attributeTAG);
            }
            XmlElement animationTAG = doc.CreateElement("animation");
            {
                XmlElement idleTAG = doc.CreateElement("idle");
                idleTAG.SetAttribute("begin", numIdleBegin.Value.ToString());
                idleTAG.SetAttribute("end", numIdleEnd.Value.ToString());
                animationTAG.AppendChild(idleTAG);
                XmlElement moveTAG = doc.CreateElement("move");
                moveTAG.SetAttribute("begin", numMoveBegin.Value.ToString());
                moveTAG.SetAttribute("end", numMoveEnd.Value.ToString());
                animationTAG.AppendChild(moveTAG);
                XmlElement birthTAG = doc.CreateElement("birth");
                birthTAG.SetAttribute("begin", numBirthBegin.Value.ToString());
                birthTAG.SetAttribute("end", numBirthEnd.Value.ToString());
                animationTAG.AppendChild(birthTAG);
                XmlElement dieTAG = doc.CreateElement("die");
                dieTAG.SetAttribute("begin", numDieBegin.Value.ToString());
                dieTAG.SetAttribute("end", numDieEnd.Value.ToString());
                animationTAG.AppendChild(dieTAG);
                rootTAG.AppendChild(animationTAG);
            }
            doc.AppendChild(rootTAG);
                XmlTextWriter writer = new XmlTextWriter(currentFile,Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
                writer.Close();
            savedTrue();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpenXML.ShowDialog() != DialogResult.OK) return;
            FileInfo xmlFile = new FileInfo(dlgOpenXML.FileName);
            string folder = xmlFile.Directory.FullName;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(dlgOpenXML.FileName));
            XmlElement rootTAG;
            if(doc.FirstChild is XmlElement)
            {
                rootTAG = (XmlElement)doc.FirstChild;
            }
            else
            {
                rootTAG = (XmlElement)doc.FirstChild.NextSibling;
            }
            if (rootTAG.Name == "mob")
            {
                cboMobBrick.SelectedIndex = 0;
            }
            else
            {
                cboMobBrick.SelectedIndex = 1;
            }
            XmlElement textureTAG;
            XmlElement attributeTAG;
            XmlElement animationTAG;
            {
                textureTAG = (XmlElement)rootTAG.FirstChild;
                txtTexturePath.Text = folder + "\\" + textureTAG.GetAttribute("file")+".png";
                int divX = int.Parse(textureTAG.GetAttribute("divide_x"));
                int divY = int.Parse(textureTAG.GetAttribute("divide_y"));
                loadBitmap();
                cutBitmap();
                numOffX.Maximum = masterBitmap.Width / divX;
                numOffY.Maximum = masterBitmap.Height / divY;
                numDivX.Value = divX;
                numDivY.Value = divY;
                numOffX.Value = int.Parse(textureTAG.GetAttribute("offset_x"));
                numOffY.Value = int.Parse(textureTAG.GetAttribute("offset_y"));
                int max = divX * divY - 1;
                numIdleBegin.Maximum = max;
                numIdleEnd.Maximum = max;
                numMoveBegin.Maximum = max;
                numMoveEnd.Maximum = max;
                numBirthBegin.Maximum = max;
                numBirthEnd.Maximum = max;
                numDieBegin.Maximum = max;
                numDieEnd.Maximum = max;
            }
            {
                attributeTAG = (XmlElement)textureTAG.NextSibling;
                chkPassable.Checked = bool.Parse(attributeTAG.GetAttribute("passable"));
                chkVulnerable.Checked = bool.Parse(attributeTAG.GetAttribute("vulnerable"));
            }
            {
                animationTAG = (XmlElement)attributeTAG.NextSibling;
                XmlElement idleTAG = (XmlElement)animationTAG.FirstChild;
                numIdleBegin.Value = int.Parse(idleTAG.GetAttribute("begin"));
                numIdleEnd.Value = int.Parse(idleTAG.GetAttribute("end"));
                XmlElement moveTAG = (XmlElement)idleTAG.NextSibling;
                numMoveBegin.Value = int.Parse(moveTAG.GetAttribute("begin"));
                numMoveEnd.Value = int.Parse(moveTAG.GetAttribute("end"));
                XmlElement birthTAG = (XmlElement)moveTAG.NextSibling;
                numBirthBegin.Value = int.Parse(birthTAG.GetAttribute("begin"));
                numBirthEnd.Value = int.Parse(birthTAG.GetAttribute("end"));
                XmlElement dieTAG = (XmlElement)birthTAG.NextSibling;
                numDieBegin.Value = int.Parse(dieTAG.GetAttribute("begin"));
                numDieEnd.Value = int.Parse(dieTAG.GetAttribute("end"));
            }
            renderBitmap();
            currentFile = dlgOpenXML.FileName;
            savedTrue();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach (Bitmap item in pieceBitmaps)
            {
                item.Dispose();
            }
            pieceBitmaps.Clear();
            if(masterBitmap != null) masterBitmap.Dispose();
            numIdleBegin.Maximum = numIdleBegin.Value = 0;
            numIdleEnd.Maximum = numIdleEnd.Value = 0;
            numMoveBegin.Maximum = numMoveBegin.Value = 0;
            numMoveEnd.Maximum = numMoveEnd.Value = 0;
            numBirthBegin.Maximum = numBirthBegin.Value = 0;
            numBirthEnd.Maximum = numBirthEnd.Value = 0;
            numDieBegin.Maximum = numDieBegin.Value = 0;
            numDieEnd.Maximum = numDieBegin.Value = 0;
            cboMobBrick.SelectedIndex = 0;
            chkPassable.Checked = false;
            chkVulnerable.Checked = false;
            masterBitmap = null;
            picBirth.Image = null;
            picDie.Image = null;
            picIdle.Image = null;
            picMove.Image = null;
            picSheet.Image = null;
            currentFile = "Untitled";
            savedFalse();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Too lazy to do this", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numDivX_ValueChanged(object sender, EventArgs e)
        {
            cutBitmap();
        }

        private void numDivY_ValueChanged(object sender, EventArgs e)
        {
            cutBitmap();
        }

        private void numOffX_ValueChanged(object sender, EventArgs e)
        {
            renderBitmap();
        }

        private void numOffY_ValueChanged(object sender, EventArgs e)
        {
            renderBitmap();
        }

        private void tmrUpdateAnimation_Tick(object sender, EventArgs e)
        {
            if (renderBitmaps.Count == 0) return;
            updateIdle();
            updateMove();
            updateBirth();
            updateDie();
        }

        private void txtTexturePath_Leave(object sender, EventArgs e)
        {
            loadBitmap();
            cutBitmap();
            renderBitmap();
        }

        private void frmEditor_Resize(object sender, EventArgs e)
        {
            int begin = picIdle.Location.X;
            int end = this.Size.Width - 26;
            int len = (end - begin - 6*3)/4;
            picIdle.Width = len;
            picMove.Width = len;
            picBirth.Width = len;
            picDie.Width = len;
            picMove.Left = picIdle.Left + len + 6;
            picBirth.Left = picMove.Left + len + 6;
            picDie.Left = picBirth.Left + len + 6;
        }

        private void picIdle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < numOffX.Maximum)
                numOffX.Value = e.X;
            else
                numOffX.Value = numOffX.Maximum;
            if (e.Y < numOffY.Maximum)
                numOffY.Value = e.Y;
            else
                numOffY.Value = numOffY.Maximum;
        }

        private void picMove_MouseDown(object sender, MouseEventArgs e)
        {
            picIdle_MouseDown(sender, e);
        }

        private void picBirth_MouseDown(object sender, MouseEventArgs e)
        {
            picIdle_MouseDown(sender, e);
        }

        private void picDie_MouseDown(object sender, MouseEventArgs e)
        {
            picIdle_MouseDown(sender, e);
        }

        private void mnNew_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }

        private void mnSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void mnRefresh_Click(object sender, EventArgs e)
        {
            cutBitmap();
            renderBitmap();
        }

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult question = MessageBox.Show("Do you wanna save this file?\n"+currentFile,Application.ProductName,
                    MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (question == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkVulnerable_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
            this.Text = Application.ProductName + " - " + currentFile + (saved ? "" : "*");
        }

        private void chkPassable_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
            this.Text = Application.ProductName + " - " + currentFile + (saved ? "" : "*");
        }
    }
}
