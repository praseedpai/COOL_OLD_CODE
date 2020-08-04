using System;
using System.Drawing; 
using System.Drawing.Imaging;  
namespace GraphicsWindow
{
	/// <summary>
	/// Summary description for SoftRender.
	/// </summary>
	public class SoftRender
	{
		int _rows ; // Number of rows
		int _cols;  // Number of columns
		int _size;  // row * col
        int [] _pixels; // pixel values

		/// <summary>
		///   
		/// </summary>
		/// <param name="r"></param>
		/// <param name="c"></param>
		public SoftRender(int r, int c)
		{
            _rows = r;
			_cols = c;
			_size = r*c;
			_pixels = new int[_size];

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="r"></param>
		/// <param name="c"></param>
		/// <param name="color"></param>
		/// <returns></returns>

		public int SetPixel( int r,int c, int color )
		{
			if ( (  r < _rows && c < _cols ) &&  ( r >= 0 && c >= 0 ) )
			{

                 _pixels[ r*_cols + c ] = color;
                 return 0;
 
			}
			return -1;
		}

		public void Clear(int color )
		{

			for( int  index = 0; index < _size; index++ )
			{
                  _pixels[index]=color;

			}

		}

        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;

        }
        private void Swap(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;

        }
        ////
        //
        //

        public  void PutPixel( int x , int y , T_COLOR col )
        {
              
	          if ( ( x <  0 || x > _rows ) ||
                   ( y < 0  || y > _cols ) )
				      return;

                  int r = 0;
                  r |= col.A << 24;
                  r |= col.R << 16;
                  r |= col.G << 8;
                  r |= col.B;
                  SetPixel(y,x, r); 
	         

        }
        /////////////////////////////////////////
        //
        //
        //
        //
        //
       public  void Line(int x1, int y1, int x2, int y2, T_COLOR col)
        {
            if (x2 < x1)
            {
                Swap(ref x2,ref x1);
                Swap(ref y2,ref y1);

            }


            int deltax = x2 - x1;
            int deltay = y2 - y1;
            int xinc = 1, yinc = 1;
            int x = x1, y = y1;


            if (deltax < 0) { xinc = -1; deltax = -deltax; }
            if (deltay < 0) { yinc = -1; deltay = -deltay; }

            if (deltay <= deltax)
            {
                int c = 2 * deltax, m = 2 * deltay;
                int D = 0;
                while (true)
                {
                    PutPixel(x, y, col);
                    if (x == x2)
                        break;

                    x += xinc;
                    D += m;

                    if (D > deltax)
                    {
                        y += yinc; D -= c;

                    }
                }


            }
            else
            {

                int c = 2 * deltay, m = 2 * deltax;
                int D = 0;
                while (true)
                {
                    PutPixel(x, y, col);
                    if (y == y2)
                        break;

                    y += yinc;
                    D += m;

                    if (D > deltay)
                    {
                        x += xinc; D -= c;

                    }
                }





            }



        }
        /// <summary>
        ///    Thick line
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="col"></param>
        /// <param name="width"></param>
        public  void Line2(int x1, int y1, int x2, int y2, T_COLOR col, int width)
        {
            if (x2 < x1)
            {
                Swap(ref x2,ref  x1);
                Swap(ref y2,ref y1);

            }


            int deltax = x2 - x1;
            int deltay = y2 - y1;
            int xinc = 1, yinc = 1;
            int x = x1, y = y1;


            if (deltax < 0) { xinc = -1; deltax = -deltax; }
            if (deltay < 0) { yinc = -1; deltay = -deltay; }

            if (deltay <= deltax)
            {
                int c = 2 * deltax, m = 2 * deltay;
                int D = 0;
                while (true)
                {
                    for (int j = -width / 2; j <= width / 2; ++j)
                        PutPixel(x, y + j, col);
                    if (x == x2)
                        break;

                    x += xinc;
                    D += m;

                    if (D > deltax)
                    {
                        y += yinc; D -= c;

                    }
                }


            }
            else
            {

                int c = 2 * deltay, m = 2 * deltax;
                int D = 0;
                while (true)
                {
                    for (int j = -width / 2; j <= width / 2; ++j)
                        PutPixel(x + j, y, col);
                    if (y == y2)
                        break;

                    y += yinc;
                    D += m;

                    if (D > deltay)
                    {
                        x += xinc; D -= c;

                    }
                }





            }



        }

