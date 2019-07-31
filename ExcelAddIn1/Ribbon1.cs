﻿using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO: 按照以下步骤启用功能区(XML)项:

// 1. 将以下代码块复制到 ThisAddin、ThisWorkbook 或 ThisDocument 类中。

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. 在此类的“功能区回调”区域中创建回调方法，以处理用户
//    操作(如单击某个按钮)。注意: 如果已经从功能区设计器中导出此功能区，
//    则将事件处理程序中的代码移动到回调方法并修改该代码以用于
//    功能区扩展性(RibbonX)编程模型。

// 3. 向功能区 XML 文件中的控制标记分配特性，以标识代码中的相应回调方法。

// 有关详细信息，请参见 Visual Studio Tools for Office 帮助中的功能区 XML 文档。


namespace ExcelAddIn1
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private frmMain frmMain;
        private string Copyfile = "";

        public Ribbon1()
        {
       
        }

        #region IRibbonExtensibility 成员

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExcelAddIn1.Ribbon1.xml");
        }

        #endregion

        #region 功能区回调
        //在此创建回调方法。有关添加回调方法的详细信息，请在解决方案资源管理器中选择功能区 XML 项，然后按 F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region 帮助器

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        public void rxbtn1_Click(IRibbonControl control)
        {

            //MessageBox.Show("找不到SAP主窗口！");
            if (frmMain == null)
            {
                frmMain = new frmMain();
                frmMain.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (frmMain == null)
            {
                frmMain = new frmMain();

            }
          
            frmMain.Show();
        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is frmMain)
            {
                frmMain = null;
            }

        }

    }
}
