using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyWidget
{
	[BroadcastReceiver(Label = "NewAppWidget")]
	[IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
	[MetaData("android.appwidget.provider", Resource = "@layout/new_app_widget_info")]
	public class NewAppWidget : AppWidgetProvider
	{
		public override void OnReceive(Context context, Intent intent)
		{
			base.OnReceive(context, intent);
		}

		public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
		{
			//ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
			//appWidgetManager.UpdateAppWidget(me, UpdateAppWidget(context, appWidgetIds));
			foreach (var id in appWidgetIds)
			{
				UpdateAppWidget(context, appWidgetManager, id);
			}
		}

		private PendingIntent GetPendingIntent(Context context)
		{
			var intent = new Intent(context, Java.Lang.Class.FromType(typeof(MainActivity)));
			return PendingIntent.GetActivity(context, 0, intent, 0);
		}

	private void UpdateAppWidget(Context context, AppWidgetManager appWidgetManager, int id)
		{
			RemoteViews views = new RemoteViews(context.PackageName, Resource.Layout.new_app_widget);
			PendingIntent pi = GetPendingIntent(context);
			views.SetOnClickPendingIntent(Resource.Id.widgetRoot, pi);
		}
	}
}