        /////////////////////////////////////////
        //
        //
        //
        //
        public void Circle(int x, int y, int r, T_COLOR col)
        {
            int p_x = 0;
            int p_y = r;
            int E = 0;
            int u = 1;
            int v = 2 * r - 1;

            while (p_x < p_y)
            {
                PutPixel(x + p_x, y + p_y, col);
                PutPixel(x + p_y, y - p_x, col);
                PutPixel(x - p_x, y - p_y, col);
                PutPixel(x - p_y, y + p_x, col);
                p_x++; E += u; u += 2;
                if (v < 2 * E) { p_y--; E -= v; v -= 2; }

                if (p_x > p_y) { break; }

                PutPixel(x + p_y, y + p_x, col);
                PutPixel(x + p_x, y - p_y, col);
                PutPixel(x - p_y, y - p_x, col);
                PutPixel(x - p_x, y + p_y, col);






            }



        }
        //////////////////////////////////////////////
        //
        //
        //
        //
        public void Rectangle(int x, int y, int x_1, int y_1, T_COLOR col)
        {
            if (x > x_1)
            {
                Swap(ref x,ref x_1);
            }

            if (y_1 < y)
            {
                Swap(ref y,ref y_1);
            }

            int d_x = x_1 - x;
            int d_y = y_1 - y;
            Line(x, y, x + d_x, y, col);
            Line(x, y, x, y + d_y, col);
            Line(x + d_x, y, x + d_x, y + d_y, col);
            Line(x, y + d_y, x + d_x, y + d_y, col);

        }

        ///////////////////////////////////////////////
        //
        //
        //
        //
        //
        public void FilledRectangle(int x, int y, int x_1, int y_1, T_COLOR col)
        {
            if (x > x_1)
            {
                Swap(ref x,ref x_1);
            }

            if (y_1 < y)
            {
                Swap(ref y,ref y_1);
            }

            int d_x = x_1 - x;
            int d_y = y_1 - y;

            int p_y = y;
            int p_x = x;
            while (p_y < y_1)
            {
                Line(p_x, p_y, p_x + d_x, p_y, col);
                p_y++;


            }


        }
        /////////////////////////////////////////////
	//
	//
	//
	//
	void CirclePoints( int cx,int cy,int x, int y, T_COLOR col )
	{
      Line(cx-x,cy-y,cx+x,cy-y,col);
      Line(cx-y,cy+x,cx+y,cy+x,col);
	  Line(cx-x,cy+y,cx+x,cy+y,col);
      Line(cx-y,cy-x,cx+y,cy-x,col);
	}

	////////////////////////////////////////////
	//
	//
	//
	//
	void EllipsePoints(int xc, int yc, int x , int y , T_COLOR col)
	{
        PutPixel(xc+x , yc + y , col );
		PutPixel(xc-x , yc + y , col );
		PutPixel(xc+x , yc - y , col );
		PutPixel(xc-x , yc - y , col );



	}


	////////////////////////////////////////////
	//
	//
	//
	//
	void EllipsePoints2(int xc, int yc, int x , int y , T_COLOR col)
	{
        Line(xc-x , yc + y ,xc+x,yc+y, col );
		Line(xc+x , yc - y ,xc-x,yc-y, col );
		



	}

