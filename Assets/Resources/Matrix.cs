//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
public class Matrix
{
	private float[,] matrixData;
	 const int r = 0;  const int c = 1;

	public Matrix (int rows, int cols)
	{
		matrixData = new float[rows, cols];
		int r1 = 0; 
		int c1 = 0;
		for(r1=0;r1 < rows;r1++)
		{
			for(c1=0;c1 < cols;c1++) 
			{
				matrixData[r1,c1] = 0;
			}
		}
	}
	public Matrix (float[,] matrixDataIn)
	{
		this.SetData (matrixDataIn);
	}

	public Matrix (Vector3 vec, bool colMatrix = true)
	{
		float [,] matrixDataIn;
		if( colMatrix == true)
			matrixDataIn = new float[3,1]{{vec.x},{vec.y},{vec.z}};
		else
			matrixDataIn = new float[1,3]{{vec.x,vec.y,vec.z}};

		this.SetData (matrixDataIn);
	}

	private void SetData(float[,] matrixDataIn)
	{
		matrixData = matrixDataIn;
	}

	public float[,] GetData()
	{
		return matrixData;
	}

	public  static Matrix operator *(Matrix m1, Matrix m2)
	{
		float[,] matrixData1 = m1.matrixData;
		float[,] matrixData2 = m2.matrixData;
		float[,] matrixResult = new float[matrixData1.GetLength(r),matrixData2.GetLength(c)];

		int r1 = 0; int c1 = 0;
		int r2 = 0; int c2 = 0; 
		float value;
		for(r1=0;r1 < matrixData1.GetLength(r);r1++)
		{
			for(c2=0;c2 < matrixData2.GetLength(c);c2++)
			{
				value = 0;
				for(c1=0;c1 < matrixData1.GetLength(c);c1++)
				{
					r2 = c1;
					value += matrixData1[r1,c1]*matrixData2[r2,c2];
				}
				matrixResult[r1,c2] = value;
			}

		}
		return new Matrix( matrixResult);
	}

	public static Matrix Inverse(Matrix m)
	{
		if (m.matrixData.GetLength (r) != m.matrixData.GetLength (c)) 
			return null; // The graceful fail
		if(m.matrixData.GetLength (r) == 2)
		{
			float det = Det (m);
			float[,] invDat = new float[m.matrixData.GetLength(r),m.matrixData.GetLength(c)];
			invDat [0,0] = m.matrixData[1,1];
			invDat [1,1] = m.matrixData[0,0];
			invDat [1,0] = -m.matrixData[1,0];
			invDat [0,1] = -m.matrixData[0,1];
			Debug.Log(new Matrix(invDat));
			invDat [0,0] /= det;
			invDat [1,0] /= det;
			invDat [0,1] /= det;
			invDat [1,1] /= det;

			return new Matrix(invDat);

		}
		if(m.matrixData.GetLength (r) == 3)
		{
			float det = Matrix.Det(m);
			Matrix[,] dm = new Matrix[3,3]; /// Det Matrix, D.M. dm.
			float[,] dpf = new float[3,3]; /// Det Product Float, D.P.F. dpf.


			dm[0,0] = new Matrix(new float [,] {{m[1,1],m[1,2]},{m[2,1],m[2,2]}});
			dm[0,1] = new Matrix(new float [,] {{m[0,2],m[0,1]},{m[2,2],m[2,1]}});
			dm[0,2] = new Matrix(new float [,] {{m[0,1],m[0,2]},{m[1,1],m[1,2]}});

			dm[1,0] = new Matrix(new float [,] {{m[1,2],m[1,0]},{m[2,2],m[2,0]}});
			dm[1,1] = new Matrix(new float [,] {{m[0,0],m[0,2]},{m[2,0],m[2,2]}});
			dm[1,2] = new Matrix(new float [,] {{m[0,2],m[0,0]},{m[1,2],m[1,0]}});

			dm[2,0] = new Matrix(new float [,] {{m[1,0],m[1,1]},{m[2,0],m[2,1]}});
			dm[2,1] = new Matrix(new float [,] {{m[0,1],m[0,0]},{m[2,1],m[2,0]}});
			dm[2,2] = new Matrix(new float [,] {{m[0,0],m[0,1]},{m[1,0],m[1,1]}});
			for (int r1=0; r1 < dm.GetLength(r); r1++)
			{
				for (int c1=0; c1 < dm.GetLength(c); c1++)
				{
					dpf[r1,c1] = Matrix.Det(dm[r1,c1])/det;					
				}
			}
			return new Matrix(dpf);
		}
		return null;
	}
	public static float Det(Matrix m)
	{
		if (m.matrixData.GetLength (r) != m.matrixData.GetLength (c)) 
			return 0; // The graceful fail
		if(m.matrixData.GetLength (r) == 2)
		{
			return m.matrixData[0,0]*m.matrixData[1,1] - m.matrixData[0,1]*m.matrixData[1,0];
		}

		if(m.matrixData.GetLength (r) == 3)
		{
			float [,] d= m.matrixData; 
			return d[0,0]*(d[1,1]*d[2,2] - d[1,2]*d[2,1])
				 - d[0,1]*(d[1,0]*d[2,2] - d[1,2]*d[2,0]) 
				 + d[0,2]*(d[1,0]*d[2,1] - d[1,1]*d[2,0]);
		}
		return 0;
	}

	public float this[int i,int i2]
	{
		get 
		{ 
			return matrixData[i,i2]; 
		}
		set 
		{ 
			matrixData[i,i2] = value; 
		}
	}

	public override string  ToString()
	{
		string result = "Matrix:("+matrixData.GetLength(r)+","+matrixData.GetLength(c)+") ["; 
		for(int r1=0;r1 < matrixData.GetLength(r);r1++)
		{
			if(r1 > 0)
				result += ";";
			for(int c1=0;c1 < matrixData.GetLength(c);c1++) 
			{
				if(c1 > 0)
					result += ",";
				result += matrixData[r1,c1].ToString();
			}
		}
		return result+ "]";
	}

	public static Matrix Transpose(Matrix m)
	{
		Matrix t = new Matrix (m.matrixData.GetLength (c), m.matrixData.GetLength (r));
		for(int r1=0;r1 < m.matrixData.GetLength(r);r1++)
		{
			for(int c1=0;c1 < m.matrixData.GetLength(c);c1++) 
			{
				t[c1,r1] = m[r1,c1];
			}
		}
		return t;

	}

	public static explicit operator Vector3 (Matrix m)  
	{ 
		if(m.matrixData.GetLength(r) == 3 && m.matrixData.GetLength(c) == 1) 
			return new Vector3 (m [0, 0], m [1, 0], m [2, 0]);
		else if(m.matrixData.GetLength(r) == 1 && m.matrixData.GetLength(c) == 3)
			return new Vector3 (m [0, 0], m [0, 1], m [0, 2]);
		else
		{
			throw new Exception("Christ that matrix can never be a Vector!");
			return new Vector3 (0, 0, 0);
		}
	}

	public static implicit operator Matrix (Vector3 v)  
	{ 
		return new Matrix(v);
	}
	/*
	public static implicit operator Vector3 (Matrix m)  
	{ 
		Vector3 nwVec;
		try
		{
			nwVec = (Vector3)m; 
		}
		catch(Exception e)
		{
			nwVec = new Vector3(0,0,0);
		}
		finally
		{
			return nwVec;
		}
	}*/


}
