using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;//引入speech库

namespace WindowsFormsSpeech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0,43,"http://www.lvsemayi.cn");
            //linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked); ;
        }
        //实例化speech
        SpeechSynthesizer speech = new SpeechSynthesizer();

        //定义一个字符串变量保存文本
        string words = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                words = textBox1.Text;
            }
            else {
                words = "请输入文字";
            }
            //speech.Speak(words);
            //调用speakAsync方法朗读输入的文字
            speech.SpeakAsync(words);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkColor = Color.Gray;
            linkLabel1.LinkVisited = true;
            linkLabel1.VisitedLinkColor =Color.DarkGray;

            LinkLabel linkLabel = (LinkLabel)sender;
            // 获取点击的链接
            LinkLabel.Link link = linkLabel.Links[linkLabel.Links.IndexOf(e.Link)];
            // 打开默认浏览器并导航到链接的URL
            System.Diagnostics.Process.Start(link.LinkData.ToString());
        }
    }
}