	/////////////////////////////////////////////
	//
	//
	//
	//
	void PlotArc1( int x , int y , int sector ,T_COLOR col , int [] arcTest,
		int x_start_test , int x_end_test )
	{
         if ( arcTest[sector] == 0 )
			      return;

		 if (arcTest[sector] == 2 )
			     PutPixel(x,y,col);

		 if ((arcTest[sector] == 1) && (x >= x_start_test ))
		 {
               PutPixel(x,y,col);

		 }

		 if ( (arcTest[sector] == 3) && ( x <= x_end_test ))
			    PutPixel(x,y,col);

		 if ((arcTest[sector]==4) && ( x>=x_start_test ) && ( x<=x_end_test ) )
			    PutPixel(x,y,col);



	}


	/////////////////////////////////////////////
	//
	//
	//
	//
	void PlotArc2( int x , int y , int sector , T_COLOR col , int[] arcTest,
		int x_start_test , int x_end_test )
	{
         if ( arcTest[sector] == 0 )
			      return;

		 if (arcTest[sector] == 2 )
			     PutPixel(x,y,col);

		 if ((arcTest[sector] == 1) && (x <= x_start_test ))
		 {
               PutPixel(x,y,col);

		 }

		 if ( (arcTest[sector] == 3) && ( x >= x_end_test ))
			    PutPixel(x,y,col);

		 if ((arcTest[sector]==4) && ( x<=x_start_test ) && ( x>=x_end_test ) )
			    PutPixel(x,y,col);



	}


	/////////////////////////////////////////////
	//
	//
	//
	//
	void FillArc1(int xc, int yc, int x , int y , int sector , T_COLOR col , int[] arcTest,
		int x_start_test , int x_end_test )
	{
         if ( arcTest[sector] == 0 )
			      return;

		 if (arcTest[sector] == 2 )
			     Line2(xc,yc,x,y,col,3);

		 if ((arcTest[sector] == 1) && (x >= x_start_test ))
		 {
               Line2(xc,yc,x,y,col,3);

		 }

		 if ( (arcTest[sector] == 3) && ( x <= x_end_test ))
			    Line2(xc,yc,x,y,col,3);


		 if ((arcTest[sector]==4) && ( x>=x_start_test ) && ( x<=x_end_test ) )
			    Line2(xc,yc,x,y,col,3);




	}


	/////////////////////////////////////////////
	//
	//
	//
	//
	void FillArc2(int xc,int yc, int x , int y , int sector , T_COLOR col , int []arcTest,
		int x_start_test , int x_end_test )
	{
         if ( arcTest[sector] == 0 )
			      return;

		 if (arcTest[sector] == 2 )
			     Line2(xc,yc,x,y,col,3);

		 if ((arcTest[sector] == 1) && (x <= x_start_test ))
		 {
               Line2(xc,yc,x,y,col,3);


		 }

		 if ( (arcTest[sector] == 3) && ( x >= x_end_test ))
			    Line2(xc,yc,x,y,col,3);


		 if ((arcTest[sector]==4) && ( x<=x_start_test ) && ( x>=x_end_test ) )
			     Line2(xc,yc,x,y,col,3);



	}

	///////////////////////////////////////////
	//
	//
	// Draw Horizontal Line Seg
	//
	//
	//
    void DrawHorizontalLine( int Y , int LeftX , int RightX , T_COLOR col )
	{
       for( int X=LeftX; X<=RightX; X++ )
		    PutPixel(X,Y,col);


	}

     public void FilledCircle(int x, int y, int r, T_COLOR col)
        {
            int p_x = 0;
            int p_y = r;
            int E = 0;
            int u = 1;
            int v = 2 * r - 1;

            while (p_x < p_y)
            {
                CirclePoints(x, y, p_x, p_y, col);

                p_x++; E += u; u += 2;
                if (v < 2 * E) { p_y--; E -= v; v -= 2; }

                if (p_x > p_y) { break; }

                CirclePoints(x, y, p_x, p_y, col);


            }



        }

