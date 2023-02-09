using System;
using System.Drawing.Text;

public class Portal
{
	private bool portal1placed;
	private bool portal2placed;

	private (int,int) portal1Pos;
	private (int,int) portal2Pos;
	public Portal()
	{
		portal1placed= false;	
		portal2placed= false;

	}
	public (int, int) getPortal1Pos()
	{
		return portal1Pos;
	}
    public (int, int) getPortal2Pos()
    {
        return portal1Pos;
    }
	public void setPortal1Placed(bool _bool)
	{
		portal1placed= _bool;
	}
    
	
}
