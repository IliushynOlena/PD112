using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_TreeViewListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDirectories(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                dirTree.Nodes);
            LoadImages();
            fileList.View = View.Details;
            fileList.Columns.Add("Name").Width = 300;
            fileList.Columns.Add("Extension").Width = 300;
            fileList.Columns.Add("Create Time").Width = 300;
        }
        void LoadImages()
        {
            ImageList list = new ImageList();
            list.Images.Add(new Bitmap("Images/folder1.png"));
            list.Images.Add(new Bitmap("Images/folder2.png"));
            list.Images.Add(new Bitmap("Images/folder3.png"));
            dirTree.ImageList = list;
            dirTree.ImageList.ImageSize = new Size(50, 40);
        }
        public void LoadDirectories(string path, TreeNodeCollection nodes)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var subdir in dir.GetDirectories())
            {
                TreeNode newNode = new TreeNode(subdir.Name,1,2);
                newNode.Tag = subdir.FullName;
                nodes.Add(newNode);
                //dirTree.Nodes.Add(subdir.Name);
                if (subdir.GetDirectories().Length > 0)
                    LoadDirectories(subdir.FullName,newNode.Nodes);
            }
            
        }

        private void dirTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void dirTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void dirTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            DirectoryInfo info = new DirectoryInfo(e.Node.Tag.ToString());
            fileList.Items.Clear();
            foreach (var file in info.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(file.CreationTime.ToString());


                fileList.Items.Add(item);
            }
           
        }
    }
}
