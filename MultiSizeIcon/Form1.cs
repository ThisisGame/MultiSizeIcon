using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MultiSizeIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Diagnostics.Process.Start("http://blog.csdn.net/huutu/article/details/73380214");
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream stream = File.OpenRead("./app_icon.png");
            int fileLength = 0;
            fileLength = (int)stream.Length;
            Byte[] image = new Byte[fileLength];
            stream.Read(image, 0, fileLength);
            System.Drawing.Image result = System.Drawing.Image.FromStream(stream);
            stream.Close();



            string[] tmpAndroidIconFolder = { "drawable", "drawable-hdpi", "drawable-ldpi", "drawable-mdpi", "drawable-xhdpi", "drawable-xxhdpi", "drawable-xxxhdpi" };
            int[] tmpAndroidIconSize = { 48, 72, 36, 36, 96, 144, 192 };

            for (int i = 0; i < tmpAndroidIconFolder.Length; i++)
            {
                Size s = new Size(tmpAndroidIconSize[i], tmpAndroidIconSize[i]);
                Bitmap newBit = new Bitmap(result, s);

                string tmpIconPath = "./Android/" + tmpAndroidIconFolder[i] ;
                if(Directory.Exists(tmpIconPath)==false)
                {
                    Directory.CreateDirectory(tmpIconPath);
                }
                newBit.Save(tmpIconPath + "/app_icon.png");
                newBit.Dispose();
            }

            MessageBox.Show("Finish");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream stream = File.OpenRead("./app_icon.png");
            int fileLength = 0;
            fileLength = (int)stream.Length;
            Byte[] image = new Byte[fileLength];
            stream.Read(image, 0, fileLength);
            System.Drawing.Image result = System.Drawing.Image.FromStream(stream);
            stream.Close();



            string[] tmpAndroidIconFolder = { "drawable", "drawable-hdpi", "drawable-ldpi", "drawable-mdpi", "drawable-xhdpi", "drawable-xxhdpi", "drawable-xxxhdpi" };
            int[] tmpAndroidIconSize = { 48, 192, 36, 36, 256, 384, 512 };

            for (int i = 0; i < tmpAndroidIconFolder.Length; i++)
            {
                Size s = new Size(tmpAndroidIconSize[i], tmpAndroidIconSize[i]);
                Bitmap newBit = new Bitmap(result, s);

                string tmpIconPath = "./Android HD/" + tmpAndroidIconFolder[i];
                if (Directory.Exists(tmpIconPath) == false)
                {
                    Directory.CreateDirectory(tmpIconPath);
                }
                newBit.Save(tmpIconPath + "/app_icon.png");
                newBit.Dispose();
            }

            MessageBox.Show("Finish");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream stream = File.OpenRead("./app_icon.png");
            int fileLength = 0;
            fileLength = (int)stream.Length;
            Byte[] image = new Byte[fileLength];
            stream.Read(image, 0, fileLength);
            System.Drawing.Image result = System.Drawing.Image.FromStream(stream);
            stream.Close();



            string[] tmpIOSIconName = { "Icon.png", "Icon@2x.png", "Icon-72.png", "Icon-76.png", "Icon-120.png", "Icon-144.png", "Icon-152.png", "Icon-167.png", "Icon-180.png", "Icon-1024.png" };
            int[] tmpIosIconSize = { 57, 114, 72, 76, 120, 144, 152,167,180 ,1024};

            for (int i = 0; i < tmpIOSIconName.Length; i++)
            {
                Size s = new Size(tmpIosIconSize[i], tmpIosIconSize[i]);
                Bitmap newBit = new Bitmap(result, s);

                string tmpIconPath = "./IOS/";
                if (Directory.Exists(tmpIconPath) == false)
                {
                    Directory.CreateDirectory(tmpIconPath);
                }
                
                if(tmpIosIconSize[i]==1024)
                {
                    newBit.Save(tmpIconPath + tmpIOSIconName[i], ImageFormat.Jpeg);
                }
                else
                {
                    newBit.Save(tmpIconPath + tmpIOSIconName[i]);
                }

                
                newBit.Dispose();
            }

            MessageBox.Show("Finish");
        }
    }
}
