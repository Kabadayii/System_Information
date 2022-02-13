using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Deployment.Application;
using System.Collections;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.Win32;
using System.Management;

namespace System_Memory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrPU();
        }
        private void CrPU()
        {

            var cpu = // Cpu
    new ManagementObjectSearcher("select * from Win32_Processor")
    .Get()
    .Cast<ManagementObject>()
    .First();

            var isletim = // İsletim Sistemi
            new ManagementObjectSearcher("select * from Win32_OperatingSystem")
        .Get()
        .Cast<ManagementObject>()
        .First();

            var video = // Ekran Kartı
    new ManagementObjectSearcher("select * from Win32_VideoController")
    .Get()
    .Cast<ManagementObject>()
    .First();

            var ram = // Ram bellek
    new ManagementObjectSearcher("select * from Win32_PhysicalMemory")
    .Get()
    .Cast<ManagementObject>()
    .First();

            string sistem = (string)cpu["name"];

            UInt64 Capacity = 0;
            Capacity += Convert.ToUInt64(ram["Capacity"].ToString());
            Capacity = Capacity / 1048576;
            Capacity = Capacity / 1024;
            string rambellek = Capacity.ToString();
            
            string ekran = (string)video["name"];
            
            string isletimsistemi = (string)isletim["Caption"];

            string sonuc = sistem + "\n" + rambellek + "\n" + isletimsistemi + "\n" + ekran;
            label4.Text = sonuc;
        }
    }
}
