using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Media3D;

namespace SphereSeams
{
    public static class G3
    {
        #region Polygons

        // Make points to define a regular polygon.
        public static Point3D[] MakePolygonPoints(int numSides,
            Point3D center, Vector3D vx, Vector3D vy)
        {
            // Generate the points.
            Point3D[] points = new Point3D[numSides];
            double dtheta = 2 * Math.PI / numSides;
            double theta = Math.PI / 2;
            for (int i = 0; i < numSides; i++)
            {
                points[i] = center + vx * Math.Cos(theta) + vy * Math.Sin(theta);
                theta += dtheta;
            }
            return points;
        }

        #endregion Polygons

        #region Spheres

        // Return a point on a spheroid.
        public static Point3D SpherePoint(Point3D center, double r, double theta, double phi)
        {
            double y = r * Math.Cos(phi);
            double h = r * Math.Sin(phi);
            double x = h * Math.Sin(theta);
            double z = h * Math.Cos(theta);
            return center + new Vector3D(x, y, z);
        }

        #endregion Spheres
    }
}
