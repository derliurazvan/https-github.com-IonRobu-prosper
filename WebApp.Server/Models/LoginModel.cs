﻿using Methodic.Common.Models;

namespace WebApi.Backend.Models;

public class LoginModel : Model
{
	public string UserName { get; set; }

	public string Password { get; set; }
}