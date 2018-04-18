@ModelType Assignment2.USER_ACCOUNT
@Code
	ViewData("Title") = "create"
End Code
<div class="padding-top-8">

	<h2 class="hometext">create new account</h2>
	@Using (Html.BeginForm())
		@Html.AntiForgeryToken()

		@<div class="form">
			@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

			<div class="form-group">
				@Html.EditorFor(Function(model) model.FIRSTNAME, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "first name"}})
				@Html.ValidationMessageFor(Function(model) model.FIRSTNAME, "", New With {.class = "text-danger"})


				@Html.EditorFor(Function(model) model.LASTNAME, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "last name"}})
				@Html.ValidationMessageFor(Function(model) model.LASTNAME, "", New With {.class = "text-danger"})

				@Html.EditorFor(Function(model) model.PASSWORD, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "password"}})
				@Html.ValidationMessageFor(Function(model) model.PASSWORD, "", New With {.class = "text-danger"})

				<input type="text" placeholder="confirm password" name="confirmpassword" />

				@Html.EditorFor(Function(model) model.EMAIL, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "email address"}})
				@Html.ValidationMessageFor(Function(model) model.EMAIL, "", New With {.class = "text-danger"})

				<select name="secQuestion">
					<option value="null" selected>select a security question</option>
					@For Each m In ViewData("Questions")
						@<option value="@m">@m</option>
					Next m
				</select>
				<input type="text" placeholder="security answer" name="secanswer" /> 
				<select name="accType">
					<option value="null" selected>select account type</option>
					<option value="savings">Savings</option>
					<option value="chequing">Chequing</option>
				</select>
				<button type = "submit" value="Create">Create</button>
                <p Class="message">@Html.ActionLink("Back to Home", "Index")</p>
			</div>
		</div>
	End Using
</div>
