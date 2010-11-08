using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.Foundation;
namespace ClanceysLib
{
	public class NavPage : UIView
	{
		public List<NavIcon> Icons {get;set;}
		public int Columns = 4;
		public int Rows = 5;
		public float Padding = 5;
		public NavLauncher parent;
		public NavPage():base()
		{
			
		}
		public NavPage (RectangleF rect): base(rect)
		{
			
		}
		
		
		public void Refresh()
		{
			float columnWidth = ((Frame.Width - (Padding * (Columns + 1) )) / Columns);
			float rowsHeight = ((Frame.Height - (Padding * 2 )) / Rows);
			float currentH = Padding;
			float currentW = Padding;
			int currentColumn = 1;
			foreach(var icon in Icons)
			{
				if(Columns < currentColumn)
				{
					currentW = Padding;
					currentH += rowsHeight + Padding;
				}
				Console.WriteLine(currentW + " : " + currentH);
				icon.parent = this;
				icon.ColumnWidth = columnWidth;
				icon.RowHeight = rowsHeight;
				icon.Refresh(new PointF( currentW, currentH));
				if(icon.Superview != this)
					this.AddSubview(icon);
				currentColumn ++;
				currentW += columnWidth + Padding;
			}	
		}
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
		}
		
	}
}

