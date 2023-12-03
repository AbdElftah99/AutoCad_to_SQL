using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

using System.Data;
using System.Data.SqlClient;
using CADDB.DB;

namespace CADDB
{
    public class DBLoadUtil
    {
        //Load all the Line Objects into DataBase
        public string LoadLines()
        {
            string result = string.Empty;
            SqlConnection conn = DBUtil.GetConnection();

            try
            {
                //Get the Doc and Editor Object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start , "Line") , 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);

                    //Check if slected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double startPtX = 0.0;
                        double startPtY = 0.0;
                        double endPtX = 0.0;
                        double endPtY = 0.0;
                        double length = 0.0;

                        string layer = "", ltype = "", color = "";

                        Line line = new Line();

                        SelectionSet ss = ssPrompt.Value;

                        string sql = @"INSERT INTO dbo.Lines (StartPtX , StartPtY , EndPtX , EndPtY , Layer , Color , LineType , Length , Created)
                                        VALUES (@StartPtX , @StartPtY ,@EndPtX , @EndPtY , @Layer , @Color , @LineType , @Length , @Created) ";

                        conn.Open();

                        //Loop Through The Selection set
                        foreach (SelectedObject sObj in ss)
                        {
                            line = trans.GetObject(sObj.ObjectId, OpenMode.ForWrite) as Line;
                            startPtX = line.StartPoint.X;
                            startPtY = line.StartPoint.Y;
                            endPtX= line.EndPoint.X;
                            endPtY = line.EndPoint.Y;
                            layer = line.Layer;
                            ltype = line.Linetype;
                            length = line.Length;
                            color = line.Color.ToString();

                            SqlCommand cmd = new SqlCommand(sql , conn);
                            cmd.Parameters.AddWithValue("@StartPtX" , startPtX);
                            cmd.Parameters.AddWithValue("@StartPtY", startPtY);
                            cmd.Parameters.AddWithValue("@EndPtX", endPtX);
                            cmd.Parameters.AddWithValue("@EndPtY", endPtY);

                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@LineType", ltype);
                            cmd.Parameters.AddWithValue("@Length", length);
                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);

                            cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }

                    result = "Done";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;  
            }
            finally 
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }  
            return result;
        }

        public string LoadPLines()
        {
            string result = string.Empty;
            SqlConnection conn = DBUtil.GetConnection();

            try
            {
                //Get the Doc and Editor Object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);

                    //Check if slected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                       
                        double length = 0.0;
                        string layer = "", ltype = "", color = "";
                        string coord = "";
                        bool isclosed = false;


                        Polyline line = new Polyline();

                        SelectionSet ss = ssPrompt.Value;

                        string sql = @"INSERT INTO dbo.PLines ( Layer , Color , LineType , Length , Coordinates , IsClosed, Created)
                                        VALUES (@Layer , @Color , @LineType , @Length ,@Coordinates ,@IsClosed , @Created) ";

                        conn.Open();

                        //Loop Through The Selection set
                        foreach (SelectedObject sObj in ss)
                        {
                            line = trans.GetObject(sObj.ObjectId, OpenMode.ForWrite) as Polyline;
                        
                            layer = line.Layer;
                            ltype = line.Linetype;
                            length = line.Length;
                            color = line.Color.ToString();
                            isclosed = line.Closed;
                            coord = CommonUtils.Common.GetrPolyLineCoord(line);

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@LineType", ltype);
                            cmd.Parameters.AddWithValue("@Length", length);
                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Coordinates", coord);
                            cmd.Parameters.AddWithValue("@IsClosed", isclosed);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }

                    result = "Done";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }


        //Load all the Mtext Objects into DataBase
        public string LoadMText()
        {
            string result = string.Empty;
            SqlConnection conn = DBUtil.GetConnection();

            try
            {
                //Get the Doc and Editor Object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "MText"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);

                    //Check if slected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double insPtX = 0.0;
                        double insPtY = 0.0;
                   
                        double height = 0.0 , width =0.0;

                        string layer = "", textStyle = "", color = "";

                        int attachment;

                        MText mtx = new MText();

                        string tx = string.Empty;

                        SelectionSet ss = ssPrompt.Value;

                        string sql = @"INSERT INTO dbo.MTexts (InsPtX , InsPtY  , Layer , Color , TextStyle , Height , Width , Text, Attachment , Created)
                                        VALUES (@InsPtX , @InsPtY , @Layer , @Color , @TextStyle , @Height , @Width , @Text , @Attachment  , @Created) ";

                        conn.Open();

                        //Loop Through The Selection set
                        foreach (SelectedObject sObj in ss)
                        {
                            mtx = trans.GetObject(sObj.ObjectId, OpenMode.ForWrite) as MText;
                            insPtX = mtx.Location.X;
                            insPtY = mtx.Location.Y;
                         
                            layer = mtx.Layer;
                            textStyle = mtx.TextStyleName;
                            height = mtx.TextHeight;
                            width = mtx.Width;
                            tx = mtx.Contents;
                            int.TryParse(mtx.Text, out attachment);
                            color = mtx.Color.ToString();

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@InsPtX", insPtX);
                            cmd.Parameters.AddWithValue("@InsPtY", insPtY);
                     
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@TextStyle", textStyle);
                            cmd.Parameters.AddWithValue("@Attachment", attachment);

                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);

                            cmd.Parameters.AddWithValue("@Height", height);
                            cmd.Parameters.AddWithValue("@Width", width);
                            cmd.Parameters.AddWithValue("@Text", tx);

                            cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }

                    result = "Done";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
