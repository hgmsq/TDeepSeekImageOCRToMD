using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TencentCloud.Common.Profile;
using TencentCloud.Common;
using TencentCloud.Lke.V20231130;
using TencentCloud.Lke.V20231130.Models;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using static System.Net.Mime.MediaTypeNames;


namespace TDeepSeekImageOCRDemo
{
    public class ImageOCRUtils
    {       
        /// <summary>
        /// 第一步 创建文档解析任务
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static string CreateImageOcrTask(string imageUrl)
        {
            try
            {
                // 实例化一个认证对象，入参需要传入腾讯云账户 SecretId 和 SecretKey，此处还需注意密钥对的保密
                // 代码泄露可能会导致 SecretId 和 SecretKey 泄露，并威胁账号下所有资源的安全性。以下代码示例仅供参考，建议采用更安全的方式来使用密钥，请参见：https://cloud.tencent.com/document/product/1278/85305
                // 密钥可前往官网控制台 https://console.cloud.tencent.com/cam/capi 进行获取
                Credential cred = new Credential
                {
                    SecretId = "",
                    SecretKey = ""
                };
                // 实例化一个client选项，可选的，没有特殊需求可以跳过
                ClientProfile clientProfile = new ClientProfile();
                // 实例化一个http选项，可选的，没有特殊需求可以跳过
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("lke.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;

                // 实例化要请求产品的client对象,clientProfile是可选的
                LkeClient client = new LkeClient(cred, "ap-guangzhou", clientProfile);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                CreateReconstructDocumentFlowRequest req = new CreateReconstructDocumentFlowRequest();
                req.FileUrl = imageUrl;
                CreateReconstructDocumentFlowConfig createReconstructDocumentFlowConfig1 = new CreateReconstructDocumentFlowConfig();
                createReconstructDocumentFlowConfig1.TableResultType = "1";
                createReconstructDocumentFlowConfig1.ResultType = "0";
                req.Config = createReconstructDocumentFlowConfig1;
                // 返回的resp是一个CreateReconstructDocumentFlowResponse的实例，与请求对象对应
                CreateReconstructDocumentFlowResponse resp = client.CreateReconstructDocumentFlowSync(req);
                // 输出json格式的字符串回包
                Console.WriteLine(AbstractModel.ToJsonString(resp));
                
                return resp.TaskId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "-1";
            }
        }

        /// <summary>
        /// 第二步 根据任务ID获取文档地址
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static string GetResultDocumentUrl(string taskId)
        {

            try
            {
                // 实例化一个认证对象，入参需要传入腾讯云账户 SecretId 和 SecretKey，此处还需注意密钥对的保密
                // 代码泄露可能会导致 SecretId 和 SecretKey 泄露，并威胁账号下所有资源的安全性。以下代码示例仅供参考，建议采用更安全的方式来使用密钥，请参见：https://cloud.tencent.com/document/product/1278/85305
                // 密钥可前往官网控制台 https://console.cloud.tencent.com/cam/capi 进行获取
                Credential cred = new Credential
                {
                    SecretId = "",
                    SecretKey = ""
                };
                // 实例化一个client选项，可选的，没有特殊需求可以跳过
                ClientProfile clientProfile = new ClientProfile();
                // 实例化一个http选项，可选的，没有特殊需求可以跳过
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("lke.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;

                // 实例化要请求产品的client对象,clientProfile是可选的
                LkeClient client = new LkeClient(cred, "ap-guangzhou", clientProfile);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                GetReconstructDocumentResultRequest req = new GetReconstructDocumentResultRequest();
                req.TaskId = taskId;
                // 返回的resp是一个GetReconstructDocumentResultResponse的实例，与请求对象对应
                GetReconstructDocumentResultResponse resp = client.GetReconstructDocumentResultSync(req);
                // 输出json格式的字符串回包
                Console.WriteLine(AbstractModel.ToJsonString(resp));
                return resp.DocumentRecognizeResultUrl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }

        /// <summary>
        /// 第三步 根据文档url下载文档识别后的ZIP
        /// </summary>
        /// <param name="fileUrl"></param>
        public static string DownloadFile(string fileUrl)
        {       
           // 获取当前时间
            DateTime now = DateTime.Now;

            // 格式化时间戳，确保文件名合法且不包含非法字符
            string timestamp = now.ToString("yyyyMMdd_HHmmss_fff");
            string filePath = @"D:\OCRTest\"+ timestamp+".zip"; // 文件保存路径          
            try
            {
                using (WebClient client = new WebClient())
                {
                    // 下载文件到指定路径
                    client.DownloadFile(fileUrl, filePath);
                    return UnzipFile(filePath, timestamp); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"下载失败: {ex.Message}");
                return "-1";
            }
        }
        /// <summary>
        /// 第四步 解压zip 用来展示结果文件
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <param name="destinationFolder"></param>
        private static string UnzipFile(string zipFilePath,string fileName)
        {
            try
            {
                string destinationFolder = @"D:\OCRTest\"+ fileName;
                // 确保目标文件夹存在
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // 解压ZIP文件到指定的目标文件夹

                (new FastZip()).ExtractZip(zipFilePath,destinationFolder, "");

                Console.WriteLine("解压完成！");
                return destinationFolder;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解压过程中发生错误: {ex.Message}");
                return "-1";
            }
        }



    }
}