        /////////////////////////////////////////
        //
        //
        //
        //
       public  void DrawTriangle(int x_1, int y_1, int x_2, int y_2, int x_3, int y_3, T_COLOR col)
        {
            Line(x_1, y_1, x_2, y_2, col);
            Line(x_2, y_2, x_3, y_3, col);
            Line(x_3, y_3, x_1, y_1, col);


        }
        ///////////////////////////////////////////
        //
        //  Fill a Triangle with Solid Color
        //
        //  There are three types of triangles
        //      Flat Top
        //      Flat bottom
        //      other.
        //  Sort the vertices in increasing order - 0 - top 1 - bottom 2-middle 
        //
        public void FillTriangle(int x_1, int y_1, int x_2, int y_2, int x_3, int y_3, T_COLOR col)
        {
            if (y_2 < y_1)
            {
                Swap(ref y_1,ref y_2);  // Swap x and y
                Swap(ref x_2,ref  x_1);

            }

            if (y_3 < y_1)
            {
                Swap(ref y_3,ref  y_1);
                Swap(ref x_3,ref x_1);
            }

            if (y_2 < y_3)
            {
                Swap( ref y_3,ref y_2);
                Swap(ref x_3,ref  x_2);
            }

            float ledge = x_1;
            float redge = x_1;

            float derive1 = (float)(x_3 - x_1) / (y_3 - y_1);
            float derive2 = (float)(x_2 - x_1) / (y_2 - y_1);

            float left_d;
            float right_d;

            if (derive1 < derive2)
            {
                left_d = derive1;
                right_d = derive2;

            }
            else
            {
                left_d = derive2;
                right_d = derive1;


            }

            /////////////////////////////
            //
            // Render the top of the triangle
            //
            //
            //
            for (int y = y_1; y < y_3; y++)
            {

                for (int rs = (int)ledge; rs <=(int) redge; ++rs)
                {

                    PutPixel(rs, y, col);


                }

                ledge += left_d;
                redge += right_d;

            }
            /////////////////////////////////////////////////////////
            //
            //
            //
            //
            //
            if (derive1 < derive2)
            {
                left_d = (float)(x_3 - x_2) / (y_3 - y_2);


            }
            else
            {

                right_d = (float)(x_3 - x_2) / (y_3 - y_2);


            }

            for (int y = y_3; y < y_2; y++)
            {

                for (int rs = (int)ledge; rs <=(int) redge; ++rs)
                {

                    PutPixel(rs, y, col);


                }

                ledge += left_d;
                redge += right_d;

            }


        }
        ///////////////////////////////////////////////////////////////////
        //
        //  Draw a ellipse
        //
        //
        //
       public  void Ellipse(int xc, int yc, int rx, int ry, T_COLOR col)
        {

            int Rx2 = rx * rx;  // square of rx
            int Ry2 = ry * ry;  // square of ry
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;

            int p;
            int x = 0;
            int y = ry;
            int px = 0;
            int py = twoRx2 * y;

            EllipsePoints(xc, yc, x, y, col);

            /********* Region #1 *****************/
            p =(int) Math.Round(Ry2 - (Rx2 * ry) + (0.25 * Rx2));

            while (px < py)
            {
                x++;
                px += twoRy2;

                if (p < 0)
                {
                    p += Ry2 + px;
                }
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                EllipsePoints(xc, yc, x, y, col);

            }

            p =(int) Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);

            while (y > 0)
            {
                y--;
                py -= twoRx2;

                if (p > 0)
                {
                    p += Rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                EllipsePoints(xc, yc, x, y, col);

            }







        }
        ///////////////////////////////////////////////////////////////////
        //
        //  Draw a ellipse
        //
        //
        //
        public void FillEllipse(int xc, int yc, int rx, int ry, T_COLOR col)
        {

            int Rx2 = rx * rx;  // square of rx
            int Ry2 = ry * ry;  // square of ry
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;

            int p;
            int x = 0;
            int y = ry;
            int px = 0;
            int py = twoRx2 * y;

            EllipsePoints2(xc, yc, x, y, col);

            /********* Region #1 *****************/
            p = (int)Math.Round(Ry2 - (Rx2 * ry) + (0.25 * Rx2));

            while (px < py)
            {
                x++;
                px += twoRy2;

                if (p < 0)
                {
                    p += Ry2 + px;
                }
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                EllipsePoints2(xc, yc, x, y, col);

            }

            p = (int)Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);

