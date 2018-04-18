@ModelType Assignment2.USER_ACCOUNT
@Code
	ViewData("Title") = "Index"
End Code
<div class="login-page">
	<h1 class="hometext">M.R Bank</h1>
	@Using (Html.BeginForm("Login", "Home", FormMethod.Post))
		@Html.AntiForgeryToken()
	@<div Class="form">
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})
		<div class="login-form" action="Login" method="post">
			<input type="text" placeholder="username" name="username" />
			<input type="password" placeholder="password" name="password" />
			<Button type="submit" value="Login" name="Login"> Login</Button>
			<p class="message">Not registered? @Html.ActionLink("Create an account", "Create", "Home", New With {.area = ""})</p>
		</div>
	</div>
	End Using
</div>