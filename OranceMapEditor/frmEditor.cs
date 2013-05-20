using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace OranceMapEditor
{
    public partial class frmEditor : Form
    {
        //TODO: correct editor, using Render() function
        //TODO: save to xml
        public frmEditor()
        {
            InitializeComponent();
        }
        enum DrawMode
        {
            BRICK,
            MOB,
            CHARACTER
        }
        Bitmap renderBitmap;
        Graphics renderer;
        int[,] matrixBrick;
        int[,] matrixMob;
        DrawMode drawMode;
        private void frmEditor_Load(object sender, EventArgs e)
        {
            matrixBrick = new int[11,13];
            matrixMob = new int[11, 13];
            renderBitmap = new Bitmap(13*42+1,11*42+1);
            renderer = Graphics.FromImage(renderBitmap);
            drawGrid();
            picPreview.Image = renderBitmap;
            drawMode = DrawMode.BRICK;
            cboMobs.Enabled = false;
            {
                DirectoryInfo dir = new DirectoryInfo("Brick");
                foreach (FileInfo item in dir.GetFiles("*.xml"))
                {
                    cboBricks.Items.Add(item.Name);
                }
                if (cboBricks.Items.Count > 0) cboBricks.SelectedIndex = 0;
            }
            {
                DirectoryInfo dir = new DirectoryInfo("Mob");
                foreach (FileInfo item in dir.GetFiles("*.xml"))
                {
                    cboMobs.Items.Add(item.Name);
                }
                if (cboMobs.Items.Count > 0) cboMobs.SelectedIndex = 0;
            }
        }
        void DrawBrick(int x, int y, int id)
        {
            matrixBrick[x, y] = id;
            //renderer.FillRectangle(Brushes.Blue, new Rectangle(x*42, y*42, 42, 42));
            renderer.DrawImage(picItemPreview.Image, new Point(x*42, y*42));
        }
        void DrawMob(int x, int y, int id)
        {
            matrixMob[x, y] = id;
            //renderer.FillRectangle(Brushes.Green, new Rectangle(x * 42, y * 42, 42, 42));
            renderer.DrawImage(picItemPreview.Image, new Point(x * 42, y * 42));
        }
        void DrawCharacter(int x, int y)
        {
            matrixMob[x, y] = -1;
            renderer.FillRectangle(Brushes.DarkGray, new Rectangle(x * 42, y * 42, 42, 42));
        }
        private void drawGrid()
        {
            Pen pen = new Pen(Brushes.Black);
            for (int i = 0; i <= 13; i++)
            {
                renderer.DrawLine(pen, new Point(i * 42, 0), new Point(i * 42, 11 * 42));
            }
            for (int i = 0; i <= 11; i++)
            {
                renderer.DrawLine(pen, new Point(0, i * 42), new Point(13 * 42, i * 42));
            }
        }

        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            Point position = new Point(e.X/42, e.Y/42);
            //MessageBox.Show(position.ToString());
            if (drawMode == DrawMode.BRICK)
            {
                DrawBrick(position.X, position.Y, 0);
            }
            else if(drawMode== DrawMode.MOB)
            {
                DrawMob(position.X, position.Y, 0);
            }
            else if (drawMode == DrawMode.CHARACTER)
            {
                DrawCharacter(position.X, position.Y);
            }
            picPreview.Image = renderBitmap;
        }

        private void btnBrick_Click(object sender, EventArgs e)
        {
            btnBrick.Enabled = false;
            cboBricks.Enabled = true;
            btnCharacter.Enabled = true;
            btnMob.Enabled = true;
            cboMobs.Enabled = false;
            drawMode = DrawMode.BRICK;
            cboBricks_SelectedIndexChanged(sender, e);
        }

        private void btnMob_Click(object sender, EventArgs e)
        {
            btnBrick.Enabled = true;
            cboBricks.Enabled = false;
            btnCharacter.Enabled = true;
            btnMob.Enabled = false;
            cboMobs.Enabled = true;
            drawMode = DrawMode.MOB;
            cboMobs_SelectedIndexChanged(sender, e);
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            btnBrick.Enabled = true;
            cboBricks.Enabled = false;
            btnCharacter.Enabled = false;
            btnMob.Enabled = true;
            cboMobs.Enabled = false;
            drawMode = DrawMode.CHARACTER;
        }

        private void cboBricks_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText("Brick/"+cboBricks.Text));
            XmlElement root;
            if (doc.FirstChild is XmlElement)
            {
                root = (XmlElement)doc.FirstChild;
            }
            else
            {
                root = (XmlElement)doc.FirstChild.NextSibling;
            }
            XmlElement textureTAG = (XmlElement)root.FirstChild;
            string pngFile = "Brick/"+textureTAG.GetAttribute("file")+".png";
            Bitmap sourceBitmap = new Bitmap(pngFile);
            int divX = int.Parse(textureTAG.GetAttribute("divide_x"));
            int divY = int.Parse(textureTAG.GetAttribute("divide_y"));
            Bitmap previewBitmap = new Bitmap(sourceBitmap.Width / divX,
                sourceBitmap.Height / divY);
            Graphics g = Graphics.FromImage(previewBitmap);
            g.DrawImage(sourceBitmap, 
                new Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height),
                new Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height),
                GraphicsUnit.Pixel);
            picItemPreview.Image = previewBitmap;

        }

        private void cboMobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText("Mob/" + cboMobs.Text));
            XmlElement root;
            if (doc.FirstChild is XmlElement)
            {
                root = (XmlElement)doc.FirstChild;
            }
            else
            {
                root = (XmlElement)doc.FirstChild.NextSibling;
            }
            XmlElement textureTAG = (XmlElement)root.FirstChild;
            string pngFile = "Mob/" + textureTAG.GetAttribute("file") + ".png";
            Bitmap sourceBitmap = new Bitmap(pngFile);
            int divX = int.Parse(textureTAG.GetAttribute("divide_x"));
            int divY = int.Parse(textureTAG.GetAttribute("divide_y"));
            Bitmap previewBitmap = new Bitmap(sourceBitmap.Width / divX,
                sourceBitmap.Height / divY);
            Graphics g = Graphics.FromImage(previewBitmap);
            g.DrawImage(sourceBitmap,
                new Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height),
                new Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height),
                GraphicsUnit.Pixel);
            picItemPreview.Image = previewBitmap;

        }
        Bitmap GetPreviewBitmap()
        {
            return new Bitmap(1, 1);
        }
    }
}
