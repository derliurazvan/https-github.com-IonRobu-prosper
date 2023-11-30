﻿using Microsoft.AspNetCore.Components;

namespace WebApp.UI.Shared.Controls;

public partial class OptionItem
{
	[Parameter]
	public Action OnClick { get; set; }

	[Parameter]
	public string Text { get; set; }
}
