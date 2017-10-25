using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;

namespace HW_03___Prospective_MDC_Student_App
{
	[Activity(Label = "Details about your Campus")]
	public class displayCampuses : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			string incomingName = Intent.GetStringExtra("SEND_NAME") ?? "No Name Received";
			string incomingMajor = Intent.GetStringExtra("SEND_MAJOR") ?? "No Major Received";
			string incomingCampus = Intent.GetStringExtra("CAMPUS") ?? "No Campus Received";
			long incomingCampusRef = Intent.GetLongExtra("CAMP_ID", 0);
			SetContentView(Resource.Layout.displayCampus);
			TextView textViewName = (TextView)FindViewById<TextView>(Resource.Id.txtName);
			//TextView textViewMajor = (TextView)FindViewById<TextView>(Resource.Id.txtMajor);
			//TextView textViewCampus = (TextView)FindViewById<TextView>(Resource.Id.txtCampus);
			textViewName.Text = string.Format("Hello {0}! Welcome to the {1} degree at the {2} Campus. For more information about this degree, click the CALL button below or for directions, click the DRIVE button.", incomingName, incomingMajor, incomingCampus);
			Button dialButton = FindViewById<Button>(Resource.Id.btnCall);
			Button driveButton = FindViewById<Button>(Resource.Id.btnDirections);

			// Change Image
			var MDCLogo =
					   FindViewById<ImageView>(Resource.Id.imgMDCLogo);
			string[] campusNames = Resources.GetStringArray(Resource.Array.campus_array);
			switch (incomingCampus)
			{
				case "Hialeah":
					MDCLogo.SetImageResource(Resource.Drawable.Hialeah_Campus_2C_H);
					break;
				case "Homestead":
					MDCLogo.SetImageResource(Resource.Drawable.Homestead_Campus_2C_H);
					break;
				case "InterAmerican":
					MDCLogo.SetImageResource(Resource.Drawable.InterAmerican_Campus_2C_H);
					break;
				case "Kendall":
					MDCLogo.SetImageResource(Resource.Drawable.Kendall_Campus_2C_H);
					break;
				case "Medical":
					MDCLogo.SetImageResource(Resource.Drawable.Medical_Campus_2C_H);
					break;
				case "North":
					MDCLogo.SetImageResource(Resource.Drawable.North_Campus_2C_H);
					break;
				case "West":
					MDCLogo.SetImageResource(Resource.Drawable.West_Campus_2C_H);
					break;
				case "Wolfson":
					MDCLogo.SetImageResource(Resource.Drawable.Wolfson_Campus_2C_H);
					break;
				default:
					MDCLogo.SetImageResource(Resource.Drawable.mdc_logo);
					break;
			}
			// Assign Phone number and Map strings
			string[] campusPhone = Resources.GetStringArray(Resource.Array.campus_phones);
			string[] campusMaps = Resources.GetStringArray(Resource.Array.campus_directions);

			// 

			// Build Contact and Directions Button 
			dialButton.Text = String.Format("Call {0} Campus", incomingCampus);
			driveButton.Text = String.Format("Drive to {0} Campus", incomingCampus);

			// Call Button 
			dialButton.Click += delegate
			{
				var uri = Android.Net.Uri.Parse(String.Format("tel:{0}", campusPhone[incomingCampusRef]));
				Intent dialCampus = new Intent(Intent.ActionDial, uri);
				StartActivity(dialCampus);
			};

			// Drive Button

			driveButton.Click += delegate
			{
				var uri = Android.Net.Uri.Parse(String.Format("{0}", campusMaps[incomingCampusRef]));
				Intent driveCampus = new Intent(Intent.ActionView, uri);
				StartActivity(driveCampus);

			};




		}
	}
}