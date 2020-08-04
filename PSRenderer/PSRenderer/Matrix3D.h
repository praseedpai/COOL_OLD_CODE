#ifndef _MATRIX_3D_DOT_H
#define _MATRIX_3D_DOT_H

class Matrix3D
{
private:
	float m_x[16];
public:
	///////////////////////////////////
	//
	//  Create an identity matrix
	//
	Matrix3D()
	{
       Unit();
	}
	///////////////////////////////////////
	//
	// Create a matrix out of an array of floats
	//
	Matrix3D(float pv[16])
	{
         memcpy(m_x,pv,16*sizeof(float));
	}
	/////////////////////////////////////////
	//
	// Copy constructor
	//
	//
    Matrix3D( const Matrix3D& pv )
	{
      memcpy(m_x,pv.m_x,16*sizeof(float));

	}
	////////////////////////////////////////////
	//
	//
	//
	//
	Matrix3D& operator = ( const Matrix3D& pv )
	{
        memcpy(m_x,pv.m_x,16*sizeof(float));
        return *this;
	}
	////////////////////////////////////////
	//
	// Set the current matrix to unit
	//
    void Unit()
	{
      m_x[0]=m_x[5]=m_x[10]=m_x[15]=1;
      m_x[1]=m_x[2]=m_x[3]=m_x[4]=m_x[6]=m_x[7]=m_x[8]=m_x[9]=m_x[11]=m_x[12]=m_x[13]=m_x[14]=0;
	}
	////////////////////////////////////
	//
	// 
	//
	//
    void Transpose()
	{


	}





};


#endif