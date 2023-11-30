﻿using Core.Common.Models;
using Methodic.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class MeasureUnitList
{
	[Parameter]
	public Action<long> OnDetail { get; set; }

	[Parameter]
	public Action<long> OnEdit { get; set; }

	[Parameter]
	public Action OnAdd { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private UserQueryInfo QueryInfo { get; set; } = new();

	public MeasureUnitList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<QueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Total;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetMeasureUnitPageAsync(QueryInfo);
	}

	private void Edit(MeasureUnitModel item)
	{
		OnEdit?.Invoke(item.Id);
	}

	//private async Task DeleteAsync(FormModel item)
	//{
	//	var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
	//	if (confirmed)
	//	{
	//		var result = await StaticDataService.DeleteFormAsync(item);
	//		if (result)
	//		{
	//			await LoadAsync();
	//			StateHasChanged();
	//		}
	//	}
	//}

	private void Form()
	{
		OnAdd?.Invoke();
	}
}
