using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace HW_03___Prospective_MDC_Student_App
{ 
		[Activity(Label = "Welcome to MDC", MainLauncher = true)]
		public class MainActivity : Activity
	{
	public string campusName { get; private set; }
	public long campusRefNum { get; private set; }

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		// Set our view from the "main" layout resource
		SetContentView(Resource.Layout.Main);

		// Set-up the Spinner
		Spinner spinner = FindViewById<Spinner>(Resource.Id.spnCampuses);

		// spinner 
		spinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
		var adapter = ArrayAdapter.CreateFromResource(
			this, Resource.Array.campus_array, Android.Resource.Layout.SimpleSpinnerItem);
		adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
		spinner.Adapter = adapter;

		// Set-Up the Button
		Button mainButton = (Button)FindViewById<Button>(Resource.Id.btnSubmit);


		mainButton.Click += delegate
		{
			EditText name = (EditText)FindViewById<EditText>(Resource.Id.txtName);
			EditText major = (EditText)FindViewById<EditText>(Resource.Id.txtMajor);
			Spinner campus = (Spinner)FindViewById<Spinner>(Resource.Id.spnCampuses);


			if (name.Text == null || major.Text == null || campusName == "Select Your Campus")
			{
				string toast = string.Format("Please complete all fields before clicking Continue");
				Toast.MakeText(this, toast, ToastLength.Long).Show();
			}
			else
			{
				var goDisplayCampuses = new Intent(this, typeof(displayCampuses));
				Bundle extras = new Bundle();
				extras.PutString("SEND_NAME", name.Text);
				extras.PutString("SEND_MAJOR", major.Text);
				extras.PutString("CAMPUS", campusName);
				extras.PutLong("CAMP_ID", campusRefNum);
				goDisplayCampuses.PutExtras(extras);
				StartActivity(goDisplayCampuses);
			}
		};




	}

	public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)

	{
		Spinner spinner = (Spinner)sender;
		campusName = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
		campusRefNum = spinner.GetItemIdAtPosition(e.Position);
		//Toast.MakeText(this, toast, ToastLength.Long).Show();

	}
}
}