            while (y > 0)
            {
                y--;
                py -= twoRx2;

                if (p > 0)
                {
                    p += Rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                EllipsePoints2(xc, yc, x, y, col);

            }







        }

        //////////////////////////////////////////
        //
        //
        //  Program to Draw an Arc
        //
        //
        //
       public  void DrawArc(int x, int y, int r, int sta, int enda, T_COLOR col)
       {
       int p_x = 0;
	   int p_y = r;
       int E=0;
	   int u=1;
	   int v=2*r-1;
       int x_start_test = (int)Math.Round(x + r * Math.Cos(sta * 3.14159 / 180.0));
       int x_end_test = (int)Math.Round(x + r * Math.Cos(enda * 3.14159 / 180.0));
	   int []arcTest = { 0 , 0, 0, 0, 0, 0, 0, 0, 0 };

	   int start_sector = (int)(sta/45);
	   int end_sector   = (int)(enda/45);

	   if ( start_sector == end_sector )
	   {
          arcTest[start_sector] = 4; // starts and ends in same sector

	   }
	   else {
          arcTest[start_sector] = 1;
		  arcTest[end_sector]=3;

		  for( int j=start_sector+1; j !=end_sector; j ++ )
		  {
              arcTest[j]=2;
			  if ( j == 8 )
				  j=-1;

		  }



	   }
       //////////////////////////////////////////////
	   //
	   //
	   //
	   //
	   //


	   while (p_x < p_y )
	   {
           //PutPixel(x+p_x,y+p_y,col);
		   //PutPixel(x+p_y,y-p_x,col);
		   //PutPixel(x-p_x,y-p_y,col);
		   //PutPixel(x-p_y,y+p_x,col);
		   PlotArc2(x+p_x,y+p_y,1,col,arcTest,x_start_test,x_end_test);
           PlotArc1(x+p_y,y-p_x,7,col,arcTest,x_start_test,x_end_test);
		   PlotArc1(x-p_x,y-p_y,5,col,arcTest,x_start_test,x_end_test);
		   PlotArc2(x-p_y,y+p_x,3,col,arcTest,x_start_test,x_end_test);

		   p_x++; E+=u; u+=2;
		   if ( v < 2*E ) { p_y--;E-=v;v-=2;}

		   if ( p_x > p_y ) { break; }

		  // PutPixel(x+p_y,y+p_x,col);
		  // PutPixel(x+p_x,y-p_y,col);
		  // PutPixel(x-p_y,y-p_x,col);
		  // PutPixel(x-p_x,y+p_y,col);
          PlotArc2(x+p_y,y+p_x,0,col,arcTest,x_start_test,x_end_test);
		  PlotArc1(x+p_x,y-p_y,6,col,arcTest,x_start_test,x_end_test);
		  PlotArc1(x-p_y,y-p_x,4,col,arcTest,x_start_test,x_end_test);
		  PlotArc2(x-p_x,y+p_y,2,col,arcTest,x_start_test,x_end_test);





	   }



 


   }

