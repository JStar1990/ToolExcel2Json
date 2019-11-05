using System;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;
using Excel2Json.Scripts;

namespace Excel2Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            out_config_url.Text = _defaultOutConfigUrl;
            out_script_url.Text = _defaultOutScriptUrl;
            _loadMain();
        }
        private List<string> _tableList;
        private DemoJson _jsonSet;
        private Form1 _self;
        private string _defaultOutConfigUrl = "../../Assets/Resources/";
        private string _defaultOutScriptUrl = "../../Assets/Scripts/resourceManager/configManager/base/";
        private void _loadMain()
        {
            _tableList = new List<string>();
            _self = this;
            _jsonSet = new DemoJson();
            try
            {
                var fs = new FileStream("main.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workBook = new XSSFWorkbook(fs);
                fs.Close();
                ISheet sheet = workBook.GetSheetAt(0);

                if (sheet == null)
                {
                    string str = "";
                    for (int i = 0; i < workBook.NumberOfSheets; i++)
                    {
                        str += workBook.GetSheetAt(i).SheetName + ",";
                    }
                    str = workBook.NumberOfSheets + str;
                    throw new Exception($"sheet不能为空！参数：0 工作簿信息：{str}");
                }
                //Excel行数
                int MaxRowNum = sheet.LastRowNum;
                for (; MaxRowNum >= 0; --MaxRowNum)
                {
                    if (sheet.GetRow(MaxRowNum)?.GetCell(0)?.StringCellValue.ToLower() == "end")
                    {
                        break;
                    }
                }
                int startRow = 3;

                // 第一行第一列为表名
                string name = sheet.GetRow(0)?.GetCell(0)?.StringCellValue;
                main_config.Text = name;

                IRow keys = sheet.GetRow(0);
                IRow type = sheet.GetRow(1);
                _tableList.Add("main.xlsx");
                //DataTable赋值
                for (int i = startRow; i <= MaxRowNum; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    list_configs.Items.Add(row.GetCell(1)?.StringCellValue, true);
                    string url = row.GetCell(2)?.StringCellValue;
                    _tableList.Add($"{url}.xlsx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _loadExcel (string fileName)
        {
            try
            {
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IWorkbook workBook = new XSSFWorkbook(fs);
                ISheet sheet = workBook.GetSheetAt(0);

                if (sheet == null)
                {
                    string str = "";
                    for (int i = 0; i < workBook.NumberOfSheets; i++)
                    {
                        str += workBook.GetSheetAt(i).SheetName + ",";
                    }
                    str = workBook.NumberOfSheets + str;
                    throw new Exception($"sheet不能为空！参数：0 工作簿信息：{str}");
                }
                //Excel行数
                int MaxRowNum = sheet.LastRowNum;
                for (; MaxRowNum >= 0; --MaxRowNum)
                {
                    if (sheet.GetRow(MaxRowNum)?.GetCell(0)?.StringCellValue.ToLower() == "end")
                    {
                        break;
                    }
                }
                int startRow = 3;

                // 第一行第一列为表名
                string name = sheet.GetRow(0)?.GetCell(0)?.StringCellValue;

                IRow keys = sheet.GetRow(0);
                IRow type = sheet.GetRow(1);
                IRow descs = sheet.GetRow(2);

                List<Dictionary<string, object>> tableList = new List<Dictionary<string, object>>();
                Dictionary<string, Dictionary<string, string>> objParams = new Dictionary<string, Dictionary<string, string>>();
                //DataTable赋值
                for (int i = startRow; i <= MaxRowNum; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.GetCell(1) == null) continue;
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    for (int j = 1; j < keys.LastCellNum; ++j)
                    {
                        _createValue(data, keys.GetCell(j), type.GetCell(j), row.GetCell(j), objParams);
                    }
                    tableList.Add(data);
                }
                string ss = "";
                if ( is_unity.Checked || suffix_cs.Checked )
                {
                    Dictionary<string, object> table = new Dictionary<string, object>();
                    table.Add("configs", tableList);
                    ss = JsonConvert.SerializeObject(table, _jsonSet);
                }
                else
                {
                    ss = JsonConvert.SerializeObject(tableList, _jsonSet);
                }
                string path = out_config_url.Text + fileName.Substring( 0, fileName.LastIndexOf('/') + 1);
                System.IO.File.WriteAllText($"{path}{name}.json", ss);

                _createClass(name.ToUpper(), keys, type, descs, objParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Dictionary<string, object> _createValue(Dictionary<string, object> data, ICell key, ICell type, ICell value, Dictionary<string, Dictionary<string, string>> objParams)
        {
            string tp = type.StringCellValue.ToLower();
            if (tp == "string")
            {
                if ( value != null )
                {
                    if ( value.CellType == CellType.Numeric )
                    {
                        data.Add(key.StringCellValue, value.NumericCellValue.ToString());
                    }
                    else
                    {
                        data.Add(key.StringCellValue, value.StringCellValue);
                    }
                }
                else
                {
                    data.Add(key.StringCellValue, "");
                }
            }
            else if (tp == "number")
            {
                if (value != null)
                {
                    if (value.CellType == CellType.Numeric)
                    {
                        data.Add(key.StringCellValue, Math.Floor(value.NumericCellValue));
                    }
                    else
                    {
                        data.Add(key.StringCellValue, long.Parse(value.StringCellValue));
                    }
                }
                else
                {
                    data.Add(key.StringCellValue, 0);
                }
            }
            else if (tp == "bool" || tp == "boolean")
            {
                data.Add(key.StringCellValue, value != null ? (value.StringCellValue.ToLower() == "true") : false);
            }
            else if (tp == "array")
            {
                if ( value != null )
                {
                    string arrStr = value.StringCellValue.Replace("\"", "");
                    data.Add(key.StringCellValue, arrStr.Substring(1, arrStr.Length - 2).Split(','));
                }
                else
                {
                    data.Add(key.StringCellValue, new string[] { });
                }
            }
            else if ( tp == "object" )
            {
                if (!objParams.ContainsKey(key.StringCellValue.ToUpper())) objParams.Add(key.StringCellValue.ToUpper(), new Dictionary<string, string>());
                Dictionary<string, string> param;
                objParams.TryGetValue(key.StringCellValue.ToUpper(), out param);
                Dictionary<string, object> obj = new Dictionary<string, object>();
                if ( value != null )
                {
                    string[] arr = value.StringCellValue.Split(',');
                    for (int i = 0; i < arr.Length; ++i )
                    {
                        string[] aa = arr[i].Split(':');
                        int result;
                        bool succ = int.TryParse(aa[1], out result);

                        if (suffix_cs.Checked)
                        {
                            if (!param.ContainsKey(aa[0])) param.Add(aa[0], succ ? "int" : "string");
                        }

                        if (succ) obj.Add(aa[0], result);
                        else obj.Add(aa[0], aa[1]);
                    }
                }
                data.Add(key.StringCellValue, obj);
            }
            return data;
        }

        private void _createClass (string name, IRow keys, IRow keyType, IRow descs, Dictionary<string,Dictionary<string,string>> objClass)
        {
            if ( suffix_ts.Checked )
            {
                _createTsClass(name, keys, keyType, descs);
            }
            if ( suffix_cs.Checked )
            {
                _createCsClassForU3D(name, keys, keyType, descs, objClass);
            }
        }

        private void _createTsClass( string name, IRow keys, IRow keyType, IRow descs )
        {
            string param = "";
            for ( int i = 1; i < keys.LastCellNum; ++i )
            {
                if (param != "") param += "\n\t";
                string type = keyType.GetCell(i).StringCellValue.ToLower();
                string key = keys.GetCell(i).StringCellValue;
                string desc = descs.GetCell(i)?.StringCellValue;

                param += $"/** {desc} */\n\t";
                if (type == "string")
                {
                    param += $"public {key}:string = \"\";";
                }
                else if (type == "number")
                {
                    param += $"public {key}:number = 0;";
                }
                else if (type == "array")
                {
                    param += $"public {key}:Array<string> = new Array<string>();";
                }
                else if (type == "bool" || type == "boolean")
                {
                    param += $"public {key}:boolean = false;";
                }
                else if (type == "object")
                {
                    param += $"public {key}:object = null;";
                }
                //param += "\n";
            }

            string file = "import RESOURCEBASE from \"../RESOURCEBASE\";\n\nexport default class "+name+" extends RESOURCEBASE{\n\tconstructor(data) { \n\t\tsuper(); \n\t\tthis.init(data);\n\t}\n\n\t" + param+ "\n}";
            System.IO.File.WriteAllText($"{_defaultOutScriptUrl}{name}.ts", file);
        }

        private void _createCsClassForU3D (string name, IRow keys, IRow keyType, IRow descs, Dictionary<string, Dictionary<string, string>> objParams)
        {
            string param = "";
            string objClass = "";
            for (int i = 1; i < keys.LastCellNum; ++i)
            {
                if (param != "") param += "\n\t\t";
                string type = keyType.GetCell(i).StringCellValue.ToLower();
                string key = keys.GetCell(i).StringCellValue;
                string desc = descs.GetCell(i)?.StringCellValue;

                param += $"/** {desc} */\n\t\t";
                if (type == "string")
                {
                    param += $"public string {key};";
                }
                else if (type == "number")
                {
                    param += $"public int {key};";
                }
                else if (type == "array")
                {
                    param += $"public Array {key};";
                }
                else if (type == "bool" || type == "boolean")
                {
                    param += $"public bool {key};";
                }
                else if (type == "object")
                {
                    param += $"public {key.ToUpper()} {key};";
                    string str = "";
                    if ( objParams.ContainsKey(key.ToUpper()) )
                    {
                        Dictionary<string, string> pm;
                        objParams.TryGetValue(key.ToUpper(), out pm);
                        foreach (var item in pm)
                        {
                            str += $"\n\t\tpublic {item.Value} {item.Key};";
                        }
                    }
                    objClass += "\n\t[Serializable]\n\tpublic class " + key.ToUpper() + "\n\t{" + str + "\n\t}";
                }
                //param += "\n";
            }
            
            string file = "using System;\n\nnamespace Dev.config\n{\n\t[Serializable]\n\tpublic class " + name + " : BaseResource\n\t{\n\t\t" + param + "\n\t}"+objClass+"\n}";
            System.IO.File.WriteAllText($"{_defaultOutScriptUrl}{name}.cs", file);
        }

        private void onClickOn(object sender, EventArgs e)
        {
    
        }

        private Thread _childThread;
        private void onClickStart(object sender, EventArgs e)
        {
            if (_childThread == null)
            {
                _showProgressBar(0);
                ThreadStart childref = new ThreadStart(_excel2Json);
                _childThread = new Thread(childref);
                _childThread.Start();
            }
        }

        private void _excel2Json ()
        {
            try
            {
                for (int i = 0; i < _tableList.Count; ++i)
                {
                    if (i > 0)
                    {
                        if (list_configs.GetItemChecked(i-1))
                            _loadExcel(_tableList[i]);
                    }
                    else
                    {
                        _loadExcel(_tableList[i]);
                    }
                    int pro = (int)((float)(i+1) / _tableList.Count * 100);
                    if (!progress_bar.InvokeRequired)
                    {
                        _showProgressBar(pro);
                    }
                    else
                    {
                        setProgress a1 = new setProgress(_showProgressBar);
                        Invoke(a1, new object[] { pro });//执行唤醒操作
                    }
                }
                _childThread.Abort();
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
                _childThread = null;
            }
            finally
            {
                _childThread = null;
            }
        }

        delegate void setProgress(int v);
        private void _showProgressBar ( int v )
        {
            progress_bar.Value = v;
        }

        private void onClickOff(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scriptSuffixSelect ( object sender, EventArgs e )
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}