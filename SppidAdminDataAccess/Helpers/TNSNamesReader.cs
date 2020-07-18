using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace TNSNamesReader
{
    /*  REFERENCE:  https://www.codeproject.com/Articles/30962/TNSNames-Reader
     *  USAGE:
     *          - Create an instance of the class in your form.
     *          private TNSNamesReader tnsNamesReader = new TNSNamesReader();
     *          
     *          - Populate a list control (combo, listbox, etc.) to let your user select the Oracle Home where the tnsnames.ora file will be read.
     *          cmbOracleHome.DataSource = tnsNamesReader.GetOracleHomes();
     *          
     *          - Populate another list control with the datasources found.
     *          this.cmbDataSource.DataSource = tnsNamesReader.LoadTNSNames((string)this.cmbOracleHome.SelectedValue);
     */

    public class TNSNamesReader
    {
        public List<string> GetOracleHomes()
        {
            List<string> oracleHomes = new List<string>();
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE");
            if (rgkAllHome != null)
            {
                foreach (string subkey in rgkAllHome.GetSubKeyNames())
                {
                    if (subkey.StartsWith("KEY_"))
                        oracleHomes.Add(subkey);
                }
            }
            return oracleHomes;
        }

        private string GetOracleHomePath(String OracleHomeRegistryKey)
        {
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkOracleHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\" +
                OracleHomeRegistryKey);

            if (!rgkOracleHome.Equals(""))
                return rgkOracleHome.GetValue("ORACLE_HOME").ToString();
            return "";
        }

        private string GetTNSNAMESORAFilePath(String OracleHomeRegistryKey)
        {
            string oracleHomePath = this.GetOracleHomePath(OracleHomeRegistryKey);
            string tnsNamesOraFilePath = "";
            if (!oracleHomePath.Equals(""))
            {
                tnsNamesOraFilePath = oracleHomePath + @"\NETWORK\ADMIN\TNSNAMES.ORA";
                if (!(System.IO.File.Exists(tnsNamesOraFilePath)))
                {
                    tnsNamesOraFilePath = oracleHomePath + @"\NET80\ADMIN\TNSNAMES.ORA";
                }
            }
            return tnsNamesOraFilePath;
        }

        public List<string> LoadTNSNames(string OracleHomeRegistryKey)
        {
            List<string> DBNamesCollection = new List<string>();
            string RegExPattern = @"[\n][\s]*[^\(][a-zA-Z0-9_.]+[\s]*=[\s]*\(";
            string strTNSNAMESORAFilePath = GetTNSNAMESORAFilePath(OracleHomeRegistryKey);

            if (!strTNSNAMESORAFilePath.Equals(""))
            {
                //check out that file does physically exists
                System.IO.FileInfo fiTNS = new System.IO.FileInfo(strTNSNAMESORAFilePath);
                if (fiTNS.Exists)
                {
                    if (fiTNS.Length > 0)
                    {
                        //read tnsnames.ora file
                        int iCount;
                        for (iCount = 0; iCount < Regex.Matches(
                            System.IO.File.ReadAllText(fiTNS.FullName),
                            RegExPattern).Count; iCount++)
                        {
                            DBNamesCollection.Add(Regex.Matches(
                                System.IO.File.ReadAllText(fiTNS.FullName),
                                RegExPattern)[iCount].Value.Trim().Substring(0,
                                Regex.Matches(System.IO.File.ReadAllText(fiTNS.FullName),
                                RegExPattern)[iCount].Value.Trim().IndexOf(" ")));
                        }
                    }
                }
            }
            return DBNamesCollection;
        }
    }
}