        //////////////////////////////////////////
        //
        //
        //  Program to Draw an Arc
        //
        //
        //
       public  void FillArc(int x, int y, int r, int sta, int enda, T_COLOR col)
   {
       int p_x = 0;
	   int p_y = r;
       int E=0;
	   int u=1;
	   int v=2*r-1;
	   sta +=90;
	   enda +=90;

	   if ( sta < 0 )
		    sta += 360;
	   if (sta > 360 )
		    sta -=360;

	   if (enda > 360 )
		    enda -=360;

	   if ( enda < 0 )
		    enda +=360;
        int x_start_test = (int)Math.Round(x + r * Math.Cos(sta * 3.14159 / 180.0));
        int x_end_test = (int)Math.Round(x + r * Math.Cos(enda * 3.14159 / 180.0));
	   int []arcTest = { 0 , 0, 0, 0, 0, 0, 0, 0, 0 };

	   int start_sector = (int)(sta/45);
	   int end_sector   = (int)(enda/45);

	   if ( start_sector == end_sector )
	   {
          arcTest[start_sector] = 4; // starts and ends in same sector

	   }
	   else {
          arcTest[start_sector] = 1;
		  arcTest[end_sector]=3;

		  for( int j=start_sector+1; j !=end_sector; j ++ )
		  {
              arcTest[j]=2;
			  if ( j == 8 )
				  j=-1;

		  }



	   }
       //////////////////////////////////////////////
	   //
	   //
	   //
	   //
	   //


	   while (p_x < p_y )
	   {
           //PutPixel(x+p_x,y+p_y,col);
		   //PutPixel(x+p_y,y-p_x,col);
		   //PutPixel(x-p_x,y-p_y,col);
		   //PutPixel(x-p_y,y+p_x,col);
		   FillArc2(x,y,x+p_x,y+p_y,1,col,arcTest,x_start_test,x_end_test);
           FillArc1(x,y,x+p_y,y-p_x,7,col,arcTest,x_start_test,x_end_test);
		   FillArc1(x,y,x-p_x,y-p_y,5,col,arcTest,x_start_test,x_end_test);
		   FillArc2(x,y,x-p_y,y+p_x,3,col,arcTest,x_start_test,x_end_test);

		   p_x++; E+=u; u+=2;
		   if ( v < 2*E ) { p_y--;E-=v;v-=2;}

		   if ( p_x > p_y ) { break; }

		  // PutPixel(x+p_y,y+p_x,col);
		  // PutPixel(x+p_x,y-p_y,col);
		  // PutPixel(x-p_y,y-p_x,col);
		  // PutPixel(x-p_x,y+p_y,col);
          FillArc2(x,y,x+p_y,y+p_x,0,col,arcTest,x_start_test,x_end_test);
		  FillArc1(x,y,x+p_x,y-p_y,6,col,arcTest,x_start_test,x_end_test);
		  FillArc1(x,y,x-p_y,y-p_x,4,col,arcTest,x_start_test,x_end_test);
		  FillArc2(x,y,x-p_x,y+p_y,2,col,arcTest,x_start_test,x_end_test);





	   }



 


   }
		/// <summary>
		///   
		/// </summary>
		/// <param name="g"></param>
		/// <returns></returns>

		public int Render( System.Drawing.Graphics g )
		{

			int r = _rows;
			int c = _cols;
			////
			//// Create a bit map equivalent to pixel array
			////

			Bitmap bmp = new Bitmap(  r, c,System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			Rectangle s = new Rectangle(0,0,r,c); 
            ////
            ////  Lock Bits for copying the Pixels to the bitmpa
            //// 
			BitmapData bd;
			bd = bmp.LockBits(s,System.Drawing.Imaging.ImageLockMode.ReadWrite,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb ); 

			
			System.IntPtr  tarr=bd.Scan0; 

			unsafe 
			{

				
				byte *marrayPtr = (byte *)tarr.ToPointer(); 
				
			
				for( int  index = 0; index < _size; index++ )
				{
					*marrayPtr++ =(byte)(_pixels[index]&0xFF) ;
					*marrayPtr++ =(byte)((_pixels[index]>>8 )&0xFF);
					*marrayPtr++ =(byte)((_pixels[index]>>16)&255);
                    *marrayPtr++ =(byte)0xFF; 
				}

			}

			bmp.UnlockBits( bd);

			g.DrawImage(bmp,0,0,r, c); 


            return 0;     

		}





	}
}
