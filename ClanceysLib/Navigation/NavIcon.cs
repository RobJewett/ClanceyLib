using System;
using System.Drawing;
using System.Collections;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
namespace ClanceysLib
{
	
	public class NavIcon :UIView
	{
		//private SizeF Size  = new SizeF(58,85);
		//private SizeF lblSize = new SizeF(58,20); 
		private float padding = 5f;
		private float TextFontSize =11f;
		/// <summary>
		/// Auto Resize and round off the image corners.
		/// </summary>
		public bool RoundImage = false;
		public bool KeepImageAspectRation = true;
		public float ColumnWidth{get;set;}
		public float RowHeight {get;set;}
		public UIImage Image {get;set;}
		public Func<UIResponder> ModalView{get;set;}
		public string Title {get;set;}
		public int NotificationCount {get;set;}
		public NavPage parent;
		private UIButton button;
		private UILabel label;
		
		public NavIcon ()
		{
			this.Frame = new RectangleF(0,0,0,0);
			
		}
		
		
		public void Refresh(PointF location)
		{
			var frame = this.Frame;
			frame.Location = location;
			frame.Height = RowHeight;
			frame.Width = ColumnWidth;
			this.Frame = frame;
			
			var imageH = RowHeight - padding - (TextFontSize + 5);
			var image = Graphics.ResizeImage(new SizeF(ColumnWidth,imageH),Image,KeepImageAspectRation);
			//var image = Image;
			if(RoundImage)
				image = Graphics.RemoveSharpEdges(image);
			
			var x = (frame.Width - image.Size.Width) /2;
			button = UIButton.FromType(UIButtonType.Custom);
			//Console.WriteLine("imageH :" + imageH);
			//Console.WriteLine("imageSize : " + image.Size);
			//Console.WriteLine("row : " + RowHeight);
			var y = imageH - image.Size.Height;
			//Console.WriteLine("y:" + y);
			button.Frame = new RectangleF(x,y,image.Size.Width,image.Size.Width);
			button.SetImage(Image,UIControlState.Normal);	
			button.TouchDown += delegate {
				parent.parent.LaunchModal(ModalView == null ? null : ModalView());
				
			};
			//button.SetImage(Graphics.AdjustImage(button.Frame, Image,CGBlendMode.Normal,UIColor.Blue),UIControlState.Highlighted);
			
			
			this.AddSubview(button);
			var lblLoc = new PointF(0,image.Size.Height + 5);
			label = new UILabel(new RectangleF(lblLoc,new SizeF(ColumnWidth,TextFontSize)));
			label.Text = Title;
			label.Font = UIFont.FromName("Arial",TextFontSize);
			label.TextAlignment = UITextAlignment.Center;
			this.AddSubview(label);
		}

		void HandleBtnTouchDown (object sender, EventArgs e)
		{
			
		}
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
		}
	}
}

