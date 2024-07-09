using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace BrightnessWheel
{
    public class BrightnessWheelProject
    {
        public string DefaultProject = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                Module.ApplicationName, "project.bwp");

        public bool LoadedOnce = false;

        public BrightnessWheelProject()
        {

        }

        public bool SaveProject()
        {
            if (!LoadedOnce) return false;            

            try
            {
                string filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                    Module.ApplicationName, "project.bwp");

                string dir = System.IO.Path.GetDirectoryName(filepath);

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }

                return SaveProject(filepath);
            }
            catch {

                return false;
            }
        }

        public bool LoadProject()
        {            
            try
            {
                string filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                    Module.ApplicationName, "project.bwp");

                if (!System.IO.File.Exists(filepath))
                {
                    LoadedOnce = true;

                    return false;
                }

                bool suc=LoadProject(filepath);

                LoadedOnce = true;

                return suc; 

            }
            catch
            {
                return false;
            }
            finally
            {
                
            }
        }

        public bool LoadProject(string filepath)
        {            
            try
            {
                DataSet ds = new DataSet("ds");
                ds.ReadXml(filepath, XmlReadMode.ReadSchema);

                DataTable dt = ds.Tables[0];

                frmMain.Instance.fplWheelOptions.Controls.Clear();

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    try
                    {
                        ucWheelOption wo = new ucWheelOption();

                        DataRow dr = dt.Rows[k];

                        int iopt = int.Parse(dr["option"].ToString());

                        wo.cmbOption.SelectedIndex = iopt;                        

                        iopt = int.Parse(dr["step"].ToString());

                        wo.cmbStep.SelectedIndex = iopt;

                        iopt = int.Parse(dr["hotkey"].ToString());

                        wo.HotKey = iopt;

                        bool bc = bool.Parse(dr["control"].ToString());

                        wo.Control = bc;

                        wo.chkControl.Checked = bc;

                        bc = bool.Parse(dr["shift"].ToString());

                        wo.Shift = bc;

                        wo.chkShift.Checked = bc;

                        bc = bool.Parse(dr["alt"].ToString());

                        wo.Alt = bc;

                        wo.chkAlt.Checked = bc;

                        wo.HotKeyStr = dr["hotkeystr"].ToString();
                        wo.txtHotKey.Text = dr["hotkeystr"].ToString();
                                                
                        
                        
                            frmMain.Instance.fplWheelOptions.Controls.Add(wo);

                            frmMain.Instance.fplWheelOptions.SetFlowBreak(wo, true);

                            
                            wo.cmbOption_SelectedIndexChanged(null, null);

                            iopt = int.Parse(dr["channel"].ToString());

                            
                        
                    }
                    catch { }
                }

                if (frmMain.Instance.fplWheelOptions.Controls.Count == 0)
                {
                    return false;
                }
                else
                {
                    frmMain.Instance.tslProject.Text = filepath;
                    frmMain.Instance.CurrentProject = filepath;
                }

                LoadedOnce = true;

                return true;
            }
            catch {

                return false;
            }
            finally
            {
                
            }
        }

        public bool SaveProject(string filepath)
        {
            if (!LoadedOnce) return false;            

            try
            {
                string dir = System.IO.Path.GetDirectoryName(filepath);

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }

                DataSet ds = new DataSet("ds");
                DataTable dt = new DataTable("table");

                ds.Tables.Add(dt);

                dt.Columns.Add("option", typeof(int));                
                dt.Columns.Add("step", typeof(int));
                dt.Columns.Add("control", typeof(bool));
                dt.Columns.Add("shift", typeof(bool));
                dt.Columns.Add("alt", typeof(bool));
                dt.Columns.Add("hotkey", typeof(int));
                dt.Columns.Add("hotkeystr", typeof(string));
                
                for (int k = 0; k < frmMain.Instance.WheelOptions.Count; k++)
                {
                    DataRow dr = dt.NewRow();

                    ucWheelOption wo = frmMain.Instance.WheelOptions[k];

                    dr["option"] = wo.cmbOption.SelectedIndex;
                    
                    
                    dr["step"] = wo.cmbStep.SelectedIndex;
                    dr["control"] = wo.Control;
                    dr["shift"] = wo.Shift;
                    dr["alt"] = wo.Alt;
                    dr["hotkey"] = wo.HotKey;
                    dr["hotkeystr"] = wo.HotKeyStr;
                    
                    dt.Rows.Add(dr);
                }

                ds.WriteXml(filepath, XmlWriteMode.WriteSchema);

                frmMain.Instance.tslProject.Text = filepath;
                frmMain.Instance.CurrentProject = filepath;

                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
