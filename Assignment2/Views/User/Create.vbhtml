@ModelType Assignment2.BANK_ACCOUNT
@Code
	ViewData("Title") = "Add an account"
End Code
<div class="padding-top-8">
	<h2 class="hometext">Add account</h2>
	@Using (Html.BeginForm())
		@Html.AntiForgeryToken()

		@<div class="form">
			@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

			<div class="form-group">
				<select name="accType">
					<option value="" selected>select account type</option>
					<option value="@ViewData("remAccount")">@ViewData("remAccount")</option>
				</select>
				<button type="submit" value="Create">Add account</button>
				<p Class="message">@Html.ActionLink("Back to Home", "Index")</p>
			</div>
		</div>
	End Using
</div>
