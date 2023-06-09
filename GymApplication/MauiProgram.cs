﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using GymApplication.Data;
using GymApplication.Services;
using BlazorStrap;

namespace GymApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddBlazorStrap();

		var adminDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"AdminDB.db3");
		builder.Services.AddSingleton<AdminService>(x => ActivatorUtilities.CreateInstance<AdminService>(x, adminDBPath));
		var staffDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"StaffDB.db3");
		builder.Services.AddSingleton<StaffService>(x => ActivatorUtilities.CreateInstance<StaffService>(x, staffDBPath));
		var customerDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"CustomerDB.db3");
		builder.Services.AddSingleton<CustomerService>(x => ActivatorUtilities.CreateInstance<CustomerService>(x, customerDBPath));
		var memberDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"MemberDB.db3");
		builder.Services.AddSingleton<MemberService>(x => ActivatorUtilities.CreateInstance<MemberService>(x, memberDBPath));
		return builder.Build();
	}
}
