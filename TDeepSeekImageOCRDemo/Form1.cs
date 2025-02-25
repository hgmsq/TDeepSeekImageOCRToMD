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

namespace TDeepSeekImageOCRDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 可以在窗体初始化时加载文件夹结构
            //LoadFolderStructure(@"D:\OCRTest\115265abe3d74eb7ad51776804606d77");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFileUrl.Text = "https://mmbiz.qpic.cn/mmbiz_png/6OxqSqWBqsKKfEv3sLcYBUMDxHIoJYeVrJT79QT1OmxCFwwWjvQOB3RZH3OCxvoMYp6mRdA7VnOBReUdDm36qg/640?wxfrom=12&tp=wxpic&usePicPrefetch=1&wx_fmt=png&amp;from=appmsg";
        }

        private void LoadFolderStructure(string folderPath)
        {
            // 清除现有的节点
            treeView1.Nodes.Clear();

            // 创建根节点
            TreeNode rootNode = new TreeNode(new DirectoryInfo(folderPath).Name);
            rootNode.Tag = folderPath; // 存储路径信息以便后续使用
            rootNode.Expand();
            treeView1.Nodes.Add(rootNode);

            // 开始递归加载子文件夹
            PopulateTreeView(rootNode, folderPath);
        }

        private void PopulateTreeView(TreeNode parentNode, string folderPath)
        {
            try
            {
                // 获取所有子文件夹
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();

                foreach (DirectoryInfo dir in subDirs)
                {
                    TreeNode node = new TreeNode(dir.Name);
                    node.Tag = dir.FullName; // 存储路径信息以便后续使用
                    parentNode.Nodes.Add(node);

                    // 递归调用以加载子文件夹
                    PopulateTreeView(node, dir.FullName);
                    node.Expand();
                }

                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    fileNode.Tag = file.FullName;
                    fileNode.ImageIndex = 1; // 文件图标索引
                    fileNode.SelectedImageIndex = 1;
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"访问被拒绝: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFileUrl.Text))
            {
                MessageBox.Show("请输入需要解析的图片URL");
            }
            else
            {
                string taskId = ImageOCRUtils.CreateImageOcrTask(txtFileUrl.Text);
                txtTaskId.Text = taskId;
            }

        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string documentUrl = txtDocumentUrl.Text;
            if (string.IsNullOrWhiteSpace(documentUrl))
            {
                MessageBox.Show("请先获取解析结果文档URL");
            }
            else
            {
                if (documentUrl == "-1")
                {
                    MessageBox.Show("解析结果文档UR获取失败！");
                }
                else
                {
                    string result = ImageOCRUtils.DownloadFile(documentUrl);
                    // 可以在窗体初始化时加载文件夹结构
                    LoadFolderStructure(result);
                    MessageBox.Show(result);
                }
            }
        }
        /// <summary>
        /// 获取文档URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string taskId = txtTaskId.Text;
            if (string.IsNullOrWhiteSpace(taskId))
            {
                MessageBox.Show("请先获取创建文档任务返回的TaskId");
            }
            else
            {
                if (taskId == "-1")
                {
                    MessageBox.Show("TaskId获取失败！");
                }
                else
                {
                    string documentUrl = ImageOCRUtils.GetResultDocumentUrl(taskId);
                    txtDocumentUrl.Text = documentUrl;
                }
            }
           
        }
    }
}
