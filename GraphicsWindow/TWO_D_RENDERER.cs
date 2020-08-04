using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicsWindow
{
    class TWO_D_RENDERER :   SoftRender
    {
        Matrix2D curr_tr = new Matrix2D();
 
        public TWO_D_RENDERER(int r, int c)
            :
               base(r, c)
        {
            curr_tr.SetIdentity(); 
        }

        public void SetTransform(Matrix2D mat)
        {
            curr_tr = mat;

        }

        public void ResetTransform()
        {

            curr_tr.SetIdentity(); 
        }

        public void RectangleT(double x , double y , double  x1,double y1,T_COLOR col)
        {
            curr_tr.Transform(ref x,ref y);
            curr_tr.Transform(ref x1, ref y1);
            base.Rectangle((int)x,(int)y,(int)x1,(int) y1, col); 

        }

        public void LineT(double x, double y, double x1, double y1, T_COLOR col)
        {
            curr_tr.Transform(ref x, ref y);
            curr_tr.Transform(ref x1, ref y1);
            base.Line((int)x, (int)y, (int)x1, (int)y1, col);

        }
        public void Line2T(double x, double y, double x1, double y1, T_COLOR col)
        {
            curr_tr.Transform(ref x, ref y);
            curr_tr.Transform(ref x1, ref y1);
            base.Line2((int)x, (int)y, (int)x1, (int)y1, col,5);

        }
    }
}
