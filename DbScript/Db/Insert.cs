﻿using DbScript.Reusables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbScript.DataGeneration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using TestDataGen.Reusables;

namespace DbScript.Db
{
    internal class Insert
    {
        DatabaseConnection dbConnectObj = new DatabaseConnection();
        public static string insertionBase(  DataTable table,string schema,string tablename)
        {
            string statement = "Insert into " + schema +"."+ tablename + " ( ";
            List<string> columns = DataOps.readDataTableByColumn("columnname", table);
            List<string> requiredforinsert = DataOps.readDataTableByColumn("requiredforinsert", table);
            List<string> IsIdentity = DataOps.readDataTableByColumn("IsIdentity", table);
            for (int i=0;i< columns.Count;i++)
            {
                if (requiredforinsert[i].ToUpper().Trim() == "YES")
                {
                    if (IsIdentity[i].ToUpper().Trim() != "YES")
                    {
                        if (i != table.Rows.Count - 1)
                        {
                            statement = statement + columns[i] + ",";
                        }
                        else
                        {
                            statement = statement + columns[i];
                        }
                    }
                }
            }
            if(statement.EndsWith(","))
            {
                statement = statement.Remove(statement.Length - 1, 1);
            }
            statement = statement + " ) values ({{data}})";

            return statement;
        }
        public static List<string> insertScripts(DataTable table, string schema, string tablename, int loopindex)
        {
            string scripts = "";
            List<string> listofData = new List<string>();
            string baseScripts = insertionBase(table,schema ,tablename);
            List<string> requiredforinsert = DataOps.readDataTableByColumn("requiredforinsert", table);
             List<string> typeOfGen = DataOps.readDataTableByColumn("generationtechniqueinsert", table);
            List<string> columnName = DataOps.readDataTableByColumn("columnname", table);
            List<string> IsIdentity = DataOps.readDataTableByColumn("IsIdentity", table);
            List<string> type = DataOps.readDataTableByColumn("type", table);

            string insertFilePath = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["dbfolder"] + "\\" + schema + "\\" + tablename + "\\" + ConfigurationManager.AppSettings["testdatasheet"];
            string insertfileSheet = ConfigurationManager.AppSettings["insertsheetname"];
            DataTable dataSet =new DataTable();
            if (typeOfGen.Any(item => item.Contains("Sheet")))
            {
                dataSet = ReadExcel.ExcelDataToDataTable(insertFilePath, insertfileSheet, true);
            }
            string dataset = "";
            for (int i = 0; i < columnName.Count; i++)
            {
                if (requiredforinsert[i].ToUpper().Trim() == "YES")
                {
                    if (IsIdentity[i].ToUpper().Trim() != "YES")
                    {
                        string generatedData = "";
                        if (typeOfGen[i].ToUpper().Trim() == "RANDOM")
                        {
                            
                            List<int> size = DataOps.readDataTableByColumn("size", table).ConvertAll(int.Parse);
                            List<string> format = DataOps.readDataTableByColumn("format", table);

                            generatedData = GenerateRandomData.GetRandomData(type[i], size[i], format[i]);
                        }
                        if (typeOfGen[i].ToUpper().Trim() == "SHEET")
                        {
                            generatedData = CaptureSheetData.readDatafromSheet(columnName[i], dataSet, loopindex);
                        }

                        listofData.Add(generatedData);
                        if (i != table.Rows.Count - 1)
                        {
                            if (type[i].ToUpper().Trim() == "INT" || type[i].ToUpper().Trim() == "BOOL" || type[i] == "BIT")
                            {

                                dataset = dataset + generatedData + ",";
                            }
                            else
                            {
                                dataset = dataset + "'" + generatedData + "',";
                            }
                        }
                        else
                        {
                            if (type[i].ToUpper().Trim() == "INT" || type[i].ToUpper().Trim() == "BOOL" || type[i] == "BIT")
                            {
                                dataset = dataset + generatedData;
                            }
                            else
                            {
                                dataset = dataset + "'" + generatedData + "'";
                            }
                        }
                    }
                }
                
            }
            if (dataset.EndsWith(","))
            {
                dataset = dataset.Remove(dataset.Length - 1, 1);
            }
            scripts = baseScripts.Replace("{{data}}", dataset);
            listofData.Add (scripts);
            return listofData;

        }


        // Method to insert data in the database //

        public static string insertData(string query)
        {
            string status = "not Executed";
        try
         {
                DatabaseConnection.Connection.Open();
                SqlCommand command = new SqlCommand(query, DatabaseConnection.Connection);
                command.ExecuteNonQuery();
                status = "Success";

            }
         catch (Exception ex)
         {
                status = "Failure \r\n" + ex.Message;
                Console.WriteLine(ex.Message);
         }
         finally
            {
                DatabaseConnection.Connection.Close(); 
            }
            return status;
        }

        public static DataTable performInsertion(DataTable table, string schema, string tablename, string count)
        {

            //Create Result dir to store result//
            Config.createResultDir(schema, tablename);

             //Prepare Dataset to add results
            List<string> columnName = DataOps.readDataTableByColumn("columnname", table);
            List<string> required = DataOps.readDataTableByColumn("requiredforinsert", table);
            List<string> IsIdentity = DataOps.readDataTableByColumn("isIdentity", table);
            List<string> requiredcolumnName = new List<string>();
            for (int i=0;i<required.Count; i++)
            {
                if (required[i].ToUpper().Trim()=="YES")
                {
                    if (IsIdentity[i].ToUpper().Trim() != "YES")
                    {
                        requiredcolumnName.Add(columnName[i]);
                    }
                }
            }
            DataTable resultData = Config.getResultDataTable(requiredcolumnName);

            for (int i=0; i<Convert.ToInt64(count);i++)
            {
                List<string> listofData = insertScripts(table, schema, tablename, i);
                string query = listofData.Last();
                String insertionStatus = insertData(query);
                listofData.Add(insertionStatus);
                Object[] data = listofData.ToArray();
                resultData.Rows.Add(data);
            }

            return resultData;

        }



    }
}
