@ModelType Assignment2.USER_QA_TB
@Code
	ViewData("Title") = "Security Confirmation"
End Code
<div class="login-page">
	<h1 class="hometext">M.R Bank</h1>
	@Using (Html.BeginForm("Security", "Home", FormMethod.Post))
		@Html.AntiForgeryToken()
		@<div Class="form">
			@Html.ValidationSummary(False, "", New With {.class = "text-danger"})
			<div class="login-form" action="Login" method="post">
				<label name="securityQuestion">@ViewData("securityQuestion")</label>
				<input type="password" placeholder="password" name="password" />
				<Button type="submit" value="Login" name="Login"> Login</Button>
			</div>
		</div>
	End Using
</div>