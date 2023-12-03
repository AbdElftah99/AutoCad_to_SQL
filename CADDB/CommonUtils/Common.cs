using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace CADDB.CommonUtils
{
    public static class Common
    {
        //Get All the vertices of PolyLine and return them to the calling method
        public static string GetrPolyLineCoord(Polyline pline)
        {
            var vcount = pline.NumberOfVertices;
            Point2d coord;
            StringBuilder coords = new StringBuilder();


            ///why vcount-1??
            ///ok as vcount count from 0 to n
            ///but each of for loop and the Polyline object method GetPoint2dAt(n) is zero index based!!
            ///so dont forget that we iterate till vcount - 1
            for (int i = 0; i < vcount -1 ; i++)
            {
                coord = pline.GetPoint2dAt(i);
                //coord[] is an indexer 
                coords.Append("(").Append(coord[0]).Append(",").Append(coord[1]).Append(")");

                ///now we want to iterate over all the vertices untill the vcount - 1 
                ///and sure, add a comma to seperate between them!! after the first coordinate
                if (i < vcount - 2)   // No comma after the last coordinate
                {
                    coords.Append(",");
                }
            }
            return coords.ToString();
        }
    }
}